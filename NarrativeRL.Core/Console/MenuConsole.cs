using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using SadConsole;
using SadConsole.Input;
using NarrativeRL.Core.UserInterface;

namespace NarrativeRL.Core.Console
{
    public class MenuConsole: SadConsole.Consoles.Console
    {
        private string Title;
        private string Introduction;
        private List<MenuItem> MenuItems;

        private StringBuilder InputKeys = new StringBuilder();

        public MenuConsole(int width, int height, string title, string introduction, List<MenuItem> items) : base(width, height)
        {            
            this.Title = title;
            this.Introduction = introduction;
            this.MenuItems = items;            
            this.InputKeys = new StringBuilder();

            this.CanUseKeyboard = true;
        }
        
        public override void Render()
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
            for (int i = 0; i < this.MenuItems.Count(); i++)
            {
                this.Print(0, 5 + i, (String.Format("[{0}] {1}", i, this.MenuItems[i].Text)).Align(System.Windows.HorizontalAlignment.Left, this.Width));               
            }

            // display input marker and move cursor to it.
            this.Print(0, this.Height - 2, ">");
            this.VirtualCursor.Position = new Microsoft.Xna.Framework.Point(1, this.Height - 2);

            base.Render();
        }
    }
}
