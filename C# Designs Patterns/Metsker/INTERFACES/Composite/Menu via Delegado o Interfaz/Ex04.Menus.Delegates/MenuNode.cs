using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuNode : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems;
        private readonly int r_CurrentNodeLevel;
        private bool m_IsMainMenu;

        public MenuNode(string i_Title, int i_Level)
            : base(i_Title)
        {
            r_CurrentNodeLevel = i_Level;
            m_IsMainMenu = i_Level == DefaultProperties.FirstLevelIndex;
            r_MenuItems = new List<MenuItem>();
        }

        public void ShowCurrentMenu(int i_Level)
        {
            int inputChoice;
            bool exitOrBackChoice = false;
            while (!exitOrBackChoice)
            {
                printCurrentMenu(i_Level);
                inputChoice = askForMenuChoice();
                Console.Clear();
                if (inputChoice > DefaultProperties.BackOrExitIndex - 1)
                {
                    r_MenuItems[inputChoice].Operation(i_Level + 1);
                }

                exitOrBackChoice = inputChoice == DefaultProperties.BackOrExitIndex - 1;
            }
        }

        public override void Operation(int i_Level)
        {
            ShowCurrentMenu(i_Level);
        }

        public void AddMenuItems(params MenuItem[] i_Items)
        {
            foreach (MenuItem menuItem in i_Items)
            {
                r_MenuItems.Add(menuItem);
            }
        }

        private int askForMenuChoice()
        {
            bool validChoice = false;
            int resultChoice = 0;

            Console.WriteLine("Please choose an option from current menu: ");
            while (!validChoice)
            {
                string stringChoice = Console.ReadLine();
                if (int.TryParse(stringChoice, out resultChoice))
                {
                    --resultChoice;
                    if (resultChoice < r_MenuItems.Count)
                    {
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Index does not exist in menu, Please Choose Again!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Format Please Choose Again");
                }
            }

            return resultChoice;
        }

        private void printCurrentMenu(int i_Level)
        {
            Console.WriteLine("Current Menu in level {0}", i_Level);
            Console.WriteLine(Title);
            Console.Write(Environment.NewLine);
            if (m_IsMainMenu == true)
            {
                Console.WriteLine("{0}.{1}", DefaultProperties.BackOrExitIndex, DefaultProperties.Exit);
            }
            else
            {
                Console.WriteLine("{0}.{1}", DefaultProperties.BackOrExitIndex, DefaultProperties.Back);
            }

            for (int i = 0; i < r_MenuItems.Count;  ++i)
            {
                Console.WriteLine("{0}.{1}", i + 1, r_MenuItems[i].Title);
            }
        }
    }
}