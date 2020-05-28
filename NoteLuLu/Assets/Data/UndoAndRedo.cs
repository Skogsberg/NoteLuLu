using System.Windows.Controls;

namespace NoteLuLu.Assets.Data
{
    public class UndoAndRedo
    {
        TextBox text;

        public UndoAndRedo(TextBox text) { this.text = text; }

        public void UndoMethod() { text.Undo(); }
        public void RedoMethod() { text.Redo(); }
    }
}
