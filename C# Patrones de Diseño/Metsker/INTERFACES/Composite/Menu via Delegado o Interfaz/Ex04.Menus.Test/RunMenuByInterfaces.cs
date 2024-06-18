using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public static class RunMenuByInterfaces
    {
        public static void ActiveMenu()
        {
            MainMenu myMainMenu = new MainMenu("Interface Main Menu");
            LeafOperation firstItem = new LeafOperation("Count Captials", new countCapitals());
            LeafOperation secondItem = new LeafOperation("Show Version", new showVersion());
            LeafOperation thirdItem = new LeafOperation("Show Time", new showTime());
            LeafOperation fourthItem = new LeafOperation("Show Date", new showDate());
            MenuNode firstSubMenu = new MenuNode("Version and Digits", 2);
            MenuNode secondSubMenu = new MenuNode("Time / Date Show", 2);

            firstSubMenu.AddMenuItems(firstItem, secondItem);
            secondSubMenu.AddMenuItems(thirdItem, fourthItem);
            myMainMenu.AddItemsToMenu(firstSubMenu, secondSubMenu);
            myMainMenu.Show();
        }

        private class countCapitals : IOperation
        {
            void IOperation.OperationFromSystem()
            {
                TestMethods.CountCapitals();
            }
        }

        private class showVersion : IOperation
        {
            void IOperation.OperationFromSystem()
            {
                TestMethods.ShowVersion();
            }
        }

        private class showDate : IOperation
        {
            void IOperation.OperationFromSystem()
            {
                TestMethods.ShowDate();
            }
        }

        private class showTime : IOperation
        {
            void IOperation.OperationFromSystem()
            {
                TestMethods.ShowTime();
            }
        }
    }
}