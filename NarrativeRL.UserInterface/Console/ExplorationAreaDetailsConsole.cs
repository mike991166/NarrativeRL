using SadConsole.Consoles;
using System;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationAreaDetailsConsole: SadConsole.Consoles.Console
    {
        TextSurface borderSurface;

        public string TerrainType;

        public ExplorationAreaDetailsConsole(int width, int height) : base(width, height) { }

        public ExplorationAreaDetailsConsole(int width, int height, string terrainType) : base(width, height)
        {
            this.TerrainType = terrainType;

            borderSurface = new TextSurface(width + 1, height + 1, base.textSurface.Font);
            var editor = new SurfaceEditor(borderSurface);

            SadConsole.Shapes.Line bottomBorder;

            bottomBorder = new SadConsole.Shapes.Line();
            bottomBorder.StartingLocation = new Microsoft.Xna.Framework.Point(0, borderSurface.Height - 1);
            bottomBorder.EndingLocation = new Microsoft.Xna.Framework.Point(borderSurface.Width - 1, borderSurface.Height - 1);
            bottomBorder.CellAppearance.GlyphIndex = 196;
            bottomBorder.UseEndingCell = false;
            bottomBorder.UseStartingCell = false;
            bottomBorder.Draw(editor);

        }

        public override void Render()
        {
            base.Render();
            Renderer.Render(borderSurface, this.Position - new Microsoft.Xna.Framework.Point(1, 1));

            Cursor consoleCursor = new Cursor(this);
            consoleCursor.Print(String.Format("Terrain: {0}", this.TerrainType));
        }
    }
}
