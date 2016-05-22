namespace WordPadSharp
{
	partial class FormInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.labelVersion = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelS4 = new System.Windows.Forms.Label();
			this.labelS3 = new System.Windows.Forms.Label();
			this.labelS2 = new System.Windows.Forms.Label();
			this.labelS1 = new System.Windows.Forms.Label();
			this.buttonOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(60, 60);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.labelVersion.Location = new System.Drawing.Point(78, 33);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(276, 21);
			this.labelVersion.TabIndex = 1;
			this.labelVersion.Text = "WordPad# Version : Beta_20160522";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelS4);
			this.groupBox1.Controls.Add(this.labelS3);
			this.groupBox1.Controls.Add(this.labelS2);
			this.groupBox1.Controls.Add(this.labelS1);
			this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.groupBox1.Location = new System.Drawing.Point(12, 83);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 108);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "제작자";
			// 
			// labelS4
			// 
			this.labelS4.AutoSize = true;
			this.labelS4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.labelS4.Location = new System.Drawing.Point(222, 78);
			this.labelS4.Name = "labelS4";
			this.labelS4.Size = new System.Drawing.Size(122, 17);
			this.labelS4.TabIndex = 5;
			this.labelS4.Text = "2014726096 조휘연";
			// 
			// labelS3
			// 
			this.labelS3.AutoSize = true;
			this.labelS3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.labelS3.Location = new System.Drawing.Point(16, 78);
			this.labelS3.Name = "labelS3";
			this.labelS3.Size = new System.Drawing.Size(122, 17);
			this.labelS3.TabIndex = 4;
			this.labelS3.Text = "2014726069 김혜진";
			// 
			// labelS2
			// 
			this.labelS2.AutoSize = true;
			this.labelS2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.labelS2.Location = new System.Drawing.Point(222, 30);
			this.labelS2.Name = "labelS2";
			this.labelS2.Size = new System.Drawing.Size(122, 17);
			this.labelS2.TabIndex = 3;
			this.labelS2.Text = "2014726062 이은찬";
			// 
			// labelS1
			// 
			this.labelS1.AutoSize = true;
			this.labelS1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.labelS1.Location = new System.Drawing.Point(16, 30);
			this.labelS1.Name = "labelS1";
			this.labelS1.Size = new System.Drawing.Size(122, 17);
			this.labelS1.TabIndex = 3;
			this.labelS1.Text = "2013726023 민병찬";
			// 
			// buttonOk
			// 
			this.buttonOk.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.buttonOk.Location = new System.Drawing.Point(155, 226);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 3;
			this.buttonOk.Text = "확인";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// FormInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormInfo";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WordPad# 정보";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelS1;
		private System.Windows.Forms.Label labelS4;
		private System.Windows.Forms.Label labelS3;
		private System.Windows.Forms.Label labelS2;
		private System.Windows.Forms.Button buttonOk;
	}
}