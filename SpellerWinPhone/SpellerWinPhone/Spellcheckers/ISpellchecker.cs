using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

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

    abstract class ISpellchecker
    {
        public virtual event EventHandler<CustomEventsArgs> RaiseCustomEvent;

        abstract public void findMistakes(string msg);
    }
}
