using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace SpellerWinPhone.Spellcheckers
{
    abstract class ISpellchecker
    {
        abstract public void findMistakes(string msg);
    }
}
