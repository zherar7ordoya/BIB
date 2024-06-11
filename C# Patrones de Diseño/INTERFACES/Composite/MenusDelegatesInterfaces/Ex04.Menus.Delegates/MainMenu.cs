namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly MenuNode r_RootMenu;

        public MainMenu(string i_Title)
        {
            r_RootMenu = new MenuNode(i_Title, DefaultProperties.FirstLevelIndex);
        }

        public void Show()
        {
            r_RootMenu.ShowCurrentMenu(DefaultProperties.FirstLevelIndex);
        }

        public void AddItemsToMenu(params MenuItem[] i_ItemsToAdd)
        {
            r_RootMenu.AddMenuItems(i_ItemsToAdd);
        }
    }
}