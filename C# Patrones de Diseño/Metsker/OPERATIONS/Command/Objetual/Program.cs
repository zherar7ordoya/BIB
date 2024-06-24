using System;

namespace CommandPattern
{
    public delegate void CommandDelegate();

    public class CutCommand
    {
        private readonly TextEditor _editor;
        public CutCommand(TextEditor editor) => _editor = editor;
        public CommandDelegate GetCommand() => _editor.Cut;
    }

    public class CopyCommand
    {
        private readonly TextEditor _editor;
        public CopyCommand(TextEditor editor) => _editor = editor;
        public CommandDelegate GetCommand() => _editor.Copy;
    }

    public class PasteCommand
    {
        private readonly TextEditor _editor;
        public PasteCommand(TextEditor editor) => _editor = editor;
        public CommandDelegate GetCommand() => _editor.Paste;
    }

    public class TextEditor
    {
        public void Cut() => Console.WriteLine("Cutting text");
        public void Copy() => Console.WriteLine("Copying text");
        public void Paste() => Console.WriteLine("Pasting text");
    }

    public class Invoker
    {
        public event CommandDelegate CommandExecuted;
        public void SetCommand(CommandDelegate command) => CommandExecuted += command;
        public void ExecuteCommand()
        {
            CommandExecuted?.Invoke();
            CommandExecuted = null;  // Clear the command after execution
        }
    }

    class Program
    {
        static void Main()
        {
            TextEditor editor = new TextEditor();
            CutCommand cutCommand = new CutCommand(editor);
            CopyCommand copyCommand = new CopyCommand(editor);
            PasteCommand pasteCommand = new PasteCommand(editor);

            Invoker invoker = new Invoker();

            invoker.SetCommand(cutCommand.GetCommand());
            invoker.ExecuteCommand();  // Output: Cutting text

            invoker.SetCommand(copyCommand.GetCommand());
            invoker.ExecuteCommand();  // Output: Copying text

            invoker.SetCommand(pasteCommand.GetCommand());
            invoker.ExecuteCommand();  // Output: Pasting text

            Console.ReadKey();
        }
    }
}
