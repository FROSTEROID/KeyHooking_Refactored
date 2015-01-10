using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Keyboard {

	public delegate void KeyActionHandler(IntPtr hookID, KeyActionArgs e);
	public delegate bool KeyActionHandlerEx(IntPtr hookID, KeyActionArgs e);
	public struct KeyActionArgs {
		public  KeyActionArgs(int keyCode, int keyAction){KeyCode=keyCode;KeyAction=keyAction;}
		public int KeyCode;
		public int KeyAction;
	}

	public class KeyHooker {
		#region Constants
			#region keyActionCodes
			private const int WH_KEYBOARD_LL = 13; // Номер прерывания, как йа понимаю. А может быть, некий уровень/способ вмешательства в работу системы. Используется при назначении обработчика (Вызове SetWindowsHookEx).
			private const int WM_KEYDOWN = 0x0100;  // Число, обозначающее Событие вжатия кнопки
			private const int WM_KEYUP = 0x0101;// Число, обозначающее Событие отжатия кнопки
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
		/// <returns>Вроде, возвращает ИН прерывателя... Или прерывания. Хз ваще, надо экспериментировать или читать где-то.</returns>
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
		/// <param name="nCode">Некий код, который если нуль, то всё плохо</param>
		/// <param name="wParam">Действие над клавишей</param>
		/// <param name="lParam">Код клавиши</param>
		/// <returns></returns>
		private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam){
			int keyCode;
			int keyAction;
			
			if (nCode >= 0){
				keyCode = Marshal.ReadInt32(lParam);
				keyAction = (int)wParam;
			}else{
				return CallNextHookEx(_hookID, nCode, wParam, lParam);
			}

			if(OnKeyAction != null)
				OnKeyAction(_hookID, new KeyActionArgs(keyCode, keyAction));
			
			bool block = false;
			if(OnKeyActionEx != null)
				block = OnKeyActionEx(_hookID, new KeyActionArgs(keyCode, keyAction));

			if(block)
				return new IntPtr(1);
			return CallNextHookEx(_hookID, nCode, wParam, lParam); // Передаём управление следующему обработчику
		}

		/// <summary>
		/// Стреляет, при попадании евента в Hooker. Позволяет реагировать, но не блокировать евент.
		/// В качестве определителя источника передаётся ID-указатель перехватывания. Можете составлять себе словари для них, если очень хочется несколько хуков.
		/// </summary>
		public event KeyActionHandler OnKeyAction;
		/// <summary>
		/// А этот позволяет отреагировать и указать, должен ли Hooker заблокировать дальнейшую обработку евента системой
		/// Верните 1(true), чтобы заблокировать евент. 0(false) - пропустить далее.
		/// Нельзя заблокировать Ctrl+Alt+Del.
		/// В качестве определителя источника передаётся ID-указатель перехватывания. Можете составлять себе словари для них, если очень хочется несколько хуков.
		/// </summary>
		public event KeyActionHandlerEx OnKeyActionEx;
		
		#endregion

		#region Structing
		public KeyHooker() {
			_hookID = SetHook(HookCallback);
		}
		#endregion
	}
}
