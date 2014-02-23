using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SpellerWinPhone.Spellcheckers;
using System.Windows.Media;

namespace SpellerWinPhone
{
    public partial class TextBoxAdvanced : UserControl
    {
        public event EventHandler<CustomEventsArgs> Spellchecked;

        private ISpellchecker spellchecker; //TODO изменить на абстрактный

        public TextBoxAdvanced()
        {
            InitializeComponent();

            spellchecker = new SpellcheckerYandex();

            spellchecker.RaiseCustomEvent += (o, e) => {
                if (e.misspelledWords == "")
                {
                    tbAdvanced.BorderBrush = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    tbAdvanced.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                EventHandler<CustomEventsArgs> handler = Spellchecked;
                if (Spellchecked != null)
                {
                    Spellchecked(this, e);
                }
            };
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            spellchecker.findMistakes(tbAdvanced.Text);
        }

        private void Mashape_Checked(object sender, RoutedEventArgs e)
        {
            spellchecker = new SpellcheckerMashape();
        }

        private void Yandex_Checked(object sender, RoutedEventArgs e)
        {
            spellchecker = new SpellcheckerYandex();
        }
    }
}