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
			this.lb_key = new System.Windows.Forms.ListBox();
			this.cb_blockAll = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
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
			this.lb_action.Size = new System.Drawing.Size(73, 277);
			this.lb_action.TabIndex = 1;
			// 
			// lb_code
			// 
			this.lb_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lb_code.FormattingEnabled = true;
			this.lb_code.Location = new System.Drawing.Point(91, 67);
			this.lb_code.Name = "lb_code";
			this.lb_code.Size = new System.Drawing.Size(73, 277);
			this.lb_code.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "ActionCode";
			// 
			// lb_key
			// 
			this.lb_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lb_key.FormattingEnabled = true;
			this.lb_key.Location = new System.Drawing.Point(170, 67);
			this.lb_key.Name = "lb_key";
			this.lb_key.Size = new System.Drawing.Size(73, 277);
			this.lb_key.TabIndex = 4;
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
			this.label2.Location = new System.Drawing.Point(88, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "KeyCode";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(167, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Key";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(254, 350);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cb_blockAll);
			this.Controls.Add(this.lb_key);
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
		private System.Windows.Forms.ListBox lb_key;
		private System.Windows.Forms.CheckBox cb_blockAll;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

