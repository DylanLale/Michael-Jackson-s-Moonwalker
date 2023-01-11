﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Player_Class;
using System;
using System.Runtime.CompilerServices;

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

        }
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
        Texture2D MJWalkLeft2;
        int Lives = 3;
        Texture2D MJWalk2;
        Rectangle ClubRect;
        Rectangle EnemyRect;
        Rectangle DeadEnemyRect;
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
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            EnemyRect = new Rectangle(generator.Next(100, 500), 50, 48, 100);
            DeadEnemyRect = new Rectangle(EnemyRect.X, 50, 118, 34);
            TitleRect = new Rectangle(0, 0, 800, 500);
            ClubRect = new Rectangle(0, 0, 800, 500);
            MJRect = new Rectangle(750, 50, 48, 100);
            


            base.Initialize();
            MJ = new Player(MJWalkLeft, MJWalkRight, MJkick, 52, 300);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TitleScreen = Content.Load<Texture2D>("MJ Moonwalker");
            MJWalkRight = Content.Load<Texture2D>("MJWalk1");
            MJWalkLeft = Content.Load<Texture2D>("MJWalkLeft");
            MJWalk2 = Content.Load<Texture2D>("MJWalk2");
            MJWalkLeft2 = Content.Load<Texture2D>("MJWalk2Left");
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
            EnemyPunch = Content.Load<Texture2D>("EnemyPunch");
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
            MJ.VSpeed = 0;
            MJ.HSpeed = 0;
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


                if (keyboardState.IsKeyDown(Keys.E))
                {
                    MJTexture = MJkick;

                    if (EnemyRect.X + 5 <= MJRect.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }

                    if (EnemyRect.X - 5 <= MJRect.X)
                    {
                        EnemyTexture = DeadEnemy;

                    }
                    if (EnemyRect.X + 5 <= MJRect.X)
                    {
                        EnemyTexture = EnemyPunch;
                    }

                    if (EnemyRect.X - 5 <= MJRect.X)
                    {
                        EnemyTexture = EnemyPunch;
                        Lives--;
                    }

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
                _spriteBatch.Draw(EnemyTexture, EnemyRect, Color.White);
                MJ.Draw(_spriteBatch);
            }

            GraphicsDevice.Clear(Color.Black);
            

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}