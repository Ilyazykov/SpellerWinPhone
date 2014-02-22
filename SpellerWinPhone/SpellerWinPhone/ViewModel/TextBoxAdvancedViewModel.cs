using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using SpellerWinPhone.Spellcheckers;

namespace SpellerWinPhone.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TextBoxAdvancedViewModel : ViewModelBase
    {
        private string _tempText;
        public string TempText
        {
            get { return _tempText; }
            set { _tempText = value; }
        }

        private ISpellchecker spellchecker;

        public RelayCommand<string> CheckCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the MvvmViewModel1 class.
        /// </summary>
        public TextBoxAdvancedViewModel()
        {
            TempText = "temprorary text";
            spellchecker = new SpellcheckerYandex();

            CheckCommand = new RelayCommand<string>((msg) => Spellchecking(msg));
        }

        private object Spellchecking(string msg)
        {
            TempText = msg;
            string words = spellchecker.findMistakes(msg);
            //TODO вызов события с ошибками
            return null;
        }


    }
}