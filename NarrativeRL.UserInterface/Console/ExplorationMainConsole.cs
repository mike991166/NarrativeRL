using SadConsole.Consoles;
using System.Collections.Generic;
using NarrativeRL.UserInterface.Helper;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationMainConsole : SadConsole.Consoles.Console
    {
        TextSurface borderSurface;

        public string NarrativeText;
        public List<MenuItem> MenuItems;

        public ExplorationMainConsole(int width, int height, string narrativeText, List<MenuItem> menuItems) : 
            base(width, height)
        {
            borderSurface = new TextSurface(width + 2, height + 1, base.textSurface.Font);
            var editor = new SurfaceEditor(borderSurface);

            SadConsole.Shapes.Line rightBorder, bottomBorder;

            bottomBorder = new SadConsole.Shapes.Line();
            bottomBorder.StartingLocation = new Microsoft.Xna.Framework.Point(-1, borderSurface.Height - 1);
            bottomBorder.EndingLocation = new Microsoft.Xna.Framework.Point(borderSurface.Width - 1, borderSurface.Height - 1);
            bottomBorder.CellAppearance.GlyphIndex = 196;
            bottomBorder.UseEndingCell = false;
            bottomBorder.UseStartingCell = false;
            bottomBorder.Draw(editor);

            rightBorder = new SadConsole.Shapes.Line();
            rightBorder.StartingLocation = new Microsoft.Xna.Framework.Point(borderSurface.Width - 1, 0);
            rightBorder.EndingLocation = new Microsoft.Xna.Framework.Point(borderSurface.Width - 1, borderSurface.Height - 1);
            rightBorder.CellAppearance.GlyphIndex = 179;
            rightBorder.UseEndingCell = true;
            rightBorder.EndingCellAppearance.GlyphIndex = 193;
            rightBorder.UseStartingCell = true;
            rightBorder.StartingCellAppearance.GlyphIndex = 194;
            rightBorder.Draw(editor);

            this.NarrativeText = narrativeText;
            this.MenuItems = menuItems;
        }

        public override void Render()
        {
            base.Render();
            Renderer.Render(borderSurface, this.Position - new Microsoft.Xna.Framework.Point(1, 1));

            Cursor consoleCursor = new Cursor(this);
            consoleCursor.Print(this.NarrativeText);
        }
    }

}
