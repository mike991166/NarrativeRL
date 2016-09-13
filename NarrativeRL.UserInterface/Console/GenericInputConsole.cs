namespace NarrativeRL.UserInterface.Console
{
    public class GenericInputConsole : SadConsole.Consoles.Console
    {
        public GenericInputConsole(int width) : base(width, 2)
        {           
            SadConsole.Shapes.Line topBorder;

            topBorder = new SadConsole.Shapes.Line();
            topBorder.StartingLocation = new Microsoft.Xna.Framework.Point(0, 0);
            topBorder.EndingLocation = new Microsoft.Xna.Framework.Point(this.Width - 1, 0);
            topBorder.CellAppearance.GlyphIndex = 196;
            topBorder.UseEndingCell = false;
            topBorder.UseStartingCell = false;
            topBorder.Draw(this);

            // display input marker and move cursor to it.
            this.Print(0, 1, ">");
            this.VirtualCursor.Position = new Microsoft.Xna.Framework.Point(1, 1);
        }
    }
}
