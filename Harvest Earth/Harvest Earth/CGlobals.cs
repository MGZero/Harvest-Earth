using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Harvest_Earth
{
    public static class CGlobals
    {
        public static GraphicsDeviceManager GDManager;
        public static SpriteBatch mainBatch;
        public static ContentManager content;

        public delegate void click(object sender);
        public delegate void release(object sender);
        public delegate void paint();
        public delegate void textChange();
        public delegate void focus(object sender);
    }
}
