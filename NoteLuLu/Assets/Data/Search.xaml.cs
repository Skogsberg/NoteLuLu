using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoteLuLu.Assets.Data
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {

        TextBox text;

        public Search(TextBox text)
        {
            InitializeComponent();
            this.text = text;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchWord = TbSearch.Text;
            int textcount = 0;
            int index = 0;
            while (textcount < text.Text.Length)
            {
                while (index < text.Text.LastIndexOf(searchWord))
                {
                    text.Select(text.Text.IndexOf(searchWord), searchWord.Length); ;
                    index = text.Text.IndexOf(searchWord, index) + 1;
                }
                textcount++;

            }
            Close();

        }
    }
}
