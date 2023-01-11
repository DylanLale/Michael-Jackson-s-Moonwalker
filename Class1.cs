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
        private Rectangle _location;
        private Vector2 _speed;

        public Player(Texture2D textureLeft, Texture2D textureRight, Texture2D TEXTUREATTACK int x, int y)
        {
            _leftTexture = textureLeft;
            _rightTexture = textureRight;
            _currentTexture = textureRight;
            _location = new Rectangle(x, y, 52, 118);
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

        public void Update(KeyboardState keyboardState)
        {
           

            if (keyboardState.IsKeyDown(Keys.D))
            {
                _currentTexture = _rightTexture;
                _speed.X = 3;
            }

            else if (keyboardState.IsKeyDown(Keys.A))
            {
                _currentTexture = _leftTexture;
                _speed.X =  -3;

            }

            


                Move(keyboardState);
        }

        public Boolean Contains(Rectangle item)
        {
            return _location.Contains(item);
        }

        
    }
}
