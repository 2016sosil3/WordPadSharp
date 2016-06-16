namespace WordPadSharp
{
	partial class FormMail
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMail));
			this.label_ID = new System.Windows.Forms.Label();
			this.label_PW = new System.Windows.Forms.Label();
			this.label_Receiver = new System.Windows.Forms.Label();
			this.label_Subject = new System.Windows.Forms.Label();
			this.label_Body = new System.Windows.Forms.Label();
			this.textBox_Body = new System.Windows.Forms.TextBox();
			this.textBox_ID = new System.Windows.Forms.TextBox();
			this.textBox_PW = new System.Windows.Forms.TextBox();
			this.textBox_Receiver = new System.Windows.Forms.TextBox();
			this.textBox_Subject = new System.Windows.Forms.TextBox();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_OK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label_ID
			// 
			this.label_ID.AutoSize = true;
			this.label_ID.Location = new System.Drawing.Point(12, 9);
			this.label_ID.Name = "label_ID";
			this.label_ID.Size = new System.Drawing.Size(78, 15);
			this.label_ID.TabIndex = 0;
			this.label_ID.Text = "보내는 사람 :";
			// 
			// label_PW
			// 
			this.label_PW.AutoSize = true;
			this.label_PW.Location = new System.Drawing.Point(12, 42);
			this.label_PW.Name = "label_PW";
			this.label_PW.Size = new System.Drawing.Size(62, 15);
			this.label_PW.TabIndex = 1;
			this.label_PW.Text = "비밀번호 :";
			// 
			// label_Receiver
			// 
			this.label_Receiver.AutoSize = true;
			this.label_Receiver.Location = new System.Drawing.Point(12, 75);
			this.label_Receiver.Name = "label_Receiver";
			this.label_Receiver.Size = new System.Drawing.Size(66, 15);
			this.label_Receiver.TabIndex = 2;
			this.label_Receiver.Text = "받는 사람 :";
			// 
			// label_Subject
			// 
			this.label_Subject.AutoSize = true;
			this.label_Subject.Location = new System.Drawing.Point(12, 108);
			this.label_Subject.Name = "label_Subject";
			this.label_Subject.Size = new System.Drawing.Size(38, 15);
			this.label_Subject.TabIndex = 3;
			this.label_Subject.Text = "제목 :";
			// 
			// label_Body
			// 
			this.label_Body.AutoSize = true;
			this.label_Body.Location = new System.Drawing.Point(12, 141);
			this.label_Body.Name = "label_Body";
			this.label_Body.Size = new System.Drawing.Size(38, 15);
			this.label_Body.TabIndex = 4;
			this.label_Body.Text = "내용 :";
			// 
			// textBox_Body
			// 
			this.textBox_Body.Location = new System.Drawing.Point(15, 161);
			this.textBox_Body.Multiline = true;
			this.textBox_Body.Name = "textBox_Body";
			this.textBox_Body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_Body.Size = new System.Drawing.Size(757, 359);
			this.textBox_Body.TabIndex = 5;
			// 
			// textBox_ID
			// 
			this.textBox_ID.Location = new System.Drawing.Point(96, 5);
			this.textBox_ID.Name = "textBox_ID";
			this.textBox_ID.Size = new System.Drawing.Size(676, 23);
			this.textBox_ID.TabIndex = 6;
			// 
			// textBox_PW
			// 
			this.textBox_PW.Location = new System.Drawing.Point(96, 38);
			this.textBox_PW.Name = "textBox_PW";
			this.textBox_PW.PasswordChar = '*';
			this.textBox_PW.Size = new System.Drawing.Size(676, 23);
			this.textBox_PW.TabIndex = 7;
			// 
			// textBox_Receiver
			// 
			this.textBox_Receiver.Location = new System.Drawing.Point(96, 71);
			this.textBox_Receiver.Name = "textBox_Receiver";
			this.textBox_Receiver.Size = new System.Drawing.Size(676, 23);
			this.textBox_Receiver.TabIndex = 8;
			// 
			// textBox_Subject
			// 
			this.textBox_Subject.Location = new System.Drawing.Point(96, 104);
			this.textBox_Subject.Name = "textBox_Subject";
			this.textBox_Subject.Size = new System.Drawing.Size(676, 23);
			this.textBox_Subject.TabIndex = 9;
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(697, 526);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 10;
			this.button_Cancel.Text = "취소(&C)";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// button_OK
			// 
			this.button_OK.Location = new System.Drawing.Point(616, 526);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 11;
			this.button_OK.Text = "확인(&O)";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
			// 
			// FormMail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.textBox_Subject);
			this.Controls.Add(this.textBox_Receiver);
			this.Controls.Add(this.textBox_PW);
			this.Controls.Add(this.textBox_ID);
			this.Controls.Add(this.textBox_Body);
			this.Controls.Add(this.label_Body);
			this.Controls.Add(this.label_Subject);
			this.Controls.Add(this.label_Receiver);
			this.Controls.Add(this.label_PW);
			this.Controls.Add(this.label_ID);
			this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormMail";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "이메일 보내기";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_ID;
		private System.Windows.Forms.Label label_PW;
		private System.Windows.Forms.Label label_Receiver;
		private System.Windows.Forms.Label label_Subject;
		private System.Windows.Forms.Label label_Body;
		private System.Windows.Forms.TextBox textBox_Body;
		private System.Windows.Forms.TextBox textBox_ID;
		private System.Windows.Forms.TextBox textBox_PW;
		private System.Windows.Forms.TextBox textBox_Receiver;
		private System.Windows.Forms.TextBox textBox_Subject;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_OK;
	}
}