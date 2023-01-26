using Enemy_Class;
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
    
    public class Game : Microsoft.Xna.Framework.Game
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

        Screen screen;
        MouseState mouseState;
        Player MJ;
        Enemy BadGuy;
        Texture2D TitleScreen;
        Rectangle TitleRect;
        Texture2D MJTexture;
        Texture2D EnemyTexture;
        Texture2D MJkick;
        Texture2D MJArm;
        Texture2D EnemyDefault;
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
        Texture2D MJWalk2;
        Rectangle ClubRect;
        Rectangle EnemyRect;
        Rectangle DoorRect;
        KeyboardState keyboardState, prevKeyboardState;

        SoundEffect MJMusic;
        SoundEffect MJOW;
        Rectangle MJRect;
        bool songplayed;
        Random generator = new Random();
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            TitleRect = new Rectangle(0, 0, 800, 500);
            ClubRect = new Rectangle(0, 0, 800, 500);
            MJRect = new Rectangle(750, 50, 48, 100);
            DoorRect = new Rectangle(50, 370, 23, 50);
            


            base.Initialize();
            MJ = new Player(MJWalkLeft, MJWalkRight, MJkick, MJArm, 52, 300);
            BadGuy = new Enemy(EnemyDefault, EnemyPunch, DeadEnemy, generator.Next(100, 600), 300);
          

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TitleScreen = Content.Load<Texture2D>("MJ Moonwalker");
            MJWalkRight = Content.Load<Texture2D>("MJWalk1");
            MJWalkLeft = Content.Load<Texture2D>("MJWalkLeft");
            MJWalk2 = Content.Load<Texture2D>("MJWalk2");
            MJMusic = Content.Load<SoundEffect>("Moonwalker Music");
            MJOW = Content.Load<SoundEffect>("MJ OW");
            MJArm = Content.Load<Texture2D>("MJArm");
            MJkick = Content.Load<Texture2D>("MJKick");
            Screen1 = Content.Load<Texture2D>("screen 1");
            Screen2 = Content.Load<Texture2D>("screen 2");
            Screen3 = Content.Load<Texture2D>("screen 3");
            Screen4 = Content.Load<Texture2D>("screen 4");
            Screen5 = Content.Load<Texture2D>("screen 5");
            EnemyDefault = Content.Load<Texture2D>("Enemy");
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
            MJ.HSpeed = 0;
            MJ.VSpeed = 0;
            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

           
            
           // if (!songplayed)
            {
               // songplayed = true;
                //MJMusic.Play();
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
                    BadGuy.X = (generator.Next(100, 600));
                    MJ.X = 50;

                }

               
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(EnemyRect.X - 40, EnemyRect.Y - 40, EnemyRect.Width + 80, EnemyRect.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();
                    EnemyTexture = DeadEnemy;

                }
                
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;

                    MJOW.Play();


                }

                if (MJ.X <= 20)
                {
                    MJ.HSpeed = 0;
                }

            }
            else if (screen == Screen.Screen2)
            {
                MJ.Update(keyboardState);

             

                if (MJ.X >= 780)
                {
                    screen = Screen.Screen3;
                    BadGuy.X = (generator.Next(200, 500));
                    MJ.X = 50;
                }

               
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();



                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();

                }




            }
            else if (screen == Screen.Screen3)
            {
                MJ.Update(keyboardState);

                

                if (MJ.X >= 780)
                {
                    screen = Screen.Screen4;
                    BadGuy.Dead = false;
                    BadGuy.X = generator.Next(100, 500);
                    MJ.X = 30;
                }

                if (MJ.X >= BadGuy.X && !BadGuy.Dead) 
                {
                    screen = Screen.gameover;
                }

                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 20, BadGuy.Y - 20, BadGuy.Width + 40, BadGuy.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();

                    BadGuy.Dead = true;



                  
                    


                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 20, BadGuy.Y - 20, BadGuy.Width + 40, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }
                
            }
            else if (screen == Screen.Screen4)
            {
                MJ.Update(keyboardState);

                //EnemyTexture = EnemyDefault;

                if (MJ.X >= 780)
                {
                    screen = Screen.Screen5;
                    BadGuy.Dead = false;
                    BadGuy.X = (generator.Next(100, 150));
                    MJ.X = 50;
                }
                if (MJ.X >= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();
                    BadGuy.Dead = true;



                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }
            }
            else if (screen == Screen.Screen5)
            {
                MJ.Update(keyboardState);

                EnemyTexture = EnemyDefault;

                if (MJ.X >= 200)
                {
                    screen = Screen.UpstairsScreen1;
                    BadGuy.Dead = false;
                    BadGuy.X = (generator.Next(100, 500));
                    BadGuy.Y = 275;
                    MJ.X = 600;
                    MJ.Direction = "left";
                }
                else if (MJ.X >= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();

                    BadGuy.Dead = true;

                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }
            }
            else if (screen == Screen.UpstairsScreen1)
            {
                MJ.Update(keyboardState);

                EnemyTexture = EnemyDefault;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen2;
                    BadGuy.Dead = false;
                    BadGuy.X = (generator.Next(100, 500));
                    BadGuy.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.X <= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();

                    BadGuy.Dead = true;



                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }
            }
            else if (screen == Screen.UpstairsScreen2)
            {
                MJ.Update(keyboardState);

                EnemyTexture = EnemyDefault;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen3;
                    BadGuy.Dead = false;
                    BadGuy.X = (generator.Next(100, 500));
                    BadGuy.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.X <= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();

                    BadGuy.Dead = true;




                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }
            }

            else if (screen == Screen.UpstairsScreen3)
            {
                MJ.Update(keyboardState);

                EnemyTexture = EnemyDefault;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen4;
                    BadGuy.Dead = false;
                    BadGuy.X = (generator.Next(100, 500));
                    BadGuy.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.X <= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;

                    MJOW.Play();
                    BadGuy.Dead = true;




                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }
            }

            else if (screen == Screen.UpstairsScreen4)
            {
                MJ.Update(keyboardState);

                EnemyTexture = EnemyDefault;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen5;
                    BadGuy.Dead = false;
                    BadGuy.X = (generator.Next(100, 500));
                    BadGuy.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.X <= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();

                    BadGuy.Dead = true;

                    if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 20, BadGuy.Y - 20, BadGuy.Width + 40, BadGuy.Height)))
                    {
                        MJTexture = MJArm;
                        MJOW.Play();
                        BadGuy.Dead = true;

                    }



                }




            }
            else if (screen == Screen.UpstairsScreen5)
            {
                MJ.Update(keyboardState);

                EnemyTexture = EnemyDefault;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen6;
                    BadGuy.Dead = false;
                    BadGuy.X = (generator.Next(100, 500));
                    BadGuy.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.X <= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;
                    MJOW.Play();
                    BadGuy.Dead = true;
                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }

            }
            else if (screen == Screen.UpstairsScreen6)
            {
                MJ.Update(keyboardState);

                EnemyTexture = EnemyDefault;

                if (MJ.X <= 10)
                {
                    screen = Screen.UpstairsScreen7;
                    BadGuy.Dead = false;
                    EnemyRect.X = (generator.Next(100, 500));
                    EnemyRect.Y = 275;
                    MJ.X = 600;
                }
                if (MJ.X <= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;

                    MJOW.Play();
                    BadGuy.Dead = true;





                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }
            }
            else if (screen == Screen.UpstairsScreen7)
            {
                MJ.Update(keyboardState);

                EnemyTexture = EnemyDefault;

                if (MJ.X <= 10)
                {
                    screen = Screen.complete;
                }
                if (MJ.X <= BadGuy.X && !BadGuy.Dead)
                {
                    screen = Screen.gameover;
                }
                if (MJ.Collide(DoorRect))
                {
                    screen = Screen.complete;
                }
                if (keyboardState.IsKeyDown(Keys.E) && prevKeyboardState.IsKeyUp(Keys.E) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJkick;

                    MJOW.Play();
                    BadGuy.Dead = true;


                }
                if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q) && MJ.Collide(new Rectangle(BadGuy.X - 40, BadGuy.Y - 40, BadGuy.Width + 80, BadGuy.Height)))
                {
                    MJTexture = MJArm;
                    MJOW.Play();
                    BadGuy.Dead = true;

                }
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
                BadGuy.Draw(_spriteBatch);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.Screen4)
            {

                _spriteBatch.Draw(Screen4, ClubRect, Color.White);
                BadGuy.Draw(_spriteBatch); 
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.Screen5)
            {

                _spriteBatch.Draw(Screen5, ClubRect, Color.White);
                BadGuy.Draw(_spriteBatch); 
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen1)
            {

                _spriteBatch.Draw(upstairsScreen1, ClubRect, Color.White);
                BadGuy.Draw(_spriteBatch);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen2)
            {

                _spriteBatch.Draw(upstairsScreen2, ClubRect, Color.White);
                BadGuy.Draw(_spriteBatch);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen3)
            {

                _spriteBatch.Draw(upstairsScreen3, ClubRect, Color.White);
                BadGuy.Draw(_spriteBatch);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen4)
            {

                _spriteBatch.Draw(upstairsScreen4, ClubRect, Color.White);
                BadGuy.Draw(_spriteBatch);
                MJ.Draw(_spriteBatch);
            }
            else if (screen == Screen.UpstairsScreen5)
            {

                _spriteBatch.Draw(upstairsScreen5, ClubRect, Color.White);
                BadGuy.Draw(_spriteBatch);
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
                BadGuy.Draw(_spriteBatch);
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