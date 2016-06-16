using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPadSharp
{
	public partial class FormMail : Form
	{
		private String FilePath = null;

		public FormMail()
		{
			InitializeComponent();
		}

		public FormMail(String str)
		{
			InitializeComponent();

			FilePath = str;
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			string id = textBox_ID.Text;
			string pw = textBox_PW.Text;
			string receiver = textBox_Receiver.Text;
			string subject = textBox_Subject.Text;
			string body = textBox_Body.Text;

			string temp = id.Substring(id.IndexOf("@") + 1);
			temp = temp.Substring(0, temp.IndexOf("."));

			try
			{
				System.Net.Mail.Attachment attachment = new Attachment(FilePath);

				MailAddress from = new MailAddress(id);
				MailAddress to = new MailAddress(receiver);

				MailMessage mail = new MailMessage(from, to);
				mail.SubjectEncoding = Encoding.UTF8;
				mail.Subject = subject;
				mail.BodyEncoding = Encoding.UTF8;
				mail.Body = body;
				mail.Attachments.Add(attachment);

				SmtpClient smtp = new SmtpClient("smtp." + temp + ".com", 587);
				smtp.EnableSsl = true;
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.Credentials = new System.Net.NetworkCredential(id, pw);

				smtp.Send(mail);

				MessageBox.Show("메일이 전송되었습니다!");

				DialogResult = DialogResult.OK;
			}
			catch
			{
				MessageBox.Show("메일 전송이 실패했습니다!");
			}
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
