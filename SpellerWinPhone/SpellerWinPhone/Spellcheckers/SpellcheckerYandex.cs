﻿using System;
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
        public override event EventHandler<CustomEventsArgs> RaiseCustomEvent;

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
                MessageBox.Show("Something wrong");
            }
            else if (!e.Cancelled)
            {
                string xmlString = (string)e.Result;
                string res = "";
                string replacement = "";

                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {
                    while (reader.ReadToFollowing("word"))
                    {
                        res += reader.ReadElementContentAsString() + " ";

                        while (reader.Name == "s")
                        {
                            replacement += reader.ReadElementContentAsString();
                            if (reader.Name == "s") replacement += "+";
                            else replacement += " ";
                        }
                    }
                }

                CustomEventsArgs e1 = new CustomEventsArgs(res, replacement);

                EventHandler<CustomEventsArgs> handler = RaiseCustomEvent;

                if (handler != null)
                {
                    handler(this, e1);
                }
            }
        }
    }
}