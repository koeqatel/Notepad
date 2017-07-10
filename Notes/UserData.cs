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

        public UserData(string html)
        {
            notesHtml = html;
        }

        public UserData(bool loadFromFile)
        {
            try
            {
                string s = File.ReadAllText(Environment.CurrentDirectory + "/userData.json");

                notesHtml = JsonConvert.DeserializeObject<UserData>(s).notesHtml;
            }
            catch (Exception ex)
            { }
        }

        public UserData()
        { }

        public string notesHtml { get; set; }

        public void SaveToFile()
        {
            //Save to JSON
            string s = JsonConvert.SerializeObject(this);
            File.WriteAllText(Environment.CurrentDirectory + "/userData.json", s);
        }
    }
}
