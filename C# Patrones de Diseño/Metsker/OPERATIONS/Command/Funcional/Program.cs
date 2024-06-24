using System;
using System.Collections.Generic;

namespace CommandPattern
{
    public interface ICommand
    {
        TextEditorState Execute(TextEditorState state);
        TextEditorState Undo(TextEditorState state);
    }

    public class CutCommand : ICommand
    {
        private string _backup;

        public TextEditorState Execute(TextEditorState state)
        {
            _backup = state.Text;
            return new TextEditorState("");
        }

        public TextEditorState Undo(TextEditorState state)
        {
            return new TextEditorState(_backup);
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

    public class Invoker
    {
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public TextEditorState ExecuteCommand(ICommand command, TextEditorState state)
        {
            var newState = command.Execute(state);
            _commandHistory.Push(command);
            return newState;
        }

        public TextEditorState Undo(TextEditorState state)
        {
            if (_commandHistory.Count > 0)
            {
                var command = _commandHistory.Pop();
                return command.Undo(state);
            }
            return state;
        }
    }

    class Program
    {
        static void Main()
        {
            TextEditorState state = new TextEditorState("Initial Text");
            ICommand cutCommand = new CutCommand();
            Invoker invoker = new Invoker();

            Console.WriteLine(state.Text); // Output: Initial Text

            state = invoker.ExecuteCommand(cutCommand, state); // Cutting text
            Console.WriteLine(state.Text); // Output: ""

            state = invoker.Undo(state); // Undo cutting
            Console.WriteLine(state.Text); // Output: Initial Text

            Console.ReadKey();
        }
    }
}
