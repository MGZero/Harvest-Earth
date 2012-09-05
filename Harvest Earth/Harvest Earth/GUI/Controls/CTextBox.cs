using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Threading;

namespace Harvest_Earth.GUI.Controls
{
    public class CTextBox : CControl
    {
        protected SpriteFont _font;
        protected string _text = "";
        private string _viewableText = "";
        private int _cursorPosition = 0;
        private Vector2 _offSet = new Vector2(1, 2);
        protected bool _locked = false;
        protected int _length = 30;
        private Vector2 _textPosition;

        protected event CGlobals.textChange onTextChange = null;

        public CTextBox(int x, int y)
            : base()
        {
            _font = CGlobals.content.Load<SpriteFont>("Arial");
            _currentDraw = new Texture2D(CGlobals.GDManager.GraphicsDevice, 1, 1);
            _currentDraw.SetData(new Color[] { Color.White});
            _defaultSize = new Rectangle(20, 40, 100, 20);
            _textPosition = new Vector2(X, Y) + _offSet;

        }

        private void callOnTextChange()
        {
            if (onTextChange != null)
                onTextChange();
        }

        public override void update(GameTime gameTime)
        {
            if (_defaultSize.Contains(CInput.mouseX, CInput.mouseY))
            {
                if (CInput.getMouse1Release)
                {
                    _currentDraw = _controlDefault;
                    callOnClick(this);
                    callOnFocus(this);
                }
            }

            if (CInput.areKeysPressed)
            {

                if (gameTime.TotalGameTime.Milliseconds % 20 != 0)
                    return;

                if (CInput.keysPressed[0] == Microsoft.Xna.Framework.Input.Keys.Back)
                {
                    try
                    {
                        _text = _text.Remove(_text.Length - 1, 1);
                    }
                    catch (ArgumentOutOfRangeException) { return; }
                }
                else if (_text.Length < _length)
                {
                    string buffer = "0";

                    //check for special inputs
                    switch (CInput.keysPressed[0])
                    {
                        case Microsoft.Xna.Framework.Input.Keys.Space:
                            buffer = " ";
                            break;

                        default:
                            buffer = CInput.keysPressed[0].ToString();
                            break;
                    }

                    _text += buffer;
                }

                callOnTextChange();
            }
        }

        public override void draw(ref GraphicsDeviceManager manager)
        {
            base.draw(ref manager);

            CGlobals.mainBatch.DrawString(_font, _text, _textPosition, Color.Black);
        }
    }
}
