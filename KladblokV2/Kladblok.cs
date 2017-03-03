﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace KladblokV2
{
    public partial class Kladblok : Form
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr Wnd, int CmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        #region Fields

        public static Color color;
        public static string Content;
        public static string Username = Environment.UserName;
        public static string PrimDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
        public static string DeltagText = "null";
        public static int ColorCode = 0;
        public static int BGColorCode;
        public string PickedColor;
        public static Dictionary<string, string> Config = new Dictionary<string, string>();
        public int Showcounter = 0;

        public static string folderPath = PrimDrive + @"Users\" + Username + @"\Appdata\Roaming\SnSStudio\Notes\";
        public static string filePath = PrimDrive + @"Users\" + Username + @"\Appdata\Roaming\SnSStudio\Notes\Content.txt";
        public static string ConfigPath = PrimDrive + @"Users\" + Username + @"\Appdata\Roaming\SnSStudio\Notes\Config.txt";
        #endregion

        public Kladblok()
        {
            InitializeComponent();
            CreateFolder();
            ReadConfig();
            ConsoleCheck.Checked = Convert.ToBoolean(Config["Console"]);
            var handle = GetConsoleWindow();

            // Hide
            if (ConsoleCheck.Checked == false)
            {
                ShowWindow(handle, SW_HIDE);
            }

            // Show
            if (ConsoleCheck.Checked == true)
            {
                ShowWindow(handle, SW_SHOW);
            }
            BG();

        }

        private void Kladblok_Load(object sender, EventArgs e)
        {
            ReadText();
            Regex();
        }

        private void Kladblok_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.File.WriteAllText(Kladblok.filePath, Edit_Textbox.Text);
            SetConfig();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startMenuStrip.Visible = false;
            Textbox.Visible = false;
            TRT_Label.Visible = false;
            editMenuStrip.Visible = true;
            Edit_Textbox.Visible = true;
        }

        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(Kladblok.filePath, Edit_Textbox.Text);
            ReadText();
            Regex();

            startMenuStrip.Visible = true;
            Textbox.Visible = true;
            TRT_Label.Visible = true;
            editMenuStrip.Visible = false;
            Edit_Textbox.Visible = false;
        }

        private void ConsoleCheck_CheckedChanged(object sender, EventArgs e)
        {
            var handle = GetConsoleWindow();

            // Hide
            if (ConsoleCheck.Checked == false)
            {
                ShowWindow(handle, SW_HIDE);
                Config["Console"] = "false";
            }

            // Show
            if (ConsoleCheck.Checked == true)
            {
                ShowWindow(handle, SW_SHOW);
                Config["Console"] = "true";
            }
        }

        private void AutoSave_Tick(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(Kladblok.filePath, Edit_Textbox.Text);
        }

        private void chooseColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                SendKeys.Send(colorDialog1.Color.Name);
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                Kladblok.Config["Background Color"] = colorDialog1.Color.Name;
        }

        private void QuestionButt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To add text click the edit button and start typing" + Environment.NewLine +
                            "To add a color type '<color='Colorname/Colorcode'>Text</c>' in the edit menu." + Environment.NewLine +
                            "The tags will dissapear in the main screen when typed correctly.");
        }

        public void CreateFolder()
        {
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.WriteAllText(filePath, "New text file");
            }
            if (!System.IO.File.Exists(ConfigPath))
            {
                System.IO.File.WriteAllText(ConfigPath, "Background Color:control" + Environment.NewLine + "Console:true");
                Config["Background Color"] = "control";
                Config["Console"] = "true";
            }
        }

        public void ReadConfig()
        {
            string line;
            StreamReader ConfigReader = new StreamReader(ConfigPath);

            while ((line = ConfigReader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    Config[parts[0]] = Convert.ToString(parts[1]);
                }
            }

            ConfigReader.Close();
        }

        public void ReadText()
        {
            try
            {
                Content = System.IO.File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                if (!System.IO.Directory.Exists(folderPath))
                    System.IO.Directory.CreateDirectory(folderPath);

                System.IO.File.WriteAllText(filePath, "New notes file.");
            }
            Textbox.Text = Content;
            Edit_Textbox.Text = Content;
        }

        public void SetConfig()
        {
            int i = 0;
            System.IO.StreamWriter ConfigSetter = new System.IO.StreamWriter(ConfigPath);
            foreach (KeyValuePair<string, string> config in Config)
            {
                if (i == 0)
                {
                    ConfigSetter.WriteLine("Background Color:" + config.Value);
                }
                if (i == 1)
                {
                    ConfigSetter.WriteLine("Console:" + config.Value);
                }
                i++;

            }
            ConfigSetter.Close();
        }

        public void Regex()
        {
            Stopwatch TotalRegexTimer = Stopwatch.StartNew();

            //Read all of "Edit" and remove the tags.
            int End = 2147483647;
            foreach (Match match in new Regex("<color='(.*?)'>(.*?)</c>(.*?)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled).Matches(this.Textbox.Text))
            {
                GroupCollection groups = match.Groups;
                //Write to the console what is to be replaced
                Write("-=['" + (object)groups[2].Value.Replace("  ", "").Replace("\n", " | ") + "']=- ", ConsoleColor.DarkCyan);
                Write("Color starts at " + (object)groups[0].Index + ", the text runs from " + (object)groups[1].Index + " to " + (object)groups[3].Index + "\n");

                //Select from end of last tag to start of current tag and make it black again.
                //This is done because otherwise the text keeps the color of the last tag.
                this.Textbox.Select(End, groups[1].Index);
                this.Textbox.SelectionColor = Color.Black;
                this.Textbox.DeselectAll();

                //Actually change the color of the text.
                this.Textbox.Select(groups[2].Index, groups[2].Length);
                if (int.TryParse(groups[1].Value, NumberStyles.HexNumber, (IFormatProvider)CultureInfo.InvariantCulture, out Kladblok.ColorCode))
                {
                    Kladblok.ColorCode = int.Parse(groups[1].Value, NumberStyles.HexNumber);
                    this.Textbox.SelectionColor = Color.FromArgb(Kladblok.ColorCode);
                }
                else
                {
                    this.Textbox.SelectionColor = Color.FromName(groups[1].Value);
                }
                End = groups[3].Index;
            }

            List<string> Colors = new List<string>();
            foreach (Match match in new Regex("<color='(.*?)'>", RegexOptions.IgnoreCase | RegexOptions.Compiled).Matches(this.Textbox.Text))
            {
                //Show what color tags are found and add them to the list.
                GroupCollection groups = match.Groups;
                Write("'" + (object)groups[""].Value + "' ", ConsoleColor.Red);
                Write("starting at character " + (object)groups[0].Index + " is detected\n");
                Colors.Add(groups[1].Value);
            }
            //Clear all double values from the list.
            List<string> DistColors = Colors.Distinct().ToList();
            Write("\n");

            foreach (string color in DistColors)
            {
                Stopwatch TagRemoveTimer = Stopwatch.StartNew();
                //Remove the tags from the edit panel and show a textbox witout the tags.
                this.Textbox.Rtf = this.Textbox.Rtf.Replace("<color='" + color + "'>", "");
                this.Textbox.Rtf = this.Textbox.Rtf.Replace("</c>", "");

                //Display what tags are removed.
                Write("Removed every ");
                Write("<color='" + color + "'> ", ConsoleColor.Red);

                TagRemoveTimer.Stop();

                //Display how long removing the tag took.
                Write(", this took ");
                Write(TagRemoveTimer.ElapsedMilliseconds.ToString(), ConsoleColor.Red);
                Write(" Ms\n");

            }

            Write("End of current Regex\n\n\n", ConsoleColor.Blue);
            TotalRegexTimer.Stop();
            //Display how long the total process took.
            TRT_Label.Text = TotalRegexTimer.ElapsedMilliseconds + " ms";

        }

        public void BG()
        {
            if (Config["Background Color"] == "")
            {
                Config["Background Color"] = "control";
            }
            if (int.TryParse(Config["Background Color"], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out BGColorCode))
            {

                BGColorCode = int.Parse(Config["Background Color"], NumberStyles.HexNumber);
                Textbox.BackColor = Color.FromArgb(BGColorCode);
            }
            else
            {
                Textbox.BackColor = Color.FromName(Config["Background Color"]);
            }
        }

        public void Write(string Text, ConsoleColor Color)
        {
            if (ConsoleCheck.Checked == true)
            {
                Console.ForegroundColor = Color;
                Console.Write(Text);
                Console.ResetColor();
            }
        }

        public void Write(string Text)
        {
            if (ConsoleCheck.Checked == true)
            {
                Console.Write(Text);
            }
        }
    }
}
