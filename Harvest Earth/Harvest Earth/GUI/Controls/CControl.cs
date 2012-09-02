using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Harvest_Earth.GUI.Controls
{
    abstract public class CControl : Renderables.IRenderable
    {
        protected Texture2D _controlDefault = null;
        protected Texture2D _controlState0 = null;
        protected Texture2D _controlState1 = null;
        protected Texture2D _currentDraw = null;
        protected Rectangle _defaultSize;

        protected event CGlobals.click onClick = null;
        protected event CGlobals.release onRelease = null;
        private event CGlobals.paint onPaint = null;
        private event CGlobals.focus onFocus = null;
        public Vector2 position = Vector2.Zero;

        private void callOnPaint()
        {
            try
            {
                onPaint();
            }
            catch (NullReferenceException) { return; }
        }

        public int X
        {
            get
            {
                return _defaultSize.X;
            }
            set
            {
                _defaultSize.X = value;
            }
        }

        public int Y
        {
            get
            {
                return _defaultSize.Y;
            }
            set
            {
                _defaultSize.Y = value;
            }
        }

        protected void callOnClick(object sender)
        {
            try
            {
                onClick(sender);
            }
            catch (NullReferenceException) { return; }
        }

        protected void callOnFocus(object sender)
        {
            try
            {
                onFocus(sender);
            }
            catch (NullReferenceException) { return; }
        }


        public void RegisterClick(CGlobals.click clickHandler)
        {
            onClick += clickHandler;
        }

        public void RegisterPaint(CGlobals.paint paintHandler)
        {
            onPaint += paintHandler;
        }

        public void RegisterFocus(CGlobals.focus focusHandler)
        {
            onFocus += focusHandler;
        }

        public virtual void draw(ref GraphicsDeviceManager manager)
        {
            if (_currentDraw != null)
            {
                CGlobals.mainBatch.Draw(_currentDraw, _defaultSize, Color.White);
                callOnPaint();
            }
        }

        public abstract void update(GameTime gameTime);
    }
}
