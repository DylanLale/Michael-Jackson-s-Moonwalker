using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Player_Class;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Michael_Jackson_s_Moonwalker
{
    
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            Screen1,
            Screen2,
            Screen3,
            Screen4,
            Screen5,
            UpstairsScreen1,
            UpstairsScreen2,
            UpstairsScreen3,
            UpstairsScreen4,
            UpstairsScreen5,
            UpstairsScreen6,
            UpstairsScreen7,
            gameover,
            complete,

        }
        float seconds;
        float startTime;
        Screen screen;
        MouseState mouseState;
        Player MJ;
        Texture2D TitleScreen;
        Rectangle TitleRect;
        Texture2D MJTexture;
        Texture2D EnemyTexture;
        Texture2D MJkick;
        Texture2D MJArm;
        Texture2D Enemy;
        Texture2D DeadEnemy;
        Texture2D EnemyPunch;
        Texture2D Screen1;
        Texture2D Screen2;
        Texture2D Screen3;
        Texture2D Screen4;
        Texture2D Screen5;
        Texture2D upstairsScreen1;
        Texture2D upstairsScreen2;
        Texture2D upstairsScreen3;
        Texture2D upstairsScreen4;
        Texture2D upstairsScreen5;
        Texture2D upstairsScreen6;
        Texture2D upstairsScreen7;
        Texture2D MJWalkRight;
        Texture2D MJWalkLeft;
        Texture2D GameOverTexture;
        Texture2D LevelComplete;
        int Lives = 3;
        Texture2D MJWalk2;
        Rectangle ClubRect;
        Rectangle EnemyRect;
        Rectangle DeadEnemyRect;
        Rectangle DoorRect; 
        KeyboardState keyboardState;
        SoundEffect MJMusic;
        Rectangle MJRect;
        bool songplayed;
        Random generator = new Random();
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;
            EnemyRect.Y = 295;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            EnemyRect = new Rectangle(generator.Next(100, 500), EnemyRect.Y, 88, 140);
            DeadEnemyRect = new Rectangle(EnemyRect.X, EnemyRect.Y, 34, 118);
            TitleRect = new Rectangle(0, 0, 800, 500);
            ClubRect = new Rectangle(0, 0, 800, 500);
            MJRect = new Rectangle(750, 50, 48, 100);
            DoorRect = new Rectangle(50, 370, 23, 50);
            


            base.Initialize();
            MJ = new Player(MJWalkLeft, MJWalkRight, MJkick, MJArm, 52, 300);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TitleScreen = Content.Load<Texture2D>("MJ Moonwalker");
            MJWalkRight = Content.Load<Texture2D>("MJWalk1");
            MJWalkLeft = Content.Load<Texture2D>("MJWalkLeft");
            MJWalk2 = Content.Load<Texture2D>("MJWalk2");
            MJMusic = Content.Load<SoundEffect>("Moonwalker Music");
            MJArm = Content.Load<Texture2D>("MJArm");
            MJkick = Content.Load<Texture2D>("MJKick");
            Screen1 = Content.Load<Texture2D>("screen 1");
            Screen2 = Content.Load<Texture2D>("screen 2");
            Screen3 = Content.Load<Texture2D>("screen 3");
            Screen4 = Content.Load<Texture2D>("screen 4");
            Screen5 = Content.Load<Texture2D>("screen 5");
            Enemy = Content.Load<Texture2D>("Enemy");
            DeadEnemy = Content.Load<Texture2D>("DeadEnemy");
            EnemyPunch = Content.Load<Texture2D>("Enemy.Punch");
            GameOverTexture = Content.Load<Texture2D>("MJgameover");
            LevelComplete = Content.Load<Texture2D>("level complete");
            upstairsScreen1 = Content.Load<Texture2D>("upstairs screen 1");
            upstairsScreen2 = Content.Load<Texture2D>("upstairs screen 2");
            upstairsScreen3 = Content.Load<Texture2D>("upstairs screen 3");
            upstairsScreen4 = Content.Load<Texture2D>("upstairs screen 4");
            upstairsScreen5 = Content.Load<Texture2D>("upstairs screen 5");
            upstairsScreen6 = Content.Load<Texture2D>("upstairs screen 6");
            upstairsScreen7 = Content.Load<Texture2D>("upstairs screen 7");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            MJ.VSpeed = 0;
            MJ.HSpeed = 0;
            // if (Lives == 0)
            {
                //(screen == Screen.gameover);
            }
            if (!songplayed)
            {
                songplayed = true;
                MJMusic.Play();
            }

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Screen1;


            }
            else if (screen == Screen.Screen1)
            {


                MJ.Update(keyboardState);

                if (MJ.X >= 780)
                {
                    screen = Screen.Screen2;
                    EnemyRect.X = (generator.Next(100, 600));
                    MJ.X = 50;

                }

                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E) && MJ.Collide(new Rectangle(EnemyRect.X - 10, EnemyRect.Y - 10, EnemyRect.Width + 20, EnemyRect.Height)))
                {
                    MJTexture = MJkick;

                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }




                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }
            else if (screen == Screen.Screen2)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X >= 780)
                {
                    screen = Screen.Screen3;
                    EnemyRect.X = (generator.Next(100, 500));
                    MJ.X = 50;
                }

                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }
                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }




            }
            else if (screen == Screen.Screen3)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X >= 780)
                {
                    screen = Screen.Screen4;
                    EnemyRect.X = (generator.Next(100, 500));
                    MJ.X = 50;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }






                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }
            else if (screen == Screen.Screen4)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X >= 780)
                {
                    screen = Screen.Screen5;
                    EnemyRect.X = (generator.Next(100, 500));
                    MJ.X = 50;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }
            else if (screen == Screen.Screen5)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X >= 200)
                {
                    screen = Screen.UpstairsScreen1;
                    EnemyRect.X = (generator.Next(100, 500));
                    EnemyRect.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }
            else if (screen == Screen.UpstairsScreen1)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen2;
                    EnemyRect.X = (generator.Next(100, 500));
                    EnemyRect.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }



                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }
            else if (screen == Screen.UpstairsScreen2)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen3;
                    EnemyRect.X = (generator.Next(100, 500));
                    EnemyRect.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }




                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }

            else if (screen == Screen.UpstairsScreen3)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen4;
                    EnemyRect.X = (generator.Next(100, 500));
                    EnemyRect.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }




                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }

            else if (screen == Screen.UpstairsScreen4)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen5;
                    EnemyRect.X = (generator.Next(100, 500));
                    EnemyRect.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (keyboardState.IsKeyDown(Keys.Q))
                    {
                        MJTexture = MJArm;

                        if (EnemyRect.X + 5 >= MJ.X)
                        {
                            EnemyTexture = DeadEnemy;

                        }

                        if (EnemyRect.X - 5 <= MJ.X)
                        {
                            EnemyTexture = DeadEnemy;

                        }

                    }



                }




            }
            else if (screen == Screen.UpstairsScreen5)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen6;
                    EnemyRect.X = (generator.Next(100, 500));
                    EnemyRect.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }





                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }

            }
            else if (screen == Screen.UpstairsScreen6)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen7;
                    EnemyRect.X = (generator.Next(100, 500));
                    EnemyRect.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }





                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }
            else if (screen == Screen.UpstairsScreen7)
            {
                MJ.Update(keyboardState);

                EnemyTexture = Enemy;

                if (MJ.X <= 10)
                {
                    screen = Screen.complete;
                }
                if (MJ.Collide(EnemyRect))
                {
                    EnemyTexture = EnemyPunch;
                    Lives--;
                }
                if (MJ.Collide(DoorRect))
                {
                    screen = Screen.complete;
                }
                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;


                    if (EnemyRect.X + 5 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }


                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    MJTexture = MJArm;

                    if (EnemyRect.X + 30 <= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 30 >= MJ.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                }
            }

            else if (screen == Screen.gameover)
            {
                if (seconds >= 5)
                    Exit();

            }













                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                // TODO: Add your update logic here

                base.Update(gameTime);
            
        }
        

            

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(TitleScreen, TitleRect, Color.White);
            }
            else if (screen == Screen.Screen1)
            {
                _spriteBatch.Draw(Screen1, ClubRect, Color.White);
                MJ.Draw(_spriteBatch);

            }
            else if (screen == Screen.Screen2)
            {
               
                _spriteBatch.Draw(Screen2, ClubRect, Color.White);
                
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.Screen3)
            {

                _spriteBatch.Draw(Screen3, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.Screen4)
            {

                _spriteBatch.Draw(Screen4, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.Screen5)
            {

                _spriteBatch.Draw(Screen5, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen1)
            {

                _spriteBatch.Draw(upstairsScreen1, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen2)
            {

                _spriteBatch.Draw(upstairsScreen2, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen3)
            {

                _spriteBatch.Draw(upstairsScreen3, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen4)
            {

                _spriteBatch.Draw(upstairsScreen4, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen5)
            {

                _spriteBatch.Draw(upstairsScreen5, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen6)
            {

                _spriteBatch.Draw(upstairsScreen6, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen7)
            {

                _spriteBatch.Draw(upstairsScreen7, ClubRect, Color.White);
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.gameover)
            {
                _spriteBatch.Draw(GameOverTexture, ClubRect, Color.White);
            }
            else if (screen == Screen.complete)
            {
                _spriteBatch.Draw(LevelComplete, ClubRect, Color.White);
            }

            GraphicsDevice.Clear(Color.Black);
            

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}