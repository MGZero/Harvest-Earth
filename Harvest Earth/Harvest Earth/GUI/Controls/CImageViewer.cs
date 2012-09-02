using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;


namespace Harvest_Earth.GUI.Controls
{
    abstract class  CImageViewer : CControl
    {
        public CImageViewer(int x, int y, int width, int height, string imagePath)
        {
            if (imagePath.Substring(imagePath.IndexOf("."), 4) == ".png")
            

            position = new Vector2(x, y);
            StreamReader reader = new StreamReader(imagePath);
            _currentDraw = Texture2D.FromStream(CGlobals.GDManager.GraphicsDevice, reader.BaseStream);
            reader.Close();

        }
        public abstract override void update(GameTime gameTime);
    }
}
