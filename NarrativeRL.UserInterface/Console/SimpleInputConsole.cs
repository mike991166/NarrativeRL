using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using SadConsole.Readers.REXPaint;
using SadConsole.Consoles;


namespace NarrativeRL.UserInterface.Console
{
    public class SimpleInputConsole: SadConsole.Consoles.Console
    {
        public SimpleInputConsole(int width, int height) : base(width, height)
        {
            Image InputTemplate;
            string inputPath;

            // Load REXPaint Template
            inputPath = ConsoleConstants.RexPaintFilePath + "InputFrame.xp";

            using (FileStream fs = File.OpenRead(inputPath))
            {
                InputTemplate = Image.Load(fs);
            }

            // Write REXPaint image to this consoles surface
            this.TextSurface = InputTemplate.ToTextSurface();

            this.CanUseKeyboard = true;
        }

    }
}
