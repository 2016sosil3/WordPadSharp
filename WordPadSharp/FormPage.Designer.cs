namespace WordPadSharp
{
	partial class FormPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPage));
			this.groupBox_Rotation = new System.Windows.Forms.GroupBox();
			this.radioButton_Horizontal = new System.Windows.Forms.RadioButton();
			this.radioButton_Vertical = new System.Windows.Forms.RadioButton();
			this.groupBox_Margin = new System.Windows.Forms.GroupBox();
			this.textBox_Margin_Right = new System.Windows.Forms.TextBox();
			this.textBox_Margin_Bottom = new System.Windows.Forms.TextBox();
			this.textBox_Margin_Top = new System.Windows.Forms.TextBox();
			this.textBox_Margin_Left = new System.Windows.Forms.TextBox();
			this.label_Margin_Right = new System.Windows.Forms.Label();
			this.label_Margin_Bottom = new System.Windows.Forms.Label();
			this.label_Margin_Left = new System.Windows.Forms.Label();
			this.label_Margin_Top = new System.Windows.Forms.Label();
			this.button_OK = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.groupBox_Rotation.SuspendLayout();
			this.groupBox_Margin.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_Rotation
			// 
			this.groupBox_Rotation.Controls.Add(this.radioButton_Horizontal);
			this.groupBox_Rotation.Controls.Add(this.radioButton_Vertical);
			this.groupBox_Rotation.Location = new System.Drawing.Point(12, 12);
			this.groupBox_Rotation.Name = "groupBox_Rotation";
			this.groupBox_Rotation.Size = new System.Drawing.Size(86, 72);
			this.groupBox_Rotation.TabIndex = 0;
			this.groupBox_Rotation.TabStop = false;
			this.groupBox_Rotation.Text = "용지 방향";
			// 
			// radioButton_Horizontal
			// 
			this.radioButton_Horizontal.AutoSize = true;
			this.radioButton_Horizontal.Location = new System.Drawing.Point(12, 42);
			this.radioButton_Horizontal.Name = "radioButton_Horizontal";
			this.radioButton_Horizontal.Size = new System.Drawing.Size(47, 16);
			this.radioButton_Horizontal.TabIndex = 1;
			this.radioButton_Horizontal.Text = "가로";
			this.radioButton_Horizontal.UseVisualStyleBackColor = true;
			this.radioButton_Horizontal.Click += new System.EventHandler(this.radioButton_Horizontal_Click);
			// 
			// radioButton_Vertical
			// 
			this.radioButton_Vertical.AutoSize = true;
			this.radioButton_Vertical.Checked = true;
			this.radioButton_Vertical.Location = new System.Drawing.Point(12, 20);
			this.radioButton_Vertical.Name = "radioButton_Vertical";
			this.radioButton_Vertical.Size = new System.Drawing.Size(47, 16);
			this.radioButton_Vertical.TabIndex = 0;
			this.radioButton_Vertical.TabStop = true;
			this.radioButton_Vertical.Text = "세로";
			this.radioButton_Vertical.UseVisualStyleBackColor = true;
			this.radioButton_Vertical.Click += new System.EventHandler(this.radioButton_Vertical_Click);
			// 
			// groupBox_Margin
			// 
			this.groupBox_Margin.Controls.Add(this.textBox_Margin_Right);
			this.groupBox_Margin.Controls.Add(this.textBox_Margin_Bottom);
			this.groupBox_Margin.Controls.Add(this.textBox_Margin_Top);
			this.groupBox_Margin.Controls.Add(this.textBox_Margin_Left);
			this.groupBox_Margin.Controls.Add(this.label_Margin_Right);
			this.groupBox_Margin.Controls.Add(this.label_Margin_Bottom);
			this.groupBox_Margin.Controls.Add(this.label_Margin_Left);
			this.groupBox_Margin.Controls.Add(this.label_Margin_Top);
			this.groupBox_Margin.Location = new System.Drawing.Point(104, 12);
			this.groupBox_Margin.Name = "groupBox_Margin";
			this.groupBox_Margin.Size = new System.Drawing.Size(368, 100);
			this.groupBox_Margin.TabIndex = 1;
			this.groupBox_Margin.TabStop = false;
			this.groupBox_Margin.Text = "여백";
			// 
			// textBox_Margin_Right
			// 
			this.textBox_Margin_Right.Location = new System.Drawing.Point(262, 20);
			this.textBox_Margin_Right.Name = "textBox_Margin_Right";
			this.textBox_Margin_Right.Size = new System.Drawing.Size(100, 21);
			this.textBox_Margin_Right.TabIndex = 7;
			// 
			// textBox_Margin_Bottom
			// 
			this.textBox_Margin_Bottom.Location = new System.Drawing.Point(262, 57);
			this.textBox_Margin_Bottom.Name = "textBox_Margin_Bottom";
			this.textBox_Margin_Bottom.Size = new System.Drawing.Size(100, 21);
			this.textBox_Margin_Bottom.TabIndex = 6;
			// 
			// textBox_Margin_Top
			// 
			this.textBox_Margin_Top.Location = new System.Drawing.Point(52, 57);
			this.textBox_Margin_Top.Name = "textBox_Margin_Top";
			this.textBox_Margin_Top.Size = new System.Drawing.Size(100, 21);
			this.textBox_Margin_Top.TabIndex = 5;
			// 
			// textBox_Margin_Left
			// 
			this.textBox_Margin_Left.Location = new System.Drawing.Point(52, 22);
			this.textBox_Margin_Left.Name = "textBox_Margin_Left";
			this.textBox_Margin_Left.Size = new System.Drawing.Size(100, 21);
			this.textBox_Margin_Left.TabIndex = 4;
			// 
			// label_Margin_Right
			// 
			this.label_Margin_Right.AutoSize = true;
			this.label_Margin_Right.Location = new System.Drawing.Point(207, 25);
			this.label_Margin_Right.Name = "label_Margin_Right";
			this.label_Margin_Right.Size = new System.Drawing.Size(49, 12);
			this.label_Margin_Right.TabIndex = 3;
			this.label_Margin_Right.Text = "오른쪽 :";
			// 
			// label_Margin_Bottom
			// 
			this.label_Margin_Bottom.AutoSize = true;
			this.label_Margin_Bottom.Location = new System.Drawing.Point(207, 60);
			this.label_Margin_Bottom.Name = "label_Margin_Bottom";
			this.label_Margin_Bottom.Size = new System.Drawing.Size(49, 12);
			this.label_Margin_Bottom.TabIndex = 2;
			this.label_Margin_Bottom.Text = "아래쪽 :";
			// 
			// label_Margin_Left
			// 
			this.label_Margin_Left.AutoSize = true;
			this.label_Margin_Left.Location = new System.Drawing.Point(9, 25);
			this.label_Margin_Left.Name = "label_Margin_Left";
			this.label_Margin_Left.Size = new System.Drawing.Size(37, 12);
			this.label_Margin_Left.TabIndex = 1;
			this.label_Margin_Left.Text = "왼쪽 :";
			// 
			// label_Margin_Top
			// 
			this.label_Margin_Top.AutoSize = true;
			this.label_Margin_Top.Location = new System.Drawing.Point(9, 60);
			this.label_Margin_Top.Name = "label_Margin_Top";
			this.label_Margin_Top.Size = new System.Drawing.Size(37, 12);
			this.label_Margin_Top.TabIndex = 0;
			this.label_Margin_Top.Text = "위쪽 :";
			// 
			// button_OK
			// 
			this.button_OK.Location = new System.Drawing.Point(316, 126);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 2;
			this.button_OK.Text = "확인";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(397, 126);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 3;
			this.button_Cancel.Text = "취소";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// FormPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 161);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.groupBox_Margin);
			this.Controls.Add(this.groupBox_Rotation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormPage";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "페이지 설정";
			this.groupBox_Rotation.ResumeLayout(false);
			this.groupBox_Rotation.PerformLayout();
			this.groupBox_Margin.ResumeLayout(false);
			this.groupBox_Margin.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_Rotation;
		private System.Windows.Forms.RadioButton radioButton_Horizontal;
		private System.Windows.Forms.RadioButton radioButton_Vertical;
		private System.Windows.Forms.GroupBox groupBox_Margin;
		private System.Windows.Forms.Label label_Margin_Top;
		private System.Windows.Forms.Label label_Margin_Right;
		private System.Windows.Forms.Label label_Margin_Bottom;
		private System.Windows.Forms.Label label_Margin_Left;
		private System.Windows.Forms.TextBox textBox_Margin_Right;
		private System.Windows.Forms.TextBox textBox_Margin_Bottom;
		private System.Windows.Forms.TextBox textBox_Margin_Top;
		private System.Windows.Forms.TextBox textBox_Margin_Left;
		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.Button button_Cancel;
	}
}