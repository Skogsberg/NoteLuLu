using System.Windows.Controls;
using System.Diagnostics;
using System;
using System.Windows;

namespace NoteLuLu.Assets.Data
{
    class SearchWebb
    {
        TextBox text;
        string searchEngine = "https://www.google.com/search?q=";


        public SearchWebb(TextBox text) { this.text = text; }

        public void SearchWebbMethod()
        {
            string searchWord = text.SelectedText;
            string strUrl = searchEngine + searchWord;

            Process pros = new Process();

            try
            {
                pros.StartInfo.UseShellExecute = true;
                pros.StartInfo.FileName = strUrl;
                pros.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Can´t find your webbrowser!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }





        }
    }
}
