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
        private Texture2D _currentTexture;
        private Texture2D _attackTexture;
        private Texture2D _armtexture;
        private Rectangle _location;
        private Vector2 _speed;

        public Player(Texture2D textureLeft, Texture2D textureRight, Texture2D TextureAttack, Texture2D ArmTexture, int x, int y)
        {
            _leftTexture = textureLeft;
            _rightTexture = textureRight;
            _attackTexture = TextureAttack;
            _armtexture = ArmTexture;
            _currentTexture = textureRight;
            _location = new Rectangle(x, y, 78, 142);
            _speed = new Vector2();
           
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
            spriteBatch.Draw(_currentTexture, _location, Color.White);
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

        public bool Collide(Rectangle item)
        {
            return _location.Intersects(item);
        }

        public void Update(KeyboardState keyboardState)
        {
            _speed = new Vector2(0, 0);

            if (keyboardState.IsKeyDown(Keys.D))
            {
                _currentTexture = _rightTexture;
                _speed.X = 5;
            }

            else if (keyboardState.IsKeyDown(Keys.A))
            {
                _currentTexture = _leftTexture;
                _speed.X =  -5;

            }

            else if (keyboardState.IsKeyDown(Keys.E))
            {
                _currentTexture = _attackTexture;

            }

            else if (keyboardState.IsKeyDown(Keys.Q))
            {
                _currentTexture = _armtexture;
            }

            Move(keyboardState);
        }

        public Boolean Contains(Rectangle item)
        {
            return _location.Contains(item);
        }

        
    }
}
