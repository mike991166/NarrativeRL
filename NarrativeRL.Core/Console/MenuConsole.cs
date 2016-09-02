using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SadConsole;
using SadConsole.Input;
using NarrativeRL.Core.UserInterface;

namespace NarrativeRL.Core.Console
{
    public class MenuConsole: SadConsole.Consoles.Console
    {
        private List<MenuItem> MenuItems;

        public MenuConsole(int width, int height, List<MenuItem> items) : base(width, height)
        {
            this.MenuItems = items;
            this.CanUseKeyboard = true;
        }

        public override void Render()
        {
            // display menu items
            for (int i = 0; i < this.MenuItems.Count(); i++)
            {
                if (i > 0)
                {
                    this.Print(0, i, (i.ToString() + " - " + this.MenuItems[i].Text).Align(System.Windows.HorizontalAlignment.Left, this.Width));
                }
                else
                {
                    this.Print(0, i, (this.MenuItems[i].Text).Align(System.Windows.HorizontalAlignment.Stretch, this.Width));
                }
            }

            base.Render();
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            bool isProcessed = false;
            int selectedItem;

            if (info.KeysPressed.Count > 0)
            {
                try
                {                    
                    selectedItem = int.Parse(info.KeysPressed[0].Character.ToString());
                    MenuItems[selectedItem]?.OnSelect(this);
                    base.ProcessKeyboard(info);
                    isProcessed = true;
                }
                catch (Exception ex)
                {
                    Print(2, 22, String.Format("Please enter a number between 1 and {0}", (MenuItems.Count - 1).ToString()));
                }
            }

            return isProcessed;
        }


    }
}
