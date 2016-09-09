using SadConsole.Consoles;
using System.Collections.Generic;
using NarrativeRL.UserInterface.Helper;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationMainConsole : BorderedConsole
    {
        public string NarrativeText;
        public List<MenuItem> MenuItems;

        public ExplorationMainConsole(int width, int height, string narrativeText, List<MenuItem> menuItems) : 
            base(width, height)
        {
            this.NarrativeText = narrativeText;
            this.MenuItems = menuItems;
        }

        public override void Render()
        {
            base.Render();

            Cursor consoleCursor = new Cursor(this);
            consoleCursor.Print(this.NarrativeText);
        }
    }

}
