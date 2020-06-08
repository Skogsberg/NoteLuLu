using Microsoft.Win32;
using NoteLuLu.Assets.Data;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Collections.Specialized;

namespace NoteLuLu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool didYouSave;
        private Print print;
        SaveAndLoad sal;
        UndoAndRedo ur;
        EditTools editTools;
        public string savedFile;

        public MainWindow()
        {
            InitializeComponent();
            CheckIfStringIsEmpty();
            sal = new SaveAndLoad(MainTextBox);
            LineBlock.Text = "1";

        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menu)
            {
                switch (menu.Header)
                {
                    // ---Under File
                    case "New": CheckIfStringIsEmpty(); if (didYouSave == true) { MainTextBox.Clear(); } else { AskForSaving(menu); } break;
                    case "Exit": CheckIfStringIsEmpty(); if (didYouSave == true) { Application.Current.Shutdown(); } else { AskForSaving(menu); } break;
                    case "Print": print = new Print(MainTextBox); break;
                    case "New Window": MainWindow mainExtra = new MainWindow(); mainExtra.Show(); break;
                    case "Save": sal.SaveFile(); break;
                    case "Save As": sal.SaveFileAs(); break;
                    case "Open": sal.LoadFile(); break;
                    // ---Under Edit
                    case "Undo": ur = new UndoAndRedo(MainTextBox); ur.UndoMethod(); break;
                    case "Redo": ur = new UndoAndRedo(MainTextBox); ur.RedoMethod(); break;
                    case "Cut": editTools = new EditTools(MainTextBox); editTools.CutMethod(); break;
                    case "Copy": editTools = new EditTools(MainTextBox); editTools.CopyMethod(); break;
                    case "Paste": editTools = new EditTools(MainTextBox); editTools.PasteMethod(); break;
                    case "Select all": editTools = new EditTools(MainTextBox); editTools.SelectAllMethod(); break;
                    case "Search": Search search = new Search(MainTextBox); search.Show(); break;
                    case "Search web": if (MainTextBox.SelectionLength > 0) { SearchWebb SWebb = new SearchWebb(MainTextBox); SWebb.SearchWebbMethod(); } else { return; } break;
                    case "Set read only": if (menu.IsChecked == true) { MainTextBox.IsReadOnly = true; } else { MainTextBox.IsReadOnly = false; } break;
                }
            }
        }

        public void CheckIfStringIsEmpty()
        {
            if (MainTextBox.Text == String.Empty) { didYouSave = true; }
            else { didYouSave = false; }
        }

        /// <summary>
        /// Checking if date is saved or will ask you to save
        /// </summary>
        /// <param name="menu"></param>
        public void AskForSaving(MenuItem menu)
        {
            MessageBoxResult answer;
            switch (menu.Header)
            {
                case "New":
                    answer = MessageBox.Show("You don´t have saved your work! Do you want to save your work?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (answer == MessageBoxResult.No) { MainTextBox.Clear(); }
                    break;
                case "Exit":
                    answer = MessageBox.Show("You don´t have saved your work! Do you want to exit anyway", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (answer == MessageBoxResult.Yes) { Application.Current.Shutdown(); }
                    break;
            }
        }

      

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int line;
            line = MainTextBox.LineCount;
            string lineNumbers = "";

            for (int i = 1; i <= line; i++)
            {
                lineNumbers += i.ToString() + "\n";
            }
            LineBlock.Text = lineNumbers;


        }
    }



}
