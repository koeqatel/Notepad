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
            string jquery = new WebClient().DownloadString("https://code.jquery.com/jquery-1.12.4.min.js");

            return "<script>" + jquery + "</script>";
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
    }
}
