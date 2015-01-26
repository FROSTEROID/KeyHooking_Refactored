using System; // Would You write something interesting in C# for Windows without this namespace?
using System.Diagnostics; // used to start a process of command line. ProcessStartInfo and Process.
using System.IO;		// Yeah, some of loggers can write to a file
using System.Runtime.InteropServices; // Needed to declare DLL using
using System.Text;		// Encoding matters
using System.Collections.Generic; // List<> is there
using System.Threading;	// Thread.Sleep is what i need there
using System.Windows.Forms; // Keys enumeration is here
using System.Windows.Forms.VisualStyles;

//This two are for IInputSimulator:
using WindowsInput; // contains the simulator class
using WindowsInput.Native; // holds VirtualKeyCode enumeration.

//TODO: COMMENT EVERYTHING!!!!
// Yeeeaaah, i'll do it one day. :D

namespace KeyboardExtending {

	#region Enums
	public enum Layout {
		RU = 1,
		EN = 2
	}
	public enum KeyAction {
		SysKeyDown = 0x0104,
		SysKeyUp = 0x0105,
		KeyDown = 0x0100,
		KeyUp = 0x0101,
	}
	#endregion

	#region Delegate Types and their arguments types
	public delegate void KeyActionHandler(IntPtr hookID, KeyActionArgs e);
	public delegate bool KeyActionHandlerEx(IntPtr hookID, KeyActionArgs e);
	/// <summary>
	/// Структура переменной с информацией о клавиатурном событии.
	/// </summary>
	public struct KeyActionArgs {
		public KeyActionArgs(Keys keyCode, int keyAction) { KeyCode = keyCode; KeyAction = keyAction; }
		public KeyActionArgs(int keyCode, int keyAction) { KeyCode = (Keys)keyCode; KeyAction = keyAction; }
		public Keys KeyCode;
		public int KeyAction;
	}
	#endregion

	#region Hooking
	public class KeyHooker {
		#region Constants
		#region keyActionCodes
		private const int WH_KEYBOARD_LL = 13; // Номер прерывания, как йа понимаю. А может быть, некий уровень/способ вмешательства в работу системы. Используется при назначении обработчика (Вызове SetWindowsHookEx).
		#endregion
		#endregion

		#region Parameters
		private static IntPtr _hookID = IntPtr.Zero; // Номер нашего прерывателя. Инициализировали нулём.
		#endregion

		#region DLL signatures and API-hooking-related types
		// Тут пиздец. Это сигнатуры использования библиотек, йа ещё не проникся их логикой. 
		// Этакое объявление о том, что в такой-то библиотеке есть такая-то функция, которая принимает такие-то аргументы.
		// Собсвенно, этот код позволяет этими самыми функциями пользоваться. На системе, где этих бибилиотек нет, ничего не выйдет хорошего.
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		// АПИшная Назначалка обработчика.
		private static extern IntPtr SetWindowsHookEx(int idHook,
			LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
			IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam); // Тип делегата для обработки события клавиатуры
		#endregion

		#region Hooking
		/// <summary>
		///  Назначатель обработчика
		/// </summary>
		/// <param name="proc">Некий держатель функции. Ему мы заранее присвоили функцию HookCallback()</param>
		/// <returns>Вроде, возвращает ID прерывателя... Или прерывания. Хз ваще, надо экспериментировать или читать где-то.
		/// Важно, что возвращаемый идентификатор потом можно использовать для отключения перехвата.</returns>
		private static IntPtr SetHook(LowLevelKeyboardProc proc) {
			using (Process curProcess = Process.GetCurrentProcess())
			using (ProcessModule curModule = curProcess.MainModule) {
				return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
			}
		}

		/// <summary>
		/// Задаваемая Функция - обработчик нажатия кнопки. Вызывается в прерывании.
		/// "отклик на действие с клавишей"
		/// </summary>
		/// <param name="nCode">Некий код, который если менее нуля, то всё плохо</param>
		/// <param name="wParam">Действие над клавишей</param>
		/// <param name="lParam">Код клавиши</param>
		/// <returns></returns>
		private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
			int keyCode;
			int keyAction;

			if (nCode >= 0) {
				keyCode = Marshal.ReadInt32(lParam);
				keyAction = (int)wParam;
			}
			else {
				return CallNextHookEx(_hookID, nCode, wParam, lParam);
			}

			bool block = false;
			if (OnKeyActionEx != null)
				block = OnKeyActionEx(_hookID, new KeyActionArgs(keyCode, keyAction));

			if (block)
				return new IntPtr(1);

			if (OnKeyAction != null)
				OnKeyAction(_hookID, new KeyActionArgs(keyCode, keyAction));

			return CallNextHookEx(_hookID, nCode, wParam, lParam); // Передаём управление следующему обработчику в системе
		}
		#endregion

		#region Events
		/// <summary>
		/// Стреляет, при попадании евента в Hooker. Позволяет реагировать, но не блокировать евент.
		/// В качестве определителя источника передаётся ID-указатель перехватывания. Можете составлять себе словари для них, если очень хочется несколько хуков.
		/// </summary>
		public event KeyActionHandler OnKeyAction;
		/// <summary>
		/// Подписка на это событе позволяет ещё и указать, должен ли Hooker заблокировать дальнейшую обработку евента системой
		/// Верните 1(true), чтобы заблокировать евент. 0(false) - пропустить далее.
		/// ВАЖНО: Hooker не станет вызывать OnKeyAction, если будет возвращено требование блокирования.
		/// Нельзя заблокировать Ctrl+Alt+Del.
		/// В качестве определителя источника передаётся ID-указатель перехватывания. Можете составлять себе словари для них, если очень хочется несколько хуков. :P
		/// </summary>
		public event KeyActionHandlerEx OnKeyActionEx;
		#endregion

		#region Structing
		/// <summary>
		/// По инициализации перехватчик "подписывается на клавиатурные события" при помощи SetWindowsHookEx.
		/// После этого можно подписаться на дёргаемые им события.
		/// </summary>
		public KeyHooker() {
			Hook();
		}
		/// <summary>
		/// В этом конструкторе можно сказать, должен ли Hooker немедленно начать перехват
		/// </summary>
		/// <param name="immediatelyHook">True - перехват начнётся сразу. Подписывайся и реагируй.
		/// False - можешь подписаться на события и после этого начать перехват методом Hook.</param>
		public KeyHooker(bool immediatelyHook) {
			if (immediatelyHook)
				Hook();
		}
		#endregion

		#region Public Commands
		/// <summary>
		/// Hook them all!
		/// </summary>
		public void Hook() {
			if (_hookID != IntPtr.Zero) return;
			_hookID = SetHook(HookCallback);
		}
		/// <summary>
		/// На случай проблем с устойчивостью перехвата.
		/// Если перехват ещё не выполняется, он просто начнётся этим методом.
		/// For the case of instable hook.
		/// </summary>
		public void Rehook() {
			if (_hookID != IntPtr.Zero) {
				UnhookWindowsHookEx(_hookID);
				_hookID = IntPtr.Zero;
			}
			_hookID = SetHook(HookCallback);
		}
		/// <summary>
		/// Let's get out here.
		/// </summary>
		public void Unhook() {
			UnhookWindowsHookEx(_hookID);
			_hookID = IntPtr.Zero;
		}
		#endregion

	}
	#endregion

	#region Binding
		#region BindInfo Classes
		public abstract class BindInfo {
			#region Parameters
			public bool Block;

			public Keys[] BindedKeys;
			public int Length;
			public int Passed = 0;
			#endregion

			#region Executing
				public abstract void Execute();
			#endregion

		}

		public class BindInfo_Keys : BindInfo {
			#region Consts
			public const int WAIT_BETWEEN_KEYACTIONS_EMULATING = 50; //milliseconds for Thread.Sleep
			#endregion

			#region Parameters
			private Keys[] _keysToEmulate;
			private KeyAction[] _actionsToEmulate;
			#endregion

			#region Structing
			/// <summary>
			/// Key stroke binding. Like Ctrl+T+G+...
			/// Will fire on the last keyDown. Firing means emulating the given keyActions chain
			/// To explain the chain, You supply two massives like:
			/// {Keys.RControlKey, Keys.G, Keys.G, Keys.RControlKey}
			/// {KeyAction.KeyDown, KeyAction.KeyDown, KeyAction.KeyUp, KeyAction.KeyUp}
			/// If You want to block the binded sequence while You're performing it,
			/// just pass TRUE to the last argument. 
			/// Note that if You then make a part of that sequence and perform an action
			/// that is not presented in the binded sequence, the blocked sequence will be passed to the system.
			/// </summary>
			/// <param name="bindedKeys"></param>
			/// <param name="keysToEmulate"></param>
			/// <param name="actionsToEmulate"></param>
			/// <param name="block"></param>
			public BindInfo_Keys(Keys[] bindedKeys, Keys[] keysToEmulate, KeyAction[] actionsToEmulate, bool block) {
				if (bindedKeys == null || keysToEmulate == null || actionsToEmulate == null) throw new Exception("Shit bricks, bitch!");
				Block = block;
				BindedKeys = bindedKeys;
				Length = bindedKeys.Length;
				_keysToEmulate = keysToEmulate;
				_actionsToEmulate = actionsToEmulate;
			}
			public BindInfo_Keys(Keys[] bindedKeys, Keys[] keysToEmulate, bool block) {
				if (bindedKeys == null || keysToEmulate == null) throw new Exception("Shit bricks, bitch!");
				Block = block;
				BindedKeys = bindedKeys;
				Length = bindedKeys.Length;
				_keysToEmulate = keysToEmulate;
				_actionsToEmulate = new KeyAction[keysToEmulate.Length*2];
				int i=0;
				for(;i<_keysToEmulate.Length; i++){
					_actionsToEmulate[i] = KeyAction.KeyDown;
					_actionsToEmulate[i + _keysToEmulate.Length] = KeyAction.KeyUp;
				}
			}
			#endregion

			#region Executing
			public override void Execute() {
				IInputSimulator s = new InputSimulator();
				for(int i=0; i<_keysToEmulate.Length; i++) {
					switch(_actionsToEmulate[i]) {
						case KeyAction.SysKeyUp:
						case KeyAction.KeyUp:
							s.Keyboard.KeyUp((VirtualKeyCode)_keysToEmulate[i]);
							break;
						case KeyAction.KeyDown:
						case KeyAction.SysKeyDown:
							s.Keyboard.KeyDown((VirtualKeyCode)_keysToEmulate[i]);
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
					Thread.Sleep(WAIT_BETWEEN_KEYACTIONS_EMULATING);
				}
			}
			#endregion
		}

		public class BindInfo_Command : BindInfo {
			#region Parameters
			readonly string _command;
			private readonly bool _hideConsole;
			#endregion

			#region Structing
			public BindInfo_Command(Keys[] bindedKeys, string command, bool hideConsole, bool block) {
				if (bindedKeys == null || string.IsNullOrEmpty(command)) throw new Exception("Shit bricks, bitch!");
				Block = block;
				_hideConsole = hideConsole;
				_command = command;
				BindedKeys = bindedKeys;
				Length = bindedKeys.Length;
			}
			#endregion

			#region Executing
			public override void Execute() {
				Process process = new Process();
				ProcessStartInfo startInfo = new ProcessStartInfo {
					FileName = "cmd.exe", 
					Arguments = "/C " + _command, 
					WindowStyle = _hideConsole ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal
				};
				process.StartInfo = startInfo;
				process.Start();
			}
			#endregion
		}

		public class BindInfo_Procedure: BindInfo {
			#region Parameters
			private EventHandler _procedure;
			#endregion

			#region Structing
			public BindInfo_Procedure(Keys[] bindedKeys, EventHandler procedure, bool block) {
				if (bindedKeys == null || procedure==null) throw new Exception("Shit bricks, bitch!");
				Block = block;
				_procedure += procedure;
				BindedKeys = bindedKeys;
				Length = bindedKeys.Length;
			}
			#endregion

			#region Executing
			public override void Execute() {
				_procedure(null, null);
			}
			#endregion
		}
		#endregion

	public class KeyBinder {
		#region Serving objects
		KeyHooker _hooker;
		#endregion

		#region KeyEvent struct
		struct KeyEvent {
			 public Keys Key;
			 public KeyAction Action;

			 public KeyEvent(Keys key, KeyAction action) {
				 Key = key;
				 Action = action;
			 }
		}
		#endregion

		#region Parameters
		List<BindInfo> _bindList;
		List<KeyEvent> _blocked;
		#endregion

		#region Structing
		public KeyBinder() {
			_bindList = new List<BindInfo>();
			_blocked = new List<KeyEvent>();
			_hooker = new KeyHooker();
			_hooker.OnKeyActionEx += _hooker_OnKeyActionEx;
		}
		#endregion

		#region Handling
		private bool _hooker_OnKeyActionEx(IntPtr hookID, KeyActionArgs e) {
			bool block = false;
			bool captured = false;
			foreach(var bind in _bindList) {
				if (((KeyAction)e.KeyAction==KeyAction.SysKeyDown || (KeyAction)e.KeyAction==KeyAction.KeyDown) && bind.BindedKeys[bind.Passed] == e.KeyCode) {
					bind.Passed++;
					captured = true;
					if (bind.Block) {
						block = true;
					}
					if(bind.Passed == bind.Length){
						_hooker.OnKeyActionEx -= _hooker_OnKeyActionEx;
						Unblock(_blocked.Count - bind.Length);
						_blocked.Clear();
						bind.Passed = 0;
						bind.Execute();
						_hooker.OnKeyActionEx += _hooker_OnKeyActionEx;
					}
				}
			}
			if(!captured) {
				_hooker.OnKeyActionEx -= _hooker_OnKeyActionEx;
				_blocked.Clear();
				_hooker.OnKeyActionEx += _hooker_OnKeyActionEx;
			}

			if(block)
				_blocked.Add(new KeyEvent(e.KeyCode, (KeyAction)e.KeyAction));

			return block;
		}
		private void Unblock(int count) {
			IInputSimulator s = new InputSimulator();
			int i = 0;
			foreach (var bl in _blocked) {
				if (i == count)
					break;
				switch (bl.Action) {
					case KeyAction.SysKeyDown:
					case KeyAction.KeyDown:
						s.Keyboard.KeyDown((VirtualKeyCode)bl.Key);
						break;
					case KeyAction.KeyUp:
					case KeyAction.SysKeyUp:
						s.Keyboard.KeyUp((VirtualKeyCode)bl.Key);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}
		#endregion

		#region Public Commands
			#region Binds adding
				#region KeysBind
				public void AddBind(Keys[] keys, Keys[] keysToEmulate) {
					_bindList.Add(new BindInfo_Keys(keys, keysToEmulate, true));
				}
				public void AddBind(Keys[] keys, Keys[] keysToEmulate, bool block) {
					_bindList.Add(new BindInfo_Keys(keys, keysToEmulate, block));
				}
				public void AddBind(Keys[] keys, Keys[] keysToEmulate, KeyAction[] actionsToEmulate) {
					_bindList.Add(new BindInfo_Keys(keys, keysToEmulate, actionsToEmulate, true));
				}
				public void AddBind(Keys[] keys, Keys[] keysToEmulate, KeyAction[] actionsToEmulate, bool block) {
					_bindList.Add(new BindInfo_Keys(keys, keysToEmulate, actionsToEmulate, block));
				}
				#endregion
				#region CommandBind
				public void AddBind(Keys[] keys, string command, bool hideConsole) {
					_bindList.Add(new BindInfo_Command(keys, command, hideConsole, true));
				}
				public void AddBind(Keys[] keys, string command, bool hideConsole, bool block) {
					_bindList.Add(new BindInfo_Command(keys, command, hideConsole, block));
				}
				#endregion
				#region ProcedureBind
				public void AddBind(Keys[] keys, EventHandler bindHandler) {
					_bindList.Add(new BindInfo_Procedure(keys, bindHandler, true));
				}
				public void AddBind(Keys[] keys, EventHandler bindHandler, bool block) {
					_bindList.Add(new BindInfo_Procedure(keys, bindHandler, block));
				}
				#endregion
			public void AddBind(BindInfo bindInfo) { // Pre-initialized bind. Can be of any type.
				_bindList.Add(bindInfo);
			}
			#endregion

		#endregion
	}
	#endregion

	#region Logging
	static class LayoutWatcher {
		#region  DLL signatures
		// Сохранил полный путь для.
		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		private static extern IntPtr GetKeyboardLayout(int windowsThreadProcessID);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowThreadProcessId(IntPtr handleWindow, out int processID);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetForegroundWindow();
		#endregion

		#region Gettings
		/// <summary>
		/// Получить текущую раскладку
		/// </summary>
		/// <returns>Идентификационный номер активной раскладки</returns>
		public static int GetLayoutID() {
			IntPtr fWin = GetForegroundWindow();
			int a; int winThrProsID = GetWindowThreadProcessId(fWin, out a);
			IntPtr lOut = GetKeyboardLayout(winThrProsID);
			for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
				if (lOut == InputLanguage.InstalledInputLanguages[i].Handle)
					return InputLanguage.InstalledInputLanguages[i].Culture.KeyboardLayoutId;
			return 0;
		}
		#endregion
	}

	class LogMaker {
		private KeysConverter _converter;
		private bool _shift;
		private bool _alt;
		private bool _ctrl;

		public LogMaker() {
			_converter = new KeysConverter();
		}

		public string Make(Keys key, KeyAction action) {
			switch (key) {
				case Keys.Return:
					return "\n";
				case Keys.LShiftKey:
				case Keys.RShiftKey:
				case Keys.ShiftKey:
				case Keys.Shift:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						_shift = true;
					else
						_shift = false;
					break;
				case Keys.Alt:
				case Keys.LMenu:
				case Keys.RMenu:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						_alt = true;
					else
						_alt = false;
					break;
				case Keys.LControlKey:
				case Keys.RControlKey:
				case Keys.Control:
				case Keys.ControlKey:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						_ctrl = true;
					else
						_ctrl = false;
					break;
				case Keys.Escape:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "\n[Escape]\n";
					break;
				case Keys.Space:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return " ";
					return "";
				case Keys.Capital:
				case Keys.Prior:
				case Keys.Next:
				case Keys.End:
				case Keys.Home:
				case Keys.Left:
				case Keys.Up:
				case Keys.Right:
				case Keys.Down:
				case Keys.Select:
				case Keys.Print:
				case Keys.Execute:
				case Keys.Snapshot:
				case Keys.Insert:
				case Keys.Delete:
				case Keys.Help:
					if (action == KeyAction.KeyUp || action == KeyAction.SysKeyUp)
						return "";
					break;
				case Keys.D0:
				case Keys.D1:
				case Keys.D2:
				case Keys.D3:
				case Keys.D4:
				case Keys.D5:
				case Keys.D6:
				case Keys.D7:
				case Keys.D8:
				case Keys.D9:
				case Keys.A:
				case Keys.B:
				case Keys.C:
				case Keys.D:
				case Keys.E:
				case Keys.F:
				case Keys.G:
				case Keys.H:
				case Keys.I:
				case Keys.J:
				case Keys.K:
				case Keys.L:
				case Keys.M:
				case Keys.N:
				case Keys.O:
				case Keys.P:
				case Keys.Q:
				case Keys.R:
				case Keys.S:
				case Keys.T:
				case Keys.U:
				case Keys.V:
				case Keys.W:
				case Keys.X:
				case Keys.Y:
				case Keys.Z:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown) {
						if (!_shift)
							return _converter.ConvertToString(key).ToLower();
						return _converter.ConvertToString(key);
					}
					return "";
				case Keys.LWin:
					if (action == KeyAction.KeyUp || action == KeyAction.SysKeyUp)
						return "";
					break;
				case Keys.RWin:
					if (action == KeyAction.KeyUp || action == KeyAction.SysKeyUp)
						return "";
					break;
				case Keys.Apps:
					if (action == KeyAction.KeyUp || action == KeyAction.SysKeyUp)
						return "";
					break;
				case Keys.Sleep:
					if (action == KeyAction.KeyUp || action == KeyAction.SysKeyUp)
						return "";
					break;
				case Keys.NumPad0:
				case Keys.NumPad1:
				case Keys.NumPad2:
				case Keys.NumPad3:
				case Keys.NumPad4:
				case Keys.NumPad5:
				case Keys.NumPad6:
				case Keys.NumPad7:
				case Keys.NumPad8:
				case Keys.NumPad9:
					return key.ToString()[key.ToString().Length - 1].ToString();
				case Keys.Multiply:
				case Keys.Add:
				case Keys.Subtract:
				case Keys.Decimal:
				case Keys.Divide:
				case Keys.F1:
				case Keys.F2:
				case Keys.F3:
				case Keys.F4:
				case Keys.F5:
				case Keys.F6:
				case Keys.F7:
				case Keys.F8:
				case Keys.F9:
				case Keys.F10:
				case Keys.F11:
				case Keys.F12:
				case Keys.F13:
				case Keys.F14:
				case Keys.F15:
				case Keys.F16:
				case Keys.F17:
				case Keys.F18:
				case Keys.F19:
				case Keys.F20:
				case Keys.F21:
				case Keys.F22:
				case Keys.F23:
				case Keys.F24:
				case Keys.Separator:
				case Keys.NumLock:
				case Keys.Scroll:
				case Keys.BrowserBack:
				case Keys.BrowserForward:
				case Keys.BrowserRefresh:
				case Keys.BrowserStop:
				case Keys.BrowserSearch:
				case Keys.BrowserFavorites:
				case Keys.BrowserHome:
				case Keys.VolumeMute:
				case Keys.VolumeDown:
				case Keys.VolumeUp:
				case Keys.MediaNextTrack:
				case Keys.MediaPreviousTrack:
				case Keys.MediaStop:
				case Keys.MediaPlayPause:
				case Keys.LaunchMail:
				case Keys.SelectMedia:
				case Keys.LaunchApplication1:
				case Keys.LaunchApplication2:
					if (action == KeyAction.KeyUp || action == KeyAction.SysKeyUp)
						return "";
					break;
				case Keys.OemSemicolon:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return ";";
					return "";
				case Keys.Oemplus:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "=";
					return "";
				case Keys.Oemcomma:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return ",";
					return "";
				case Keys.OemMinus:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "-";
					return "";
				case Keys.OemPeriod:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return ".";
					return "";
				case Keys.OemQuestion:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "/";
					return "";
				case Keys.Oemtilde:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "`";
					return "";
				case Keys.OemOpenBrackets:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "\\[";
					return "";
				case Keys.OemCloseBrackets:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "\\]";
					return "";
				case Keys.OemQuotes:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "'";
					return "";
				case Keys.Oem8:
					break;
				case Keys.OemBackslash:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "\\\\";
					return "";
				case Keys.ProcessKey:
				case Keys.OemPipe:
				case Keys.Packet:
				case Keys.Attn:
				case Keys.Crsel:
				case Keys.Exsel:
				case Keys.EraseEof:
				case Keys.Play:
				case Keys.Zoom:
				case Keys.NoName:
				case Keys.Pa1:
				case Keys.OemClear:
				case Keys.Back:
					if (action == KeyAction.KeyUp || action == KeyAction.SysKeyUp)
						return "";
					break;
				default:
					if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
						return "[" + key + "]";
					return "[/" + key + "]";
			}
			if (action == KeyAction.KeyDown || action == KeyAction.SysKeyDown)
				return "[" + key + "]";
			return "[/" + key + "]";
		}

	}

	public class KeyLogger { //TODO: Layouts. There must be a simple way to know what letter should be used for each button!
		//TODO: Refactor it to smaller classes, make a virtual KeyLogger and then pull HardKeyLogger, RemoteKeyLogger, some else KeyLogger from it. Oh shit.
		#region Consts
		public const String DEFAULT_TEXT_PATH = "Log_text.txt";
		public const String DEFAULT_LOG_PATH = "Log.txt";
		public const int ACTIONS_TO_FLUSH = 10; // TODO: When finishing, replace with some bigger number. Made it small for testing purposes.
		#endregion

		#region Serving objects
		KeyHooker _hooker;
		StreamWriter _writerLog;
		StreamWriter _writerText;
		LogMaker _maker;
		#endregion

		#region parameters
		private string _logFilePath;
		private string _textFilePath;
		#endregion

		#region Structing
		public KeyLogger() {
			_logFilePath = DEFAULT_LOG_PATH;
			_textFilePath = DEFAULT_TEXT_PATH;

			Initialize();
		}
		public KeyLogger(bool startNow) {
			_logFilePath = DEFAULT_LOG_PATH;
			_textFilePath = DEFAULT_TEXT_PATH;

			if (startNow)
				Initialize();
		}

		public KeyLogger(string folderPath) {
			if (!Directory.Exists(folderPath))
				throw new Exception("Directory '" + folderPath + "' not found!");

			_logFilePath = folderPath + "\\" + DEFAULT_LOG_PATH;
			_textFilePath = folderPath + "\\" + DEFAULT_TEXT_PATH;
			Initialize();
		}
		public void Begin() {
			Initialize();
		}

		public KeyLogger(string logFilePath, string textFilePath) {
			if (!Directory.Exists(logFilePath.Remove(logFilePath.LastIndexOf("\\", StringComparison.Ordinal))))
				throw new Exception("Directory '" + logFilePath + "' not found!");
			if (!Directory.Exists(textFilePath.Remove(textFilePath.LastIndexOf("\\", StringComparison.Ordinal))))
				throw new Exception("Directory '" + textFilePath + "' not found!");

			_logFilePath = logFilePath;
			_textFilePath = textFilePath;
			Initialize();
		}

		private void Initialize() {
			_writerLog = new StreamWriter(new FileStream(_logFilePath, FileMode.Append), Encoding.Unicode) {
				AutoFlush = false
			};
			_writerText = new StreamWriter(new FileStream(_textFilePath, FileMode.Append), Encoding.Unicode) {
				AutoFlush = false
			};

			_maker = new LogMaker();
			_hooker = new KeyHooker(false);
			_hooker.OnKeyAction += Hooker_OnKeyAction;
			_actions = 0;
			_hooker.Hook();
		}
		#endregion

		#region Handling
		private int _actions;
		private void Hooker_OnKeyAction(IntPtr hookID, KeyActionArgs e) {
			_writerLog.WriteLine(((int)e.KeyCode) + ";" + e.KeyAction);

			string toWrite = _maker.Make(e.KeyCode, (KeyAction)e.KeyAction);
			if(!string.IsNullOrEmpty(toWrite))
				_writerText.Write(toWrite); ;

			_actions++;
			if (_actions == ACTIONS_TO_FLUSH) {
				_writerLog.Flush();
				_writerText.Flush();
				_actions = 0;
			}
		}
		#endregion
	}
	#endregion

}
