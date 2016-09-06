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
            this.Print(0, this.Height - 1, ">");
            this.VirtualCursor.Position = new Microsoft.Xna.Framework.Point(1, this.Height - 1);

            base.Render();
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            bool isProcessed = true;
            int selectedItem;

            // seems like all of this could go through MonoGame, and passed into GameWorld?

            if (info.KeysReleased.Count > 0)
            {
                if (info.IsKeyReleased(Keys.Enter))
                {
                    string enteredString = this.InputKeys.ToString();
                    this.InputKeys.Clear();

                    try
                    {
                        selectedItem = int.Parse(enteredString);
                        MenuItems[selectedItem].OnSelect(this);
                    }
                    catch (Exception ex)
                    {
                        Print(2, 22, String.Format("Please enter a number between 1 and {0}", (MenuItems.Count - 1).ToString()));
                    }
                }
                else if (!info.IsKeyReleased(Keys.Escape))
                {
                    for (int i = 0; i < info.KeysReleased.Count; i++)
                    {
                        this.InputKeys.Append(info.KeysReleased[i].Character);
                        this.VirtualCursor.Print(info.KeysReleased[i].Character.ToString());
                    }

                }
            }

            //base.ProcessKeyboard(info);

            /*
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
            */
            return isProcessed;
        }


    }
}
