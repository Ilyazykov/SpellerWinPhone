using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using unirest_net.http;
using unirest_net.request;

namespace SpellerWinPhone.Spellcheckers
{
    class SpellcheckerMashape : ISpellchecker
    {
        override public void findMistakes(string msg)
        {
            string key = "Sw5Km8ZsGJHdT6ezOXfURD0Q5n5b8N6R";

            HttpRequest req = Unirest.get("https://montanaflynn-spellcheck.p.mashape.com/check/?text=This%20sentnce%20has%20some%20probblems.");

            //HttpResponse<string> response = Unirest.get("https://montanaflynn-spellcheck.p.mashape.com/check/?text=This%20sentnce%20has%20some%20probblems.");
                //.header("X-Mashape-Authorization", key).asString();

            //MessageBox.Show(response.ToString());
            //throw new NotImplementedException();
        }
    }
}