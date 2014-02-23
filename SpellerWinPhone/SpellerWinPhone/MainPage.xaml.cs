using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace SpellerWinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Text.Spellchecked += (s, e) =>
            {
                string res = "";
                foreach (var word in e.misspelledWords)
                {
                    res += word + " ";
                }
                Result.Text = res;
            };
        }
    }
}