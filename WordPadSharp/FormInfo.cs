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
	public partial class FormInfo : Form
	{
		public FormInfo()
		{
			InitializeComponent();

			AcceptButton = buttonOk;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
