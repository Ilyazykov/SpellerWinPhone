using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SpellerWinPhone.Spellcheckers
{
    class SpellcheckerYandex : ISpellchecker
    {
        public string findMistakes(string msg)
        {
            MessageBox.Show(msg);
            return "";
        }
    }
}