using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NoteLuLu.Assets.Data
{
    class EditTools
    {
        TextBox text;

        public EditTools(TextBox text) { this.text = text; }

        public void CutMethod() { text.Cut(); }
        public void CopyMethod() { text.Copy(); }
        public void PasteMethod() { text.Paste(); }
        public void SelectAllMethod() { text.SelectAll(); }
    }
}
