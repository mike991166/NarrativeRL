using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NarrativeRL.UserInterface.Helper;

namespace NarrativeRL.UserInterface.Console
{
    public class MenuConsole: SadConsole.Consoles.Console
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                this._title = value;
                this.RedrawConsole();
            }

        }

        private string _introduction;
        public  string Introduction
        {
            get { return _introduction; }
            set
            {
                this._introduction = value;
                this.RedrawConsole();
            }
        }

        private List<MenuItem> _menuItems;
        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                this._menuItems = value;
                this.RedrawConsole();
            }
        }

        public MenuConsole(int width, int height, string title, string introduction, List<MenuItem> items) : base(width, height)
        {            
            this.Title = title;
            this.Introduction = introduction;
            this.MenuItems = items;            

            this.CanUseKeyboard = true;
        }

        private void RedrawConsole()
        {
            if (!String.IsNullOrEmpty(this.Title))
            {
                this.Print(0, 0, this.Title.Align(System.Windows.HorizontalAlignment.Center, this.Width));
            }

            if (!String.IsNullOrEmpty(this.Introduction))
            {
                this.Print(0, 3, this.Introduction.Align(System.Windows.HorizontalAlignment.Center, this.Width));
            }

            // display menu items
            if (this.MenuItems != null)
            {
                for (int i = 0; i < this.MenuItems.Count(); i++)
                {
                    this.Print(0, 5 + i, (String.Format("[{0}] {1}", i, this.MenuItems[i].Text)).Align(System.Windows.HorizontalAlignment.Left, this.Width));
                }
            }

            // display input marker and move cursor to it.
            this.Print(0, this.Height - 2, ">");
            this.VirtualCursor.Position = new Microsoft.Xna.Framework.Point(1, this.Height - 2);
        }
    }
}
