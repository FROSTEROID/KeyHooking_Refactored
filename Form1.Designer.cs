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
			this.CB_makeLogger = new System.Windows.Forms.Button();
			this.CB_test = new System.Windows.Forms.Button();
			this.lb_keyConv = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// CB_makeHooker
			// 
			this.CB_makeHooker.Location = new System.Drawing.Point(12, 12);
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
			this.lb_action.Location = new System.Drawing.Point(12, 67);
			this.lb_action.Name = "lb_action";
			this.lb_action.Size = new System.Drawing.Size(100, 420);
			this.lb_action.TabIndex = 1;
			// 
			// lb_code
			// 
			this.lb_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lb_code.FormattingEnabled = true;
			this.lb_code.Location = new System.Drawing.Point(118, 67);
			this.lb_code.Name = "lb_code";
			this.lb_code.Size = new System.Drawing.Size(100, 420);
			this.lb_code.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 51);
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
			this.lb_keyStr.Location = new System.Drawing.Point(224, 67);
			this.lb_keyStr.Name = "lb_keyStr";
			this.lb_keyStr.Size = new System.Drawing.Size(100, 420);
			this.lb_keyStr.TabIndex = 4;
			// 
			// cb_blockAll
			// 
			this.cb_blockAll.AutoSize = true;
			this.cb_blockAll.Location = new System.Drawing.Point(170, 16);
			this.cb_blockAll.Name = "cb_blockAll";
			this.cb_blockAll.Size = new System.Drawing.Size(71, 17);
			this.cb_blockAll.TabIndex = 5;
			this.cb_blockAll.Text = "blockALL";
			this.cb_blockAll.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(115, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "KeyCode";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(221, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "KeyCodeName";
			// 
			// CB_makeLogger
			// 
			this.CB_makeLogger.Location = new System.Drawing.Point(459, 10);
			this.CB_makeLogger.Name = "CB_makeLogger";
			this.CB_makeLogger.Size = new System.Drawing.Size(152, 43);
			this.CB_makeLogger.TabIndex = 8;
			this.CB_makeLogger.Text = "Make Logger";
			this.CB_makeLogger.UseVisualStyleBackColor = true;
			this.CB_makeLogger.Click += new System.EventHandler(this.CB_makeLogger_Click);
			// 
			// CB_test
			// 
			this.CB_test.Location = new System.Drawing.Point(536, 315);
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
			this.lb_keyConv.Location = new System.Drawing.Point(330, 67);
			this.lb_keyConv.Name = "lb_keyConv";
			this.lb_keyConv.Size = new System.Drawing.Size(100, 420);
			this.lb_keyConv.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(327, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "KeyConverted";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(623, 504);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lb_keyConv);
			this.Controls.Add(this.CB_test);
			this.Controls.Add(this.CB_makeLogger);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cb_blockAll);
			this.Controls.Add(this.lb_keyStr);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lb_code);
			this.Controls.Add(this.lb_action);
			this.Controls.Add(this.CB_makeHooker);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.Button CB_makeLogger;
		private System.Windows.Forms.Button CB_test;
		private System.Windows.Forms.ListBox lb_keyConv;
		private System.Windows.Forms.Label label4;
	}
}

