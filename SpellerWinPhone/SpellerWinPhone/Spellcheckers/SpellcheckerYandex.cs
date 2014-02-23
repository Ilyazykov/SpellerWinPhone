using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;

namespace SpellerWinPhone.Spellcheckers
{
    class SpellcheckerYandex : ISpellchecker
    {
        public string findMistakes(string msg)
        {
            var urlStrin = String.Format("http://speller.yandex.net/services/spellservice.json/checkText?text={0}", msg);

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
            // If the request was not canceled and did not throw
            // an exception, display the resource.
            else if (!e.Cancelled)
            {
                MessageBox.Show((string)e.Result);
                //If you get the cross-thread exception then use the following line instead of the above
                //Dispatcher.BeginInvoke(new Action (() => textBlock1.Text = (string)e.Result));
            }
        }
    }
}