using System;
using System.Collections.Generic;

namespace MementoPattern
{
    public class TextEditor
    {
        private TextEditorState _state = new TextEditorState("Initial Text");

        public void SetState(string text)
        {
            _state = new TextEditorState(text);
        }

        public TextEditorState GetState()
        {
            return _state;
        }

        public TextEditorMemento Save()
        {
            return new TextEditorMemento(_state);
        }

        public void Restore(TextEditorMemento memento)
        {
            _state = memento.State;
        }
    }

    public class TextEditorState
    {
        public string Text { get; }

        public TextEditorState(string text)
        {
            Text = text;
        }
    }

    public class TextEditorMemento
    {
        public TextEditorState State { get; }

        public TextEditorMemento(TextEditorState state)
        {
            State = state;
        }
    }

    public class History
    {
        private readonly Stack<TextEditorMemento> _history = new Stack<TextEditorMemento>();

        public void Save(TextEditor editor)
        {
            _history.Push(editor.Save());
        }

        public void Undo(TextEditor editor)
        {
            if (_history.Count > 0)
            {
                var memento = _history.Pop();
                editor.Restore(memento);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TextEditor editor = new TextEditor();
            History history = new History();

            history.Save(editor);
            editor.SetState("First change");
            Console.WriteLine(editor.GetState().Text); // Output: First change

            history.Save(editor);
            editor.SetState("Second change");
            Console.WriteLine(editor.GetState().Text); // Output: Second change

            history.Undo(editor);
            Console.WriteLine(editor.GetState().Text); // Output: First change

            history.Undo(editor);
            Console.WriteLine(editor.GetState().Text); // Output: Initial Text

            Console.ReadKey();
        }
    }
}
