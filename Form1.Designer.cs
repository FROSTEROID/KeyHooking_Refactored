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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// CB_makeHooker
			// 
			this.CB_makeHooker.Location = new System.Drawing.Point(209, 42);
			this.CB_makeHooker.Name = "CB_makeHooker";
			this.CB_makeHooker.Size = new System.Drawing.Size(105, 23);
			this.CB_makeHooker.TabIndex = 0;
			this.CB_makeHooker.Text = "Make hooker";
			this.CB_makeHooker.UseVisualStyleBackColor = true;
			this.CB_makeHooker.Click += new System.EventHandler(this.CB_makeHooker_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(320, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 303);
			this.listBox1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 326);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.CB_makeHooker);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CB_makeHooker;
		private System.Windows.Forms.ListBox listBox1;
	}
}

