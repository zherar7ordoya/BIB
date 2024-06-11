using System;

namespace Ex04.Menus.Delegates
{
    public class LeafOperation : MenuItem
    {
        public delegate void MyOperationFunctionDelegate();

        public LeafOperation(string i_Title)
            : base(i_Title)
        {
        }

        public event MyOperationFunctionDelegate LeafChoosenOperation;

        public override void Operation(int i_Level)
        {
            OnLeafOperationChosen();
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
            Console.Clear();
        }

        protected virtual void OnLeafOperationChosen()
        {
            if (LeafChoosenOperation != null)
            {
                LeafChoosenOperation.Invoke();
            }
        }
    }
}