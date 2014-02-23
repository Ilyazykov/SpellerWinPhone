using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml;
using System.IO;

namespace SpellerWinPhone.Spellcheckers
{
    class SpellcheckerYandex : ISpellchecker
    {
        override public string findMistakes(string msg)
        {
            var urlStrin = String.Format("http://speller.yandex.net/services/spellservice/checkText?text={0}", msg);

            LoadSiteContent(urlStrin);

            return "";
        }

        public void LoadSiteContent(string url)
        {
            WebClient client = new WebClient();

            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCallback2);
            client.DownloadStringAsync(new Uri(url));
        }

        private void DownloadStringCallback2(Object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("e.Error != null");
            }
            else if (!e.Cancelled)
            {
                string xmlString = (string)e.Result;
                string res = "";

                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {

                    while (reader.ReadToFollowing("word"))
                    {
                        res += reader.ReadElementContentAsString() + " ";
                    }
                }

                MessageBox.Show(res);
            }
        }
    }
}