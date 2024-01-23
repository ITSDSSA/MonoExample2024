using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sprites;

namespace MoneoExample2024
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Song openingMusicTrack;
        private SoundEffect clickEffect;
        private SoundEffectInstance clickPlayer;
        private SimpleSprite bodySprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            new InputEngine(this);
            Vector2 currentMouse = InputEngine.MousePosition;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D bodytx = Content.Load<Texture2D>("body");
            openingMusicTrack = Content.Load<Song>("Opening Music Track");
            //MediaPlayer.Play(openingMusicTrack);
            clickEffect = Content.Load<SoundEffect>("charge");
             clickPlayer = clickEffect.CreateInstance();
            //clickEffect.Play();
            bodySprite = new SimpleSprite(bodytx, new Vector2(100, 100));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(InputEngine.IsKeyHeld(Keys.Right)) 
            {
                bodySprite.Move(new Vector2(5, 0));
            }
            if (InputEngine.IsKeyHeld(Keys.Left))
            {
                bodySprite.Move(new Vector2(-5, 0));
            }

            if(InputEngine.IsMouseLeftClick() 
                && bodySprite.BoundingRect.Contains(InputEngine.MousePosition.ToPoint() ))
                if(clickPlayer.State != SoundState.Playing)
                {
                    clickPlayer.Play();
                }
                    
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            bodySprite.draw(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
