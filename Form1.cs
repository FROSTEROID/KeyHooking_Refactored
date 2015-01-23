using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using KeyboardExtending;

namespace KeyHooking_Refactored {
	public partial class Form1 : Form {

		#region Serving objects
		KeyHooker _hooker;
		KeysConverter _converter;
		KeyLogger _logger;
		#endregion

		public Form1() {
		_converter = new KeysConverter();
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

		#region ЭЭЭэкспериментыЫЫЫ
		private void CB_test_Click(object sender, EventArgs e) {
		
		Thread thr = new Thread(Ther);
		thr.Start();

		KeysConverter a = new KeysConverter();
		MessageBox.Show(Keys.D5.ToString());

		/*
			StreamWriter s = new StreamWriter(new FileStream("test.txt", FileMode.OpenOrCreate), Encoding.Unicode);
			s.Write("Azaz!");
			s.Flush();
			s.WriteLine("Azaz!");
			s.Flush();
			s.Close();
		*/
		}

		void Ther() {
			Thread.Sleep(100);
			SendKeys.SendWait("\n");
		}
		#endregion
	}
}
