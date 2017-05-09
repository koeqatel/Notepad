using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class UserData
    {

        public UserData(string html, string jquery = "https://code.jquery.com/jquery-1.12.4.min.js")
        {
            jqueryUri = jquery;
            notesHtml = html;
        }

        public UserData(bool loadFromFile)
        {
            try
            {
                string s = File.ReadAllText(Environment.CurrentDirectory + "/userData.json");

                notesHtml = JsonConvert.DeserializeObject<UserData>(s).notesHtml;
                jqueryUri = JsonConvert.DeserializeObject<UserData>(s).jqueryUri;
            }
            catch (Exception ex)
            { jqueryUri = "https://code.jquery.com/jquery-1.12.4.min.js"; }
        }

        public UserData()
        { }

        public string notesHtml { get; set; }
        public string jqueryUri { get; set; }

        public void SaveToFile()
        {
            //Save to JSON
            string s = JsonConvert.SerializeObject(this);
            File.WriteAllText(Environment.CurrentDirectory + "/userData.json", s);
        }
    }
}
