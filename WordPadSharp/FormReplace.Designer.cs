namespace WordPadSharp
{
	partial class FormReplace
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReplace));
			this.checkBox_Case = new System.Windows.Forms.CheckBox();
			this.checkBox_Word = new System.Windows.Forms.CheckBox();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_Next = new System.Windows.Forms.Button();
			this.textBox_Search = new System.Windows.Forms.TextBox();
			this.label_Search = new System.Windows.Forms.Label();
			this.button_Replace = new System.Windows.Forms.Button();
			this.textBox_Replace = new System.Windows.Forms.TextBox();
			this.label_Replace = new System.Windows.Forms.Label();
			this.button_ReplaceAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBox_Case
			// 
			this.checkBox_Case.AutoSize = true;
			this.checkBox_Case.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.checkBox_Case.Location = new System.Drawing.Point(13, 143);
			this.checkBox_Case.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkBox_Case.Name = "checkBox_Case";
			this.checkBox_Case.Size = new System.Drawing.Size(123, 19);
			this.checkBox_Case.TabIndex = 11;
			this.checkBox_Case.Text = "대/소문자 구분(&C)";
			this.checkBox_Case.UseVisualStyleBackColor = true;
			// 
			// checkBox_Word
			// 
			this.checkBox_Word.AutoSize = true;
			this.checkBox_Word.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.checkBox_Word.Location = new System.Drawing.Point(13, 118);
			this.checkBox_Word.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkBox_Word.Name = "checkBox_Word";
			this.checkBox_Word.Size = new System.Drawing.Size(109, 19);
			this.checkBox_Word.TabIndex = 10;
			this.checkBox_Word.Text = "단어 단위로(&W)";
			this.checkBox_Word.UseVisualStyleBackColor = true;
			// 
			// button_Cancel
			// 
			this.button_Cancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.button_Cancel.Location = new System.Drawing.Point(376, 90);
			this.button_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(96, 22);
			this.button_Cancel.TabIndex = 9;
			this.button_Cancel.Text = "취소";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// button_Next
			// 
			this.button_Next.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.button_Next.Location = new System.Drawing.Point(376, 5);
			this.button_Next.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.button_Next.Name = "button_Next";
			this.button_Next.Size = new System.Drawing.Size(96, 22);
			this.button_Next.TabIndex = 8;
			this.button_Next.Text = "다음 찾기(&F)";
			this.button_Next.UseVisualStyleBackColor = true;
			this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
			// 
			// textBox_Search
			// 
			this.textBox_Search.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBox_Search.Location = new System.Drawing.Point(102, 5);
			this.textBox_Search.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBox_Search.Name = "textBox_Search";
			this.textBox_Search.Size = new System.Drawing.Size(266, 23);
			this.textBox_Search.TabIndex = 7;
			// 
			// label_Search
			// 
			this.label_Search.AutoSize = true;
			this.label_Search.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label_Search.Location = new System.Drawing.Point(13, 9);
			this.label_Search.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_Search.Name = "label_Search";
			this.label_Search.Size = new System.Drawing.Size(83, 15);
			this.label_Search.TabIndex = 6;
			this.label_Search.Text = "찾을 내용(&N) :";
			// 
			// button_Replace
			// 
			this.button_Replace.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.button_Replace.Location = new System.Drawing.Point(376, 34);
			this.button_Replace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.button_Replace.Name = "button_Replace";
			this.button_Replace.Size = new System.Drawing.Size(96, 22);
			this.button_Replace.TabIndex = 14;
			this.button_Replace.Text = "바꾸기(&R)";
			this.button_Replace.UseVisualStyleBackColor = true;
			this.button_Replace.Click += new System.EventHandler(this.button_Replace_Click);
			// 
			// textBox_Replace
			// 
			this.textBox_Replace.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBox_Replace.Location = new System.Drawing.Point(102, 34);
			this.textBox_Replace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBox_Replace.Name = "textBox_Replace";
			this.textBox_Replace.Size = new System.Drawing.Size(266, 23);
			this.textBox_Replace.TabIndex = 13;
			// 
			// label_Replace
			// 
			this.label_Replace.AutoSize = true;
			this.label_Replace.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label_Replace.Location = new System.Drawing.Point(13, 38);
			this.label_Replace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_Replace.Name = "label_Replace";
			this.label_Replace.Size = new System.Drawing.Size(81, 15);
			this.label_Replace.TabIndex = 12;
			this.label_Replace.Text = "바꿀 내용(&P) :";
			// 
			// button_ReplaceAll
			// 
			this.button_ReplaceAll.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.button_ReplaceAll.Location = new System.Drawing.Point(376, 62);
			this.button_ReplaceAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.button_ReplaceAll.Name = "button_ReplaceAll";
			this.button_ReplaceAll.Size = new System.Drawing.Size(96, 22);
			this.button_ReplaceAll.TabIndex = 15;
			this.button_ReplaceAll.Text = "모두 바꾸기(&A)";
			this.button_ReplaceAll.UseVisualStyleBackColor = true;
			this.button_ReplaceAll.Click += new System.EventHandler(this.button_ReplaceAll_Click);
			// 
			// FormReplace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(484, 181);
			this.Controls.Add(this.button_ReplaceAll);
			this.Controls.Add(this.button_Replace);
			this.Controls.Add(this.textBox_Replace);
			this.Controls.Add(this.label_Replace);
			this.Controls.Add(this.checkBox_Case);
			this.Controls.Add(this.checkBox_Word);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_Next);
			this.Controls.Add(this.textBox_Search);
			this.Controls.Add(this.label_Search);
			this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.Name = "FormReplace";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "바꾸기";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox_Case;
		private System.Windows.Forms.CheckBox checkBox_Word;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_Next;
		private System.Windows.Forms.TextBox textBox_Search;
		private System.Windows.Forms.Label label_Search;
		private System.Windows.Forms.Button button_Replace;
		private System.Windows.Forms.TextBox textBox_Replace;
		private System.Windows.Forms.Label label_Replace;
		private System.Windows.Forms.Button button_ReplaceAll;
	}
}