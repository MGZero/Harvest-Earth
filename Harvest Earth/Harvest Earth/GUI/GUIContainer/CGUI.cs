using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harvest_Earth.GUI.Controls;
using Microsoft.Xna.Framework;

namespace Harvest_Earth.GUI.GUIContainer
{
    public static class CGUI
    {
        public static Dictionary<string,CControl> controls = new Dictionary<string,CControl>();

        //put all event handlers here

        //register them here
        public static void register()
        {
            controls.Add("TestButton", new CButton(20, 20));
            controls.Add("TestText", new CTextBox(20, 40));
        }

        public static void runThisShit(GameTime gameTime)
        {
            foreach (KeyValuePair<string, CControl> kvp in controls)
                kvp.Value.update(gameTime);
        }

        public static void drawThisShit()
        {
            foreach (KeyValuePair<string, CControl> kvp in controls)
                kvp.Value.draw(ref CGlobals.GDManager);
        }

    }
}
