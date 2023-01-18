using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_Class
{
    internal class Enemy
{
        private Texture2D _defaultTexture;
        private Texture2D _attackTexture;
        private Texture2D _deadTexture;
        private Rectangle _location;
        private bool dead = false;

        public Enemy(Texture2D defaultTexture, Texture2D attackTexture, Texture2D deadTexture, int x, int y)
        {
            _defaultTexture = defaultTexture;
            _attackTexture = attackTexture;
            _deadTexture = deadTexture;
            _location = new Rectangle(x, y, 78, 142);
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
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(_defaultTexture, _location, Color.White);
        }

        public bool Dead (KeyboardState keyboardState)
        {
            if (MJ = _attackTexture)
                dead = true;
        }

    }
}
