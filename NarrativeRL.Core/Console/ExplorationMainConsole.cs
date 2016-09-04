using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SadConsole.Consoles;

using NarrativeRL.Core.UserInterface;

namespace NarrativeRL.Core.Console
{
    public class ExplorationMainConsole : BorderedConsole
    {
        public string NarrativeText { set; get; }
        public List<MenuItem> MenuItems { set; get; }

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
