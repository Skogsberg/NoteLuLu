using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace NoteLuLu.Assets.Data
{
    class Print
    {
        PrintDialog PrintIt;

        public Print(TextBox text)
        {
            PrintIt = new PrintDialog();
            PrintItNow(text);
        }

        public void PrintItNow(TextBox printText)
        {
            if (PrintIt.ShowDialog() != true) { return; }
            else if (PrintIt.ShowDialog() == true) { PrintIt.PrintVisual(printText, "My First Print Job"); }
            else { MessageBox.Show("Somthing was wrong! please check if all is correct", "Wrong", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
    }
}
