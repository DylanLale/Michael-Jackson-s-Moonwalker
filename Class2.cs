using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_Class
{
    class Enemy
{
        private Texture2D _defaultTexture;
        private Texture2D _attackTexture;
        private Texture2D _deadTexture;
        private Rectangle _location;
        private bool _dead;

        public Enemy(Texture2D defaultTexture, Texture2D attackTexture, Texture2D deadTexture, int x, int y)
        {
            _defaultTexture = defaultTexture;
            _attackTexture = attackTexture;
            _deadTexture = deadTexture;
            _location = new Rectangle(x, y, 78, 142);
            _dead = false;
        }
        public int X
        {
            get { return _location.X; }
            set { _location.X = value; }
        }

        public int Y
        {
            get { return _location.Y; }
            set { _location.Y = value; }
        }
        public int Width
        {
            get { return _location.Width; }
        }
        public int Height
        {
            get { return _location.Height; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_dead)
            {
                spriteBatch.Draw(_deadTexture, new Rectangle(_location.X, 400, 118, 34), Color.White);
            }
            else
                spriteBatch.Draw(_defaultTexture, _location, Color.White);
        }

        public bool Dead
        {
            get { return _dead; }
            set { _dead = value; }

        }

    }
}
