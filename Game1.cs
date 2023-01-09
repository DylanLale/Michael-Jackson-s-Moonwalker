using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Player_Class;

namespace Michael_Jackson_s_Moonwalker
{
    
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            Game
        }
        Screen screen;
        MouseState mouseState;
        Player MJ;
        Texture2D TitleScreen;
        Rectangle TitleRect;
        Texture2D MJkick;
        Texture2D MJArm;
        Texture2D Club;
        Texture2D MJWalk1;
        Texture2D MJWalk2;
        Rectangle ClubRect;
        KeyboardState keyboardState;
        SoundEffect MJMusic;
        Rectangle MJRect;
        bool songplayed;
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
            TitleRect = new Rectangle(0, 0, 800, 500);
            ClubRect = new Rectangle(0, 0, 1280, 270);
            MJRect = new Rectangle(450, 50, 58, 188);
            

            base.Initialize();
            MJ = new Player(MJWalk1, 118, 52);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TitleScreen = Content.Load<Texture2D>("MJ Moonwalker");
            MJWalk1 = Content.Load<Texture2D>("MJWalk1");
            MJWalk2 = Content.Load<Texture2D>("MJWalk2");
            MJMusic = Content.Load<SoundEffect>("Moonwalker Music");
            MJArm = Content.Load<Texture2D>("MJArm");
            MJkick = Content.Load<Texture2D>("MJKick");
            Club = Content.Load<Texture2D>("level 1");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Game;

            }
            if (!songplayed)
            {
                songplayed = true;
                MJMusic.Play();
            }
            
            
            if (keyboardState.IsKeyDown(Keys.D))
                ClubRect.X -= 1;


            else if (keyboardState.IsKeyDown(Keys.A))
                ClubRect.X += 1;


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
            else if (screen == Screen.Game)
            {
                _spriteBatch.Draw(Club, ClubRect, Color.White);
                MJ.Draw(_spriteBatch);
            }
            
            GraphicsDevice.Clear(Color.Black);
            

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}