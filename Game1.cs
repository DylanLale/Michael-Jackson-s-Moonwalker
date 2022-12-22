using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Player_Class;

namespace Michael_Jackson_s_Moonwalker
{
    
    public class Game1 : Game
    {
        Player MJ;
        Texture2D MJkick;
        Texture2D MJArm;
        Texture2D Club;
        Texture2D MJWalk1;
        Texture2D MJWalk2;
        Rectangle ClubRect;
        KeyboardState keyboardState;
        SoundEffect MJMusic;
        Rectangle MJRect;
        int MJSpeed;
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
            MJSpeed = 2;
            ClubRect = new Rectangle(0, 0, 1280, 270);
            MJRect = new Rectangle(450, 50, 58, 188);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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
            if (!songplayed)
            {
                songplayed = true;
                MJMusic.Play();
            }
            keyboardState = Keyboard.GetState();
            MJ.HSpeed = 0;
            MJ.VSpeed = 0;
            if (keyboardState.IsKeyDown(Keys.D))

                ClubRect.X += MJSpeed;
            else if (keyboardState.IsKeyDown(Keys.A))
                ClubRect.X -= MJSpeed;


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MJ.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Draw(Club, ClubRect, Color.White);
            MJ.Draw(_spriteBatch);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}