using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace NoteLuLu.Assets.Data
{
    public class SaveAndLoad
    {
        SaveFileDialog saveFile;
        OpenFileDialog openFile;
        string savedFile;
        TextBox text;
        string files = "Text Documents (*.txt)|*.txt|NoteLuLu Documents (*.nlu)|*.nlu|SQL File (*.sql)|*.sql|All (*.*)|*.*";

        public SaveAndLoad(TextBox text) { this.text = text; }

        public void SaveFile()
        {
            saveFile = new SaveFileDialog();

            if (savedFile == null) { SaveFileAs(); }
            else { File.WriteAllText(savedFile, text.Text); }
        }

        public void SaveFileAs()
        {
            saveFile = new SaveFileDialog();

            saveFile.DefaultExt = ".txt";
            saveFile.FilterIndex = 1;
            saveFile.Filter = files;
            saveFile.FileName = "NoteLuLu";

            if (saveFile.ShowDialog() == true) { File.WriteAllText(saveFile.FileName, text.Text); savedFile = saveFile.FileName; }
            else { return; }
        }

        public void LoadFile()
        {
            openFile = new OpenFileDialog();

            openFile.DefaultExt = ".txt";
            openFile.Filter = files;

            if (openFile.ShowDialog() == true) { text.Text = File.ReadAllText(openFile.FileName); savedFile = openFile.FileName; }
        }
    }
}