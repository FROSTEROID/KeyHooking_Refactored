namespace KeyHooking_Refactored {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.CB_makeHooker = new System.Windows.Forms.Button();
			this.lb_action = new System.Windows.Forms.ListBox();
			this.lb_code = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lb_keyStr = new System.Windows.Forms.ListBox();
			this.cb_blockAll = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.CB_test = new System.Windows.Forms.Button();
			this.lb_keyConv = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.CB_keyBinder = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tab_hooking = new System.Windows.Forms.TabPage();
			this.tab_logging = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tb_to = new System.Windows.Forms.TextBox();
			this.tb_pass = new System.Windows.Forms.TextBox();
			this.tb_from = new System.Windows.Forms.TextBox();
			this.tb_serv = new System.Windows.Forms.TextBox();
			this.CB_makeMailLogger = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.CB_makeFileLogger = new System.Windows.Forms.Button();
			this.tab_binding = new System.Windows.Forms.TabPage();
			this.nUD_port = new System.Windows.Forms.NumericUpDown();
			this.tabControl1.SuspendLayout();
			this.tab_hooking.SuspendLayout();
			this.tab_logging.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tab_binding.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD_port)).BeginInit();
			this.SuspendLayout();
			// 
			// CB_makeHooker
			// 
			this.CB_makeHooker.Location = new System.Drawing.Point(6, 6);
			this.CB_makeHooker.Name = "CB_makeHooker";
			this.CB_makeHooker.Size = new System.Drawing.Size(152, 23);
			this.CB_makeHooker.TabIndex = 0;
			this.CB_makeHooker.Text = "Make hooker";
			this.CB_makeHooker.UseVisualStyleBackColor = true;
			this.CB_makeHooker.Click += new System.EventHandler(this.CB_makeHooker_Click);
			// 
			// lb_action
			// 
			this.lb_action.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lb_action.FormattingEnabled = true;
			this.lb_action.Location = new System.Drawing.Point(6, 61);
			this.lb_action.Name = "lb_action";
			this.lb_action.Size = new System.Drawing.Size(100, 498);
			this.lb_action.TabIndex = 1;
			// 
			// lb_code
			// 
			this.lb_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lb_code.FormattingEnabled = true;
			this.lb_code.Location = new System.Drawing.Point(112, 61);
			this.lb_code.Name = "lb_code";
			this.lb_code.Size = new System.Drawing.Size(100, 498);
			this.lb_code.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "ActionCode";
			// 
			// lb_keyStr
			// 
			this.lb_keyStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lb_keyStr.FormattingEnabled = true;
			this.lb_keyStr.Location = new System.Drawing.Point(218, 61);
			this.lb_keyStr.Name = "lb_keyStr";
			this.lb_keyStr.Size = new System.Drawing.Size(100, 498);
			this.lb_keyStr.TabIndex = 4;
			// 
			// cb_blockAll
			// 
			this.cb_blockAll.AutoSize = true;
			this.cb_blockAll.Location = new System.Drawing.Point(164, 10);
			this.cb_blockAll.Name = "cb_blockAll";
			this.cb_blockAll.Size = new System.Drawing.Size(71, 17);
			this.cb_blockAll.TabIndex = 5;
			this.cb_blockAll.Text = "blockALL";
			this.cb_blockAll.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(109, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "KeyCode";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(215, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "KeyCodeName";
			// 
			// CB_test
			// 
			this.CB_test.Location = new System.Drawing.Point(414, 5);
			this.CB_test.Name = "CB_test";
			this.CB_test.Size = new System.Drawing.Size(75, 23);
			this.CB_test.TabIndex = 9;
			this.CB_test.Text = "test";
			this.CB_test.UseVisualStyleBackColor = true;
			this.CB_test.Click += new System.EventHandler(this.CB_test_Click);
			// 
			// lb_keyConv
			// 
			this.lb_keyConv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lb_keyConv.FormattingEnabled = true;
			this.lb_keyConv.Location = new System.Drawing.Point(324, 61);
			this.lb_keyConv.Name = "lb_keyConv";
			this.lb_keyConv.Size = new System.Drawing.Size(100, 498);
			this.lb_keyConv.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(321, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "KeyConverted";
			// 
			// CB_keyBinder
			// 
			this.CB_keyBinder.Location = new System.Drawing.Point(181, 154);
			this.CB_keyBinder.Name = "CB_keyBinder";
			this.CB_keyBinder.Size = new System.Drawing.Size(118, 43);
			this.CB_keyBinder.TabIndex = 13;
			this.CB_keyBinder.Text = "KeyBinder";
			this.CB_keyBinder.UseVisualStyleBackColor = true;
			this.CB_keyBinder.Click += new System.EventHandler(this.CB_keyBinder_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tab_hooking);
			this.tabControl1.Controls.Add(this.tab_logging);
			this.tabControl1.Controls.Add(this.tab_binding);
			this.tabControl1.Location = new System.Drawing.Point(12, 34);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(644, 594);
			this.tabControl1.TabIndex = 15;
			// 
			// tab_hooking
			// 
			this.tab_hooking.Controls.Add(this.CB_makeHooker);
			this.tab_hooking.Controls.Add(this.label4);
			this.tab_hooking.Controls.Add(this.label2);
			this.tab_hooking.Controls.Add(this.lb_action);
			this.tab_hooking.Controls.Add(this.cb_blockAll);
			this.tab_hooking.Controls.Add(this.lb_keyConv);
			this.tab_hooking.Controls.Add(this.label3);
			this.tab_hooking.Controls.Add(this.lb_code);
			this.tab_hooking.Controls.Add(this.lb_keyStr);
			this.tab_hooking.Controls.Add(this.label1);
			this.tab_hooking.Location = new System.Drawing.Point(4, 22);
			this.tab_hooking.Name = "tab_hooking";
			this.tab_hooking.Padding = new System.Windows.Forms.Padding(3);
			this.tab_hooking.Size = new System.Drawing.Size(636, 568);
			this.tab_hooking.TabIndex = 0;
			this.tab_hooking.Text = "Hooking";
			this.tab_hooking.UseVisualStyleBackColor = true;
			// 
			// tab_logging
			// 
			this.tab_logging.Controls.Add(this.groupBox2);
			this.tab_logging.Controls.Add(this.groupBox1);
			this.tab_logging.Location = new System.Drawing.Point(4, 22);
			this.tab_logging.Name = "tab_logging";
			this.tab_logging.Padding = new System.Windows.Forms.Padding(3);
			this.tab_logging.Size = new System.Drawing.Size(636, 568);
			this.tab_logging.TabIndex = 1;
			this.tab_logging.Text = "Logging";
			this.tab_logging.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.nUD_port);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.tb_to);
			this.groupBox2.Controls.Add(this.tb_pass);
			this.groupBox2.Controls.Add(this.tb_from);
			this.groupBox2.Controls.Add(this.tb_serv);
			this.groupBox2.Controls.Add(this.CB_makeMailLogger);
			this.groupBox2.Location = new System.Drawing.Point(3, 143);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(624, 117);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Mail";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(429, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(19, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "to:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(221, 42);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "pass:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(221, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "from:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 42);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(28, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "port:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "server:";
			// 
			// tb_to
			// 
			this.tb_to.Location = new System.Drawing.Point(454, 13);
			this.tb_to.Name = "tb_to";
			this.tb_to.Size = new System.Drawing.Size(164, 20);
			this.tb_to.TabIndex = 15;
			// 
			// tb_pass
			// 
			this.tb_pass.Location = new System.Drawing.Point(257, 39);
			this.tb_pass.Name = "tb_pass";
			this.tb_pass.Size = new System.Drawing.Size(164, 20);
			this.tb_pass.TabIndex = 14;
			// 
			// tb_from
			// 
			this.tb_from.Location = new System.Drawing.Point(257, 13);
			this.tb_from.Name = "tb_from";
			this.tb_from.Size = new System.Drawing.Size(164, 20);
			this.tb_from.TabIndex = 13;
			// 
			// tb_serv
			// 
			this.tb_serv.Location = new System.Drawing.Point(51, 13);
			this.tb_serv.Name = "tb_serv";
			this.tb_serv.Size = new System.Drawing.Size(164, 20);
			this.tb_serv.TabIndex = 11;
			// 
			// CB_makeMailLogger
			// 
			this.CB_makeMailLogger.Location = new System.Drawing.Point(216, 65);
			this.CB_makeMailLogger.Name = "CB_makeMailLogger";
			this.CB_makeMailLogger.Size = new System.Drawing.Size(152, 46);
			this.CB_makeMailLogger.TabIndex = 9;
			this.CB_makeMailLogger.Text = "Make MailLogger";
			this.CB_makeMailLogger.UseVisualStyleBackColor = true;
			this.CB_makeMailLogger.Click += new System.EventHandler(this.CB_makeMailLogger_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.CB_makeFileLogger);
			this.groupBox1.Location = new System.Drawing.Point(6, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(624, 97);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "file";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(612, 20);
			this.textBox1.TabIndex = 9;
			// 
			// CB_makeFileLogger
			// 
			this.CB_makeFileLogger.Location = new System.Drawing.Point(216, 45);
			this.CB_makeFileLogger.Name = "CB_makeFileLogger";
			this.CB_makeFileLogger.Size = new System.Drawing.Size(152, 46);
			this.CB_makeFileLogger.TabIndex = 8;
			this.CB_makeFileLogger.Text = "Make FileLogger";
			this.CB_makeFileLogger.UseVisualStyleBackColor = true;
			this.CB_makeFileLogger.Click += new System.EventHandler(this.CB_makeFileLogger_Click);
			// 
			// tab_binding
			// 
			this.tab_binding.Controls.Add(this.CB_keyBinder);
			this.tab_binding.Location = new System.Drawing.Point(4, 22);
			this.tab_binding.Name = "tab_binding";
			this.tab_binding.Size = new System.Drawing.Size(636, 568);
			this.tab_binding.TabIndex = 2;
			this.tab_binding.Text = "Binding";
			this.tab_binding.UseVisualStyleBackColor = true;
			// 
			// nUD_port
			// 
			this.nUD_port.Location = new System.Drawing.Point(51, 39);
			this.nUD_port.Name = "nUD_port";
			this.nUD_port.Size = new System.Drawing.Size(164, 20);
			this.nUD_port.TabIndex = 21;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 640);
			this.Controls.Add(this.CB_test);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "KeyboardExtending";
			this.tabControl1.ResumeLayout(false);
			this.tab_hooking.ResumeLayout(false);
			this.tab_hooking.PerformLayout();
			this.tab_logging.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tab_binding.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nUD_port)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CB_makeHooker;
		private System.Windows.Forms.ListBox lb_action;
		private System.Windows.Forms.ListBox lb_code;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lb_keyStr;
		private System.Windows.Forms.CheckBox cb_blockAll;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button CB_test;
		private System.Windows.Forms.ListBox lb_keyConv;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button CB_keyBinder;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tab_hooking;
		private System.Windows.Forms.TabPage tab_logging;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tb_to;
		private System.Windows.Forms.TextBox tb_pass;
		private System.Windows.Forms.TextBox tb_from;
		private System.Windows.Forms.TextBox tb_serv;
		private System.Windows.Forms.Button CB_makeMailLogger;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button CB_makeFileLogger;
		private System.Windows.Forms.TabPage tab_binding;
		private System.Windows.Forms.NumericUpDown nUD_port;
	}
}

