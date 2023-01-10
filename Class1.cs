using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player_Class
{
    class Player
    {
        private Texture2D _leftTexture;
        private Texture2D _rightTexture;
        private Rectangle _location;
        private Vector2 _speed;
        private int _prevSpeed;

        public Player(Texture2D texture, int x, int y)
        {
            _leftTexture = texture;
            _rightTexture = texture;
            _location = new Rectangle(x, y, 52, 118);
            _speed = new Vector2();
            _prevSpeed = 1;
        }

        public float HSpeed
        {
            get { return _speed.X; }
            set { _speed.X = value; }
        }

        public float VSpeed
        {
            get { return _speed.Y; }
            set { _speed.Y = value; }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (_prevSpeed < 0)
                spriteBatch.Draw(_leftTexture, _location, Color.White);
            else
            spriteBatch.Draw(_rightTexture, _location, Color.White);
        }

        private void Move(KeyboardState keyboardState)
        {
            _location.X += (int)_speed.X;
            _location.Y += (int)_speed.Y;
        }

        public void UndoMove()
        {
            _location.X -= (int)_speed.X;
            _location.Y -= (int)_speed.Y;
        }

        public void Update(KeyboardState keyboardState)
        {
            if (_speed.X < 0)
                _prevSpeed = -1;
            else if (_speed.X > 0)
                _prevSpeed = 1;

            Move(keyboardState);
        }

        public Boolean Contains(Rectangle item)
        {
            return _location.Contains(item);
        }

        
    }
}
