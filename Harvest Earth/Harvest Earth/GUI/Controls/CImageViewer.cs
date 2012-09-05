using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace Harvest_Earth.GUI.Controls
{
    class CImageViewer : CControl
    {
        private Texture2D _imageToDraw;
        private Rectangle _imageDrawLocation;

        public CImageViewer(int x, int y, int width, int height, string imagePath)
        {
            if (imagePath.Substring(imagePath.IndexOf("."), 4) != ".png")
                throw new BadImageFormatException("The image " + imagePath + " was not in png format.");
            
            position = new Vector2(x, y);
            StreamReader reader = new StreamReader(imagePath);

            _currentDraw = new Texture2D(CGlobals.GDManager.GraphicsDevice, 1, 1);
            _currentDraw.SetData(new Color[] { Color.White });
            _imageToDraw = Texture2D.FromStream(CGlobals.GDManager.GraphicsDevice, reader.BaseStream);
            reader.Close();

            //image will be top-left justified
            _defaultSize = new Rectangle(x, y, width, height);
            _imageDrawLocation = new Rectangle(x, y, 
                                               _imageToDraw.Width > width ? width : _imageToDraw.Width,
                                               _imageToDraw.Height > height ? height : _imageToDraw.Height);
        }

        public override void update(GameTime gameTime)
        {
            if (_defaultSize.Contains(CInput.mouseX, CInput.mouseY))
            {
                if (CInput.getMouse1Release)
                {
                    _currentDraw = _controlDefault;
                    callOnClick(this);
                }
            }
        }

        public override void draw(ref GraphicsDeviceManager manager)
        {
            base.draw(ref manager);

            if (_imageToDraw != null)
                CGlobals.mainBatch.Draw(_imageToDraw, _imageDrawLocation, Color.White);
        }
    }
}
