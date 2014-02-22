using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

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
        public string TempText
        {
            get
            {
                return "temprorary text"; //TODO - другое что-то надо возвращать
            }
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
            CheckCommand = new RelayCommand<string>((msg) => Spellchecking(msg));
        }

        private object Spellchecking(string msg)
        {
            MessageBox.Show("Введённая строка ->" + msg);
            return null;
        }


    }
}