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
	public partial class FormDialog : Form
	{
		public FormDialog()
		{
			InitializeComponent();
			CancelButton = buttonCancel;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Yes;
		}

		private void buttonNotSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
