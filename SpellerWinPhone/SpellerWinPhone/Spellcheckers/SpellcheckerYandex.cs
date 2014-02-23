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
    public class CustomEventsArgs : EventArgs
    {
        public string misspelledWords;

        public CustomEventsArgs(string str)
        {
            misspelledWords = str;
        }
    }

    class SpellcheckerYandex : ISpellchecker
    {
        public event EventHandler<CustomEventsArgs> RaiseCustomEvent;

        override public void findMistakes(string msg)
        {
            var url = String.Format("http://speller.yandex.net/services/spellservice/checkText?text={0}", msg);

            WebClient client = new WebClient();

            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCallback);
            client.DownloadStringAsync(new Uri(url));
        }

        private void DownloadStringCallback(Object sender, DownloadStringCompletedEventArgs e)
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
                        //TODO replacementOptions
                    }
                }

                CustomEventsArgs e1 = new CustomEventsArgs(res);

                EventHandler<CustomEventsArgs> handler = RaiseCustomEvent;

                if (handler != null)
                {
                    handler(this, e1);
                }
            }
        }
    }
}