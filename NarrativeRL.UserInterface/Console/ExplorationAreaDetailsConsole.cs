using Microsoft.Xna.Framework;
using SadConsole.Consoles;
using System;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationAreaDetailsConsole: SadConsole.Consoles.Console
    {
        TextSurface borderSurface;

        private string _terrainType;
        public string TerrainType
        {
            get { return _terrainType; }
            set
            {
                this._terrainType = value;
                this.RedrawConsole();
            }
        }

        public ExplorationAreaDetailsConsole(int width, int height) : base(width, height) { }

        public ExplorationAreaDetailsConsole(int width, int height, string terrainType) : base(width, height)
        {
            this.TerrainType = terrainType;

            borderSurface = new TextSurface(width + 1, height + 2, base.textSurface.Font);
            var editor = new SurfaceEditor(borderSurface);

            SadConsole.Shapes.Line bottomBorder;

            bottomBorder = new SadConsole.Shapes.Line();
            bottomBorder.StartingLocation = new Point(0, borderSurface.Height - 1);
            bottomBorder.EndingLocation = new Point(borderSurface.Width - 1, borderSurface.Height - 1);
            bottomBorder.CellAppearance.GlyphIndex = 196;
            bottomBorder.UseEndingCell = false;
            bottomBorder.UseStartingCell = false;
            bottomBorder.Draw(editor);
        }

        public override void Render()
        {
            base.Render();
            Renderer.Render(borderSurface, this.Position - new Microsoft.Xna.Framework.Point(1, 1));
        }

        private void RedrawConsole()
        {
            this.VirtualCursor.Position = new Point(0, 0);
            this.VirtualCursor.Print(String.Format("Terrain: {0}", this.TerrainType));
        }
    }
}
