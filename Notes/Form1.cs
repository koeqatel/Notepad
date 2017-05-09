using System;
using System.Net;
using System.Windows.Forms;

namespace Notes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            editor.Visible = false;
            editor.Text = new UserData(true).notesHtml;

            viewer.DocumentText = getPrerequisites() + editor.Text;
        }

        public string getPrerequisites()
        {
            try
            {
                string jquery = new WebClient().DownloadString(new UserData(true).jqueryUri);
                preReqFail.Visible = false;
                return "<script>" + jquery + "</script>";
            }
            catch (Exception ex)
            {
                preReqFail.Visible = true;
                return "";
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editToolStripMenuItem.Text == "Edit")
            {
                editToolStripMenuItem.Text = "Done";

                editor.Visible = true;
                viewer.Visible = false;
            }
            else
            {
                editToolStripMenuItem.Text = "Edit";
                viewer.DocumentText = getPrerequisites() + editor.Text;

                editor.Visible = false;
                viewer.Visible = true;
            }

            new UserData(editor.Text).SaveToFile();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Text = new UserData(true).notesHtml;

            viewer.DocumentText = "";
            viewer.DocumentText = getPrerequisites() + editor.Text;
        }
    }
}
