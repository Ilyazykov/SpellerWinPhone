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
            TempText = "temprorary text for yau";
        }

        private object Spellchecking(string msg)
        {
            TempText = msg;
            
            //TODO вызов события с ошибками
            return null;
        }


    }
}