namespace WordPadSharp
{
	partial class FormSearch
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearch));
			this.label_Search = new System.Windows.Forms.Label();
			this.textBox_Search = new System.Windows.Forms.TextBox();
			this.button_Next = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.checkBox_Word = new System.Windows.Forms.CheckBox();
			this.checkBox_Case = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label_Search
			// 
			this.label_Search.AutoSize = true;
			this.label_Search.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label_Search.Location = new System.Drawing.Point(12, 9);
			this.label_Search.Name = "label_Search";
			this.label_Search.Size = new System.Drawing.Size(83, 15);
			this.label_Search.TabIndex = 0;
			this.label_Search.Text = "찾을 내용(&N) :";
			// 
			// textBox_Search
			// 
			this.textBox_Search.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBox_Search.Location = new System.Drawing.Point(101, 6);
			this.textBox_Search.Name = "textBox_Search";
			this.textBox_Search.Size = new System.Drawing.Size(283, 21);
			this.textBox_Search.TabIndex = 1;
			// 
			// button_Next
			// 
			this.button_Next.Location = new System.Drawing.Point(390, 5);
			this.button_Next.Name = "button_Next";
			this.button_Next.Size = new System.Drawing.Size(82, 23);
			this.button_Next.TabIndex = 2;
			this.button_Next.Text = "다음 찾기(&F)";
			this.button_Next.UseVisualStyleBackColor = true;
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(390, 34);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(82, 23);
			this.button_Cancel.TabIndex = 3;
			this.button_Cancel.Text = "취소";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// checkBox_Word
			// 
			this.checkBox_Word.AutoSize = true;
			this.checkBox_Word.Location = new System.Drawing.Point(12, 63);
			this.checkBox_Word.Name = "checkBox_Word";
			this.checkBox_Word.Size = new System.Drawing.Size(109, 19);
			this.checkBox_Word.TabIndex = 4;
			this.checkBox_Word.Text = "단어 단위로(&W)";
			this.checkBox_Word.UseVisualStyleBackColor = true;
			// 
			// checkBox_Case
			// 
			this.checkBox_Case.AutoSize = true;
			this.checkBox_Case.Location = new System.Drawing.Point(12, 88);
			this.checkBox_Case.Name = "checkBox_Case";
			this.checkBox_Case.Size = new System.Drawing.Size(123, 19);
			this.checkBox_Case.TabIndex = 5;
			this.checkBox_Case.Text = "대/소문자 구분(&C)";
			this.checkBox_Case.UseVisualStyleBackColor = true;
			// 
			// FormSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(484, 121);
			this.Controls.Add(this.checkBox_Case);
			this.Controls.Add(this.checkBox_Word);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_Next);
			this.Controls.Add(this.textBox_Search);
			this.Controls.Add(this.label_Search);
			this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormSearch";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "찾기";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_Search;
		private System.Windows.Forms.TextBox textBox_Search;
		private System.Windows.Forms.Button button_Next;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.CheckBox checkBox_Word;
		private System.Windows.Forms.CheckBox checkBox_Case;
	}
}