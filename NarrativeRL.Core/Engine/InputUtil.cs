using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SadConsole.Input;  // someday remove if decoupling is a priority, but has some nice helpers
using Microsoft.Xna.Framework.Input;

namespace NarrativeRL.Core.Engine
{
    public static class InputUtil
    {
        static StringBuilder InputKeys = new StringBuilder();

        /// <summary>
        /// Reads keystrokes until an ENTER key is encountered, returning the string of chars
        /// recieved prior to ENTER being pressed.  Any chars received after ENTER and before 
        /// this is processed will be lost.
        /// </summary>
        /// <returns>String with characters received prior to ENTER.</returns>
        public static string ReadLineFromKeyboard()
        {
            string ret = null;

            KeyboardInfo keyInfo = SadConsole.Engine.Keyboard;

            // loop through looking for ENTER key
            for (int i = 0; i < keyInfo.KeysReleased.Count; i++)
            {
                // if not enter, add to list of receved keystrokes
                if (keyInfo.KeysReleased[i].XnaKey != Keys.Enter)
                {
                    InputKeys.Append(keyInfo.KeysReleased[i].Character);
                }
                
                // ENTER pressed, process recieved keys and clear the buffer
                else
                {
                    ret = InputKeys.ToString();
                    InputKeys.Clear();
                }
            }
           
            return ret;
        }
    }
}
