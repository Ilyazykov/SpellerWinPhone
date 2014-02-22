using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellerWinPhone.Spellcheckers
{
    interface ISpellchecker
    {
        string findMistakes(string msg);
    }
}
