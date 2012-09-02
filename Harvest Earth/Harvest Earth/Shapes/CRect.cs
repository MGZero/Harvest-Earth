using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Harvest_Earth.Shapes
{
    class CRect : Renderables.IRenderable
    {
        private Texture2D _dummy;
        private Rectangle _internalRect;

        public CRect(int x, int y, int width, int height, Color color)
        {
            _dummy = new Texture2D(CGlobals.GDManager.GraphicsDevice, 1, 1);
            _dummy.SetData(new Color[] { color});

            _internalRect = new Rectangle(x, y, width, height);
        }

        ~CRect()
        {
            _dummy.Dispose();
            _dummy = null;
        }

        public void draw(ref GraphicsDeviceManager manager)
        {
            CGlobals.mainBatch.Draw(_dummy, _internalRect, Color.White);
        }

        public Vector2 position
        {
            get
            {
                return new Vector2(_internalRect.X, _internalRect.Y);
            }
            set
            {
                _internalRect.X = (int)value.X;
                _internalRect.Y = (int)value.Y;
            }
        }
    }
}
