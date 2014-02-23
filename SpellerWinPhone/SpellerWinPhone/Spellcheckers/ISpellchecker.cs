using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellerWinPhone.Spellcheckers
{
    abstract class ISpellchecker
    {
        public LinkedList<string> misspelledWords;
        public LinkedList<string> replacementOptions;

        abstract public string findMistakes(string msg);
    }
}
