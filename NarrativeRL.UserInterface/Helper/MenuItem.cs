using System;

namespace NarrativeRL.UserInterface.Helper
{
    public class MenuItem
    {
        public string Text { get; set; }
        public int Index { set; get; }
        public event EventHandler<int> Select;
       
        public MenuItem(string text, int index, EventHandler<int> onSelect = null)
        {
            this.Text = text;
            this.Index = index;

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
                this.Select(sender, this.Index);
            }
        }
    }
}
