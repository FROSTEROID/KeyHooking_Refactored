using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using KeyboardExtending;

namespace KeyHooking_Refactored {
	public partial class Form1 : Form {

		#region Serving objects
		KeyHooker _hooker;
		KeysConverter _converter;
		IInputSimulator _simulator;
		KeyBinder _binder;

		KeyLogger _logger;
		#endregion

		public Form1() {
		_converter = new KeysConverter();
		_simulator = new InputSimulator();
			InitializeComponent();
		}

		#region Hooker demostration UI and Handlers
		private void CB_makeHooker_Click(object sender, EventArgs e){
			_hooker = new KeyHooker();
			_hooker.OnKeyAction += Hooker_OnKeyAction;
			_hooker.OnKeyActionEx += _hooker_OnKeyActionEx;
		}

		private void Hooker_OnKeyAction(IntPtr hookID, KeyActionArgs e){
				lb_action.Items.Insert(0, e.KeyAction);
				lb_code.Items.Insert(0, (int)e.KeyCode);
				lb_keyStr.Items.Insert(0, e.KeyCode.ToString());
				lb_keyConv.Items.Insert(0, _converter.ConvertToString(e.KeyCode));
		}
		private bool _hooker_OnKeyActionEx(IntPtr hookID, KeyActionArgs e){
			return cb_blockAll.Checked;
		}
		#endregion

		#region Logger demostration UI and Handlers
		private void CB_makeLogger_Click(object sender, EventArgs e) {
			_logger = new KeyLogger();
		}
		#endregion

		private void CB_keyBinder_Click(object sender, EventArgs e) {
			_binder = new KeyBinder();
			_binder.AddBind(new[] { Keys.Capital, Keys.P }, new[] { Keys.Up, Keys.Up}, new[] { KeyAction.KeyDown, KeyAction.KeyUp });
			_binder.AddBind(new[] { Keys.Capital, Keys.N }, new[] { Keys.Down, Keys.Down }, new[] { KeyAction.KeyDown, KeyAction.KeyUp });
			_binder.AddBind(new[] { Keys.Capital, Keys.B }, new[] { Keys.Left, Keys.Left }, new[] { KeyAction.KeyDown, KeyAction.KeyUp });
			_binder.AddBind(new[] { Keys.Capital, Keys.F }, new[] { Keys.Right, Keys.Right }, new[] { KeyAction.KeyDown, KeyAction.KeyUp });
		}

		#region ЭЭЭэкспериментыЫЫЫ
		private void CB_test_Click(object sender, EventArgs e) {
		_hooker = new KeyHooker();
		_hooker.OnKeyActionEx +=_hooker_OnKeyActionEx1;

		//IInputSimulator simulator = new InputSimulator();
		//simulator.Keyboard.KeyDown((VirtualKeyCode)Keys.LWin);
		//simulator.Keyboard.KeyUp((VirtualKeyCode)Keys.LWin);
		//simulator.Keyboard.KeyPress((VirtualKeyCode)Keys.LWin);
		}
		private bool _hooker_OnKeyActionEx1(IntPtr hookID, KeyActionArgs e) {
			if(e.KeyCode == Keys.OemSemicolon && (KeyAction)e.KeyAction == KeyAction.KeyDown)
				_simulator.Keyboard.KeyDown((VirtualKeyCode)Keys.Enter);
			return false;
		}
		#endregion

	}
}
