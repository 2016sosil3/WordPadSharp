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
	public partial class FormDate : Form
	{
		public FormDate()
		{
			InitializeComponent();

			listBox.Items.Add(DateTime.Now.ToString("d"));
			listBox.Items.Add(DateTime.Now.ToString("D"));
			listBox.Items.Add(DateTime.Now.ToString("f"));
			listBox.Items.Add(DateTime.Now.ToString("F"));
			listBox.Items.Add(DateTime.Now.ToString("g"));
			listBox.Items.Add(DateTime.Now.ToString("G"));
			listBox.Items.Add(DateTime.Now.ToString("m"));
			listBox.Items.Add(DateTime.Now.ToString("o"));
			listBox.Items.Add(DateTime.Now.ToString("R"));
			listBox.Items.Add(DateTime.Now.ToString("s"));
			listBox.Items.Add(DateTime.Now.ToString("t"));
			listBox.Items.Add(DateTime.Now.ToString("T"));
			listBox.Items.Add(DateTime.Now.ToString("u"));
			listBox.Items.Add(DateTime.Now.ToString("U"));
			listBox.Items.Add(DateTime.Now.ToString("y"));
		}

		private void listBox_DoubleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		public String DateString
		{
			get { return listBox.SelectedItem.ToString(); }
		}
	}
}
