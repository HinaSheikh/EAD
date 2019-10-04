using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Excercise6
{
    public partial class Form1 : Form
    {
        String fileName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtData.Text = "";
            fileName = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                var result = saveFileDialog1.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                }
            }
            if (fileName != "")
            {
                TextWriter writer = new StreamWriter(fileName);
                writer.Write(txtData.Text);
                writer.Flush();
                writer.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                StreamReader reader = new StreamReader(fileName);
                String text = reader.ReadToEnd();
                txtData.Text = text;
                reader.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;

                if (fileName != "")
                {
                    StreamWriter writer = new StreamWriter(fileName);
                    writer.Write(txtData.Text);
                    writer.Flush();
                    writer.Close();
                }
            }

        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
//protected void SendEmail(string _subject, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc = null)
//{
//    string Text = "";
//    SmtpClient mailClient = new SmtpClient("Mailhost");
//    MailMessage msgMail;
//    Text = "Stuff";
//    msgMail = new MailMessage();
//    msgMail.From = _from;
//    msgMail.To.Add(_to);
//    foreach (MailAddress addr in _cc)
//    {
//        msgMail.CC.Add(addr);
//    }
//    if (_bcc != null)
//    {
//        foreach (MailAddress addr in _bcc)
//        {
//            msgMail.Bcc.Add(addr);
//        }
//    }
//    msgMail.Subject = _subject;
//    msgMail.Body = Text;
//    msgMail.IsBodyHtml = true;
//    mailClient.Send(msgMail);
//    msgMail.Dispose();
//}
//}

//Task 2 Showing data in datagridview
//Task Three File Uploading