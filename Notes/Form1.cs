using System;
using System.Net;
using System.Windows.Forms;
using cef;
using CefSharp.WinForms.Internals;
using CefSharp;
using CefSharp.WinForms;

namespace Notes
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public Form1()
        {
            InitializeComponent();
            // Start the browser after initialize global component
            InitializeChromium();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();

            // Initialize cef with the provided settings
            Cef.Initialize(settings);

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://google.com/");
            chromeBrowser.IsBrowserInitializedChanged += ChromeBrowser_IsBrowserInitializedChanged;

            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void ChromeBrowser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            chromeBrowser.LoadString(editor.Text, "about:notes");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            editor.Visible = false;
            editor.Text = new UserData(true).notesHtml;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editToolStripMenuItem.Text == "Edit")
            {
                editToolStripMenuItem.Text = "Done";

                editor.Visible = true;
                chromeBrowser.Visible = false;
            }
            else
            {
                editToolStripMenuItem.Text = "Edit";
                chromeBrowser.LoadString(editor.Text, "about:notes");

                editor.Visible = false;
                chromeBrowser.Visible = true;
            }

            new UserData(editor.Text).SaveToFile();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Text = new UserData(true).notesHtml;

            chromeBrowser.Reload();
            chromeBrowser.LoadString(editor.Text, "about:notes");
        }
    }
}
