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
        public LinkedList<string> misspelledWords;
        public LinkedList<LinkedList<string>> replacementOptions;

        public CustomEventsArgs(string misspelledStr, string replacementStr)
        {
            setMisspelledWords(misspelledStr);
            setReplacementOptions(replacementStr);
        }

        private void setMisspelledWords(string misspelledStr)
        {
            misspelledWords = new LinkedList<string>();
            string[] temp = misspelledStr.Split(' ');
            foreach (var word in temp)
            {
                misspelledWords.AddLast(word);
            }
            misspelledWords.RemoveLast();
        }

        private void setReplacementOptions(string replacementStr)
        {
            replacementOptions = new LinkedList<LinkedList<string>>();
            string[] temp = replacementStr.Split(' ');
            foreach (var words in temp)
            {
                LinkedList<string> tempList = new LinkedList<string>();
                string[] similarWords = words.Split('+');
                foreach (var word in similarWords)
                {
                    tempList.AddLast(word);
                }
                replacementOptions.AddLast(tempList);
            }
            replacementOptions.RemoveLast();
        }
    }

    abstract class ISpellchecker
    {
        public virtual event EventHandler<CustomEventsArgs> RaiseCustomEvent;

        abstract public void findMistakes(string msg);
    }
}
