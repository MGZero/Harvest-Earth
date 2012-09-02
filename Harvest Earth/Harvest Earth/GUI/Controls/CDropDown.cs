using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Harvest_Earth.GUI.Controls
{
    class CDropDown : CTextBox
    {
        private List<string> _items = new List<string>();
        private bool _drop = false;
        private Rectangle _dropDownSize;
        private Texture2D _dropTex;

        public CDropDown(int x, int y)
            : base(x, y)
        { }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);

            if (_defaultSize.Contains(CInput.mouseX, CInput.mouseY))
            {
                if (CInput.getMouse1Release)
                    _dropDown();
            }
            else
            {
                if (CInput.getMouse1Release)
                    _drop = false;
            }
        }

        public override void draw(ref GraphicsDeviceManager manager)
        {
            base.draw(ref manager);

            int YPos = 0;

            if (_drop)
            {
                CGlobals.mainBatch.Draw(_dropTex, _dropDownSize, Color.White);

                foreach (string item in _items)
                {
                    CGlobals.mainBatch.DrawString(_font, item, new Vector2(position.X, position.Y + YPos + 2),Color.White);
                    YPos += 5;
                }
            }
        }

        private void _dropDown()
        {
            _drop = true;
        }

        public void add(object item)
        {
            _items.Add(item.ToString());
            _dropDownSize.Height += 3;
        }
    }
}
