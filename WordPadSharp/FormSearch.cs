using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPadSharp
{
	public partial class FormSearch : Form
	{
		private int Start = 0;

		public FormSearch()
		{
			InitializeComponent();
		}

		private void button_Next_Click(object sender, EventArgs e)
		{
			FormMain formMain = (FormMain)this.Owner;
			RichTextBoxFinds option = RichTextBoxFinds.None;

			if (checkBox_Case.Checked)
				option |= RichTextBoxFinds.MatchCase;

			if (checkBox_Word.Checked)
				option |= RichTextBoxFinds.WholeWord;

			Start = formMain.MyFind(textBox_Search.Text, Start, option);

			if (Start < 0)
			{
				MessageBox.Show("문자열을 찾을 수 없습니다!");

				Start = 0;
			}
			else
				Start++;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
