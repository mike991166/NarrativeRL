using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeRL.Core.Console
{
    public class ExplorationHeaderConsole: BorderedConsole
    {
        public string HeaderText { set; get; }

        public ExplorationHeaderConsole(int width) : base(width, 1) { }

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
