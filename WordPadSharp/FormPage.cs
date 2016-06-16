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
	public partial class FormPage : Form
	{
		private int PageType = 0;

		private int Margin_Top = 0;
		private int Margin_Bottom = 0;
		private int Margin_Left = 0;
		private int Margin_Right = 0;

		public FormPage()
		{
			InitializeComponent();
		}

		public FormPage(int type, int left, int top, int right, int bottom)
		{
			InitializeComponent();

			PageType = type;

			switch (type)
			{
				case 0:
					radioButton_Vertical.Checked = true;
					radioButton_Horizontal.Checked = false;
					break;

				case 1:
					radioButton_Vertical.Checked = false;
					radioButton_Horizontal.Checked = true;
					break;

				default:
					break;
			}

			textBox_Margin_Left.Text = left.ToString();
			textBox_Margin_Right.Text = right.ToString();
			textBox_Margin_Top.Text = top.ToString();
			textBox_Margin_Bottom.Text = bottom.ToString();
		}

		private void radioButton_Vertical_Click(object sender, EventArgs e)
		{
			PageType = 0;

			radioButton_Horizontal.Checked = false;
		}

		private void radioButton_Horizontal_Click(object sender, EventArgs e)
		{
			PageType = 1;

			radioButton_Vertical.Checked = false;
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			Margin_Left = Convert.ToInt32(textBox_Margin_Left.Text);
			Margin_Right = Convert.ToInt32(textBox_Margin_Right.Text);
			Margin_Top = Convert.ToInt32(textBox_Margin_Top.Text);
			Margin_Bottom = Convert.ToInt32(textBox_Margin_Bottom.Text);

			DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		public int MyType
		{
			get { return PageType; }
		}

		public Padding MyPadding
		{
			get { return new Padding(Margin_Left, Margin_Top, Margin_Right, Margin_Bottom); }
		}
	}
}
