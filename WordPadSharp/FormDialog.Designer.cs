namespace WordPadSharp
{
	partial class FormDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialog));
			this.labelText = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonNotSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelText.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.labelText.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.labelText.Location = new System.Drawing.Point(0, 0);
			this.labelText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(291, 21);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "변경 내용을 문서에 저장하시겠습니까?";
			// 
			// buttonSave
			// 
			this.buttonSave.AutoSize = true;
			this.buttonSave.Location = new System.Drawing.Point(117, 72);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(56, 25);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "저장(&S)";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonNotSave
			// 
			this.buttonNotSave.AutoSize = true;
			this.buttonNotSave.Location = new System.Drawing.Point(178, 72);
			this.buttonNotSave.Margin = new System.Windows.Forms.Padding(0);
			this.buttonNotSave.Name = "buttonNotSave";
			this.buttonNotSave.Size = new System.Drawing.Size(90, 25);
			this.buttonNotSave.TabIndex = 2;
			this.buttonNotSave.Text = "저장 안 함(&N)";
			this.buttonNotSave.UseVisualStyleBackColor = true;
			this.buttonNotSave.Click += new System.EventHandler(this.buttonNotSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.AutoSize = true;
			this.buttonCancel.Location = new System.Drawing.Point(273, 72);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(41, 25);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "취소";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FormDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(329, 102);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonNotSave);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelText);
			this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WordPad#";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonNotSave;
		private System.Windows.Forms.Button buttonCancel;
	}
}