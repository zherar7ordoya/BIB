using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public static class RunMenuByDelegates
    {
        public static void ActiveMenu()
        {
            MainMenu myMainMenu = new MainMenu("Delegate Main Menu");
            LeafOperation firstItem = new LeafOperation("Count Captials");
            LeafOperation secondItem = new LeafOperation("Show Version");
            MenuNode firstSubMenu = new MenuNode("Version and Digits", 2);
            LeafOperation thirdItem = new LeafOperation("Show Time");
            LeafOperation fourthItem = new LeafOperation("Show Date");
            MenuNode secondSubMenu = new MenuNode("Time / Date Show", 2);

            firstItem.LeafChoosenOperation += TestMethods.CountCapitals;
            secondItem.LeafChoosenOperation += TestMethods.ShowVersion;
            thirdItem.LeafChoosenOperation += TestMethods.ShowTime;
            fourthItem.LeafChoosenOperation += TestMethods.ShowDate;
            firstSubMenu.AddMenuItems(firstItem, secondItem);
            secondSubMenu.AddMenuItems(thirdItem, fourthItem);
            myMainMenu.AddItemsToMenu(firstSubMenu, secondSubMenu);
            myMainMenu.Show();
        }
    }
}
