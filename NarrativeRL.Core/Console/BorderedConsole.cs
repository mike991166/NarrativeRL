using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Consoles;

namespace NarrativeRL.Core.Console
{
    public class BorderedConsole : SadConsole.Consoles.Console
    {
        TextSurface borderSurface;

        public BorderedConsole(int width, int height) : base(width, height)
        {
            borderSurface = new TextSurface(width + 2, height + 2, base.textSurface.Font);
            var editor = new SurfaceEditor(borderSurface);

            SadConsole.Shapes.Box box = SadConsole.Shapes.Box.GetDefaultBox();
            box.Width = borderSurface.Width;
            box.Height = borderSurface.Height;
            box.Draw(editor);
        }

        public BorderedConsole(string text, int width, int height) : this(width, height)
        {
            Print(2, 0, text);
        }

        public override void Render()
        {
            base.Render();

            Renderer.Render(borderSurface, this.Position - new Microsoft.Xna.Framework.Point(1, 1));
        }
    }
}
