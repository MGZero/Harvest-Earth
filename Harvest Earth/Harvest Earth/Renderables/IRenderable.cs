using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Harvest_Earth.Renderables
{
    interface IRenderable
    {
        void draw(ref GraphicsDeviceManager manager);
    }
}
