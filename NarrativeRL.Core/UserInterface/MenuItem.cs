using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeRL.Core.UserInterface
{
    public class MenuItem
    {
        public string Text { get; set; }
        public event EventHandler<EventArgs> Select;
       
        public MenuItem(string text, EventHandler<EventArgs> onSelect = null)
        {
            this.Text = text;

            if (onSelect != null)
            {
                this.Select += onSelect;
            }
        }
        
        /*
        public void OnDraw(object sender, int itemIndex)
        {
            if (Draw != null)
                Draw(sender, itemIndex);
            else
                Console.WriteLine(itemIndex.ToString() + ") " + Title);
        }
        */

        public void OnSelect(object sender)
        {
            if (this.Select != null)
            {
                this.Select(sender, new EventArgs());
            }
        }
    }
}
