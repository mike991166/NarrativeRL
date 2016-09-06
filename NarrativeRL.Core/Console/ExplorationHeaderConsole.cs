using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;

namespace NarrativeRL.Core.Console
{
    public class ExplorationHeaderConsole: SadConsole.Consoles.Console
    {
        public string HeaderText { set; get; }

        public ExplorationHeaderConsole(int width) : base(width, 2)
        {
            SadConsole.Shapes.Line line = new SadConsole.Shapes.Line();
            line.StartingLocation = new Microsoft.Xna.Framework.Point(0, 1);
            line.EndingLocation = new Microsoft.Xna.Framework.Point(width - 1, 1);
            line.CellAppearance.GlyphIndex = 196;
            line.UseEndingCell = false;
            line.UseStartingCell = false;
            line.Draw(this);
        }

        public ExplorationHeaderConsole(int width, string text) : this(width)
        {
            this.HeaderText = text;            
        }

        public override void Render()
        {
            base.Render();
            this.Print(0, 0, HeaderText.Align(System.Windows.HorizontalAlignment.Center, this.Width));            
        }
    }
}
