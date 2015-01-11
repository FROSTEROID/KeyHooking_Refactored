using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Keyboard;

namespace KeyHooking_Refactored {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		KeyHooker _hooker;

		private void CB_makeHooker_Click(object sender, EventArgs e){
			_hooker = new KeyHooker();
			_hooker.OnKeyAction += Hooker_OnKeyAction;
			_hooker.OnKeyActionEx += _hooker_OnKeyActionEx;
		}

		private void Hooker_OnKeyAction(IntPtr hookID, KeyActionArgs e){
				lb_action.Items.Insert(0, e.KeyAction);
				lb_code.Items.Insert(0, (int)e.KeyCode);
				lb_key.Items.Insert(0, e.KeyCode);
		}
		private bool _hooker_OnKeyActionEx(IntPtr hookID, KeyActionArgs e){
			return cb_blockAll.Checked;
		}

	}
}
