using System;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationHeaderConsole : SadConsole.Consoles.Console
    {
        private string _headerText;
        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                this._headerText = value;
                this.RedrawConsole();
            }            
        }

        private int _totalSteps;
        public int TotalSteps
        {
            get { return _totalSteps; }
            set
            {
                this._totalSteps = value;
                this.RedrawConsole();
            }
        }

        private int _currentStep;
        public int CurrentStep
        {
            get { return _currentStep; }
            set
            {
                this._currentStep = value;
                this.RedrawConsole();
            }
        }

        public ExplorationHeaderConsole(int width) : base(width, 2)
        {
            SadConsole.Shapes.Line line = new SadConsole.Shapes.Line();
            line.StartingLocation = new Microsoft.Xna.Framework.Point(0, 1);
            line.EndingLocation = new Microsoft.Xna.Framework.Point(width - 1, 1);
            line.CellAppearance.GlyphIndex = 196;
            line.UseEndingCell = false;
            line.UseStartingCell = false;
            line.Draw(this);
        }

        public ExplorationHeaderConsole(int width, string text) : this(width)
        {
            this.HeaderText = text;            
        }
      
        private void RedrawConsole()
        {
            string title;

            if (TotalSteps > 0)
            {
                title = String.Format("{0} [{1}/{2}]", this.HeaderText, CurrentStep.ToString("D2"), TotalSteps.ToString("D2"));
            }
            else
            {
                title = this.HeaderText;
            }

            this.Print(0, 0, title.Align(System.Windows.HorizontalAlignment.Center, this.Width));
        }
    }
}
