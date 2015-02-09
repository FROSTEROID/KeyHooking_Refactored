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

		FileKeyLogger _fileLogger;
		MailKeyLogger _mailLogger;
		#endregion

		#region Structing
		public Form1() {
		_converter = new KeysConverter();
		_simulator = new InputSimulator();
			InitializeComponent();
		}
		#endregion

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
		private void CB_makeFileLogger_Click(object sender, EventArgs e) {
			_fileLogger = new FileKeyLogger("");
		}
		private void CB_makeMailLogger_Click(object sender, EventArgs e) {
			_mailLogger = new MailKeyLogger(tb_serv.Text, Convert.ToInt32(nUD_port.Value), tb_from.Text, tb_pass.Text, tb_to.Text);
		}
		#endregion

		#region Binder demonstration UI and Handlers
		private void CB_keyBinder_Click(object sender, EventArgs e) {
			_binder = new KeyBinder();
			_binder.AddBind(new[] { Keys.Capital, Keys.P }, new[] { Keys.Up, Keys.Up}, new[] { KeyAction.KeyDown, KeyAction.KeyUp });
			_binder.AddBind(new[] { Keys.Capital, Keys.N }, new[] { Keys.Down, Keys.Down }, new[] { KeyAction.KeyDown, KeyAction.KeyUp });
			_binder.AddBind(new[] { Keys.Capital, Keys.B }, new[] { Keys.Left, Keys.Left }, new[] { KeyAction.KeyDown, KeyAction.KeyUp });
			_binder.AddBind(new[] { Keys.Capital, Keys.F }, new[] { Keys.Right, Keys.Right }, new[] { KeyAction.KeyDown, KeyAction.KeyUp });
		}
		#endregion

		#region ЭЭЭэкспериментыЫЫЫ
		private void CB_test_Click(object sender, EventArgs e) {
		//_hooker = new KeyHooker();
		//_hooker.OnKeyActionEx +=_hooker_OnKeyActionEx1;

		MessageBox.Show(@"By GetKeyState: " + KeyboardWatching.GetKeyState((int)Keys.Capital));
		MessageBox.Show(@"By GetKeysState: " + KeyboardWatching.GetKeysState()[20]);
		
		
		//Thread.Sleep(1000);
		//_simulator.Keyboard.TextEntry("ᵺ"); // The fucking possibility to enter any character. o_<

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



//button1.Text = "working..."; Application.DoEvents();

//			string[] str =  new string[1000];
//			Random a = new Random();
//			for(int j=0; j<1000; j++){
//			str[j] = "";
//			for(int i=500; i>0; i--)str[j]+=(char)a.Next(250);
//			}

//			lb_keyConv.Items.AddRange(str);

//			label4.Text = lb_keyConv.Items.Count.ToString();

//			button1.Text = "Ready!";
//			Application.DoEvents();