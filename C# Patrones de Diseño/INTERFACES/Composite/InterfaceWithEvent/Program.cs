using System;
using System.Collections.Generic;

namespace InterfaceWithEvent
{
    // Interface definition
    public interface IMenuElement
    {
        void AddMenuElement(MenuElement menuToAdd);
        void RemoveMenuElement(MenuElement menuToRemove);
        void Activate();
        MenuElement this[int index] { get; }

        // Evento que se dispara cuando un elemento de menú es activado.
        event EventHandler Activated;
    }

    // MenuElement class definition
    public class MenuElement : IMenuElement
    {
        readonly List<MenuElement> _menuElements;
        public event EventHandler Activated;

        public MenuElement()
        {
            _menuElements = new List<MenuElement>();
        }

        public void AddMenuElement(MenuElement menuToAdd)
        {
            _menuElements.Add(menuToAdd);
        }

        public void RemoveMenuElement(MenuElement menuToRemove)
        {
            _menuElements.Remove(menuToRemove);
        }

        public void Activate()
        {
            // Some operations here
            Console.WriteLine("MenuElement activated.");

            // Raising the event
            OnActivated();
        }

        // Método protegido que dispara el evento Activated.
        protected virtual void OnActivated()
        {
            Activated?.Invoke(this, EventArgs.Empty);
        }

        public MenuElement this[int index]
        {
            get
            {
                if (index < 0 || index >= _menuElements.Count)
                    throw new IndexOutOfRangeException("Index out of range");
                return _menuElements[index];
            }
        }
    }

    // Example usage
    class Program
    {
        static void Main()
        {
            MenuElement mainMenu = new MenuElement();
            MenuElement subMenu1 = new MenuElement();
            MenuElement subMenu2 = new MenuElement();

            mainMenu.AddMenuElement(subMenu1);
            mainMenu.AddMenuElement(subMenu2);

            subMenu1.Activated += OnSubMenuActivated;
            subMenu2.Activated += OnSubMenuActivated;

            Console.WriteLine("Activating subMenu1...");
            subMenu1.Activate();

            Console.WriteLine("Activating subMenu2...");
            subMenu2.Activate();

            Console.ReadLine();
        }

        static void OnSubMenuActivated(object sender, EventArgs e)
        {
            Console.WriteLine("A submenu was activated.");
        }
    }
}
