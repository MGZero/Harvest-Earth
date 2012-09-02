using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Harvest_Earth.GUI.Controls
{
    class CButton : CControl
    {
        public CButton(int x, int y)
        {
            _defaultSize = new Microsoft.Xna.Framework.Rectangle(x, y, 16, 16);
            _controlDefault = CGlobals.content.Load<Texture2D>("ArrowRight");
            _controlState0 = CGlobals.content.Load<Texture2D>("ArrowRightPressed");

            _currentDraw = _controlDefault;
            position = new Vector2(x, y);
        }

        public override void update(GameTime gameTime)
        {
            if (_defaultSize.Contains(CInput.mouseX, CInput.mouseY))
            {
                if (CInput.getMouse1Down)
                {
                    _currentDraw = _controlState0;
                }
                else if (CInput.getMouse1Release)
                {
                    _currentDraw = _controlDefault;
                    callOnClick(this);
                }
            }
        }
    }
}
