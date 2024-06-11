using System;

namespace Ex04.Menus.Interfaces
{
    public class LeafOperation : MenuItem
    {
        private readonly IOperation r_OperationItem;

        public LeafOperation(string i_Title, IOperation i_OperationItem)
            : base(i_Title)
        {
            r_OperationItem = i_OperationItem;
        }

        public override void Operation(int i_Level)
        {
            r_OperationItem.OperationFromSystem();
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}