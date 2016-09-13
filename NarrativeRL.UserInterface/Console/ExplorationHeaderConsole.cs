using System;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationHeaderConsole : SadConsole.Consoles.Console
    {
        private string _headerText;
        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                this._headerText = value;
                this.RedrawConsole();
            }            
        }

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
      
        private void RedrawConsole()
        {
            this.Print(0, 0, HeaderText.Align(System.Windows.HorizontalAlignment.Center, this.Width));
        }
    }
}
