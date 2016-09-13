using SadConsole;
using SadConsole.Consoles;
using System.Collections.Generic;
using NarrativeRL.UserInterface.Helper;
using System;
using Microsoft.Xna.Framework;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationMainConsole : ScrollingConsole
    {
        TextSurface borderSurface;

        private string _narrativeText;

        public string NarrativeText
        {
            get { return this._narrativeText; }

            set
            {
                this._narrativeText = value;
                this.RedrawConsole();
            }
        }
        public List<MenuItem> MenuItems;

        public ExplorationMainConsole(int width, int height, string narrativeText, List<MenuItem> menuItems) : 
            base(width, height, 800)
        {
            // add borders
            borderSurface = new TextSurface(width + 2, height + 2, base.textSurface.Font);
            var editor = new SurfaceEditor(borderSurface);

            SadConsole.Shapes.Line rightBorder, bottomBorder;

            bottomBorder = new SadConsole.Shapes.Line();
            bottomBorder.StartingLocation = new Point(-1, borderSurface.Height - 1);
            bottomBorder.EndingLocation = new Point(borderSurface.Width - 1, borderSurface.Height - 1);
            bottomBorder.CellAppearance.GlyphIndex = 196;
            bottomBorder.UseEndingCell = false;
            bottomBorder.UseStartingCell = false;
            bottomBorder.Draw(editor);

            rightBorder = new SadConsole.Shapes.Line();
            rightBorder.StartingLocation = new Point(borderSurface.Width - 1, 0);
            rightBorder.EndingLocation = new Point(borderSurface.Width - 1, borderSurface.Height - 1);
            rightBorder.CellAppearance.GlyphIndex = 179;
            rightBorder.UseEndingCell = true;
            rightBorder.EndingCellAppearance.GlyphIndex = 193;
            rightBorder.UseStartingCell = true;
            rightBorder.StartingCellAppearance.GlyphIndex = 194;
            rightBorder.Draw(editor);

            // assign inputs
            this.NarrativeText = narrativeText;
            this.MenuItems = menuItems;
        }

        public override void Render()
        {
            base.Render();
            Renderer.Render(borderSurface, this.Position - new Point(1, 1));            
        }

        private void RedrawConsole()
        {
            if (this.NarrativeText != null)
            {
                this.VirtualCursor.Print(this.NarrativeText);

                if (this.MenuItems != null)
                {

                }
                else
                {
                    ColoredString prompt = new ColoredString(
                        "< Press any key >".Align(System.Windows.HorizontalAlignment.Center, 
                        this.Width),
                        Color.LightBlue, 
                        Color.Black);
                    this.VirtualCursor.Down(2);
                    this.VirtualCursor.CarriageReturn();
                    this.VirtualCursor.Print(prompt);
                }
            }            
        }
    }

}
