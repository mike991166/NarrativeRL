using Microsoft.Xna.Framework.Input;
using SadConsole.Input;
using System.Text;

namespace NarrativeRL.UserInterface
{
    public static class KeyboardInputHandler
    {
        public delegate string InputReader();

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

        /// <summary>
        /// Reads all keystrokes since last time called.  Used when ENTER is not needed or "Press Any Key"
        /// type prompt is in use.
        /// </summary>
        /// <returns>String with characters since last time called.</returns>
        public static string ReadAnyKeyFromKeyboard()
        {
            string ret = null;

            KeyboardInfo keyInfo = SadConsole.Engine.Keyboard;

            // loop through building string
            for (int i = 0; i < keyInfo.KeysReleased.Count; i++)
            {
                InputKeys.Append(keyInfo.KeysReleased[i].Character);
            }

            if (InputKeys.Length > 0)
            {
                ret = InputKeys.ToString();
                InputKeys.Clear();
            }

            return ret;
        }

        /// <summary>
        /// Returns a dummy string for states that do not actually require an input.
        /// </summary>
        /// <returns>Dummy string.</returns>
        public static string GenerateKey()
        {
            return "foo";
        }
    }
}
