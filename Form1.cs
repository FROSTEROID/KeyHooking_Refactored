using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Keyboard;

namespace KeyHooking_Refactored {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		KeyHooker _hooker;

		private void CB_makeHooker_Click(object sender, EventArgs e) {
			_hooker = new KeyHooker();
			_hooker.OnKeyAction +=_hooker_OnKeyAction;
		}

		private void _hooker_OnKeyAction(IntPtr hookID, KeyActionArgs e) {
				listBox1.Items.Add(e.KeyAction);
		}

	}
}
