using SadConsole.Consoles;
using System;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationAreaDetailsConsole: BorderedConsole
    {
        public string TerrainType;

        public ExplorationAreaDetailsConsole(int width, int height) : base(width, height) { }

        public ExplorationAreaDetailsConsole(int width, int height, string terrainType) : base(width, height)
        {
            this.TerrainType = terrainType;
        }

        public override void Render()
        {
            base.Render();

            Cursor consoleCursor = new Cursor(this);
            consoleCursor.Print(String.Format("Terrain: {0}", this.TerrainType));
        }
    }
}
