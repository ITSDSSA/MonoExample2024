using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotty2024
{
    
    public class Dot : DrawableGameComponent
    {
        public Rectangle Bound { get; set; }
        public Vector2 Position { get; set; }

        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public string TextureName { get; set; }

        public Color Shade { get; set; }
        public Texture2D Texture { get; set; }
        public Dot(Game game, Vector2 StartPos, float speed, Color color) : base(game)
        {
            Position = StartPos;
            Speed = speed;
            Shade = color;
            Random r = new Random();
            Direction = Vector2.Normalize(new Vector2(r.Next(360), r.Next(360)));
            
            game.Components.Add(this);

        }

        protected override void LoadContent()
        {
            Texture = Game.Content.Load<Texture2D>("Circle 32 x 32");
            Bound = new Rectangle(Position.ToPoint(), Texture.Bounds.Size);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if(Game.GraphicsDevice.Viewport.Bounds.Contains(Bound))
            {
                Position = Position + Direction * Speed;
                Bound = new Rectangle(Position.ToPoint(), Texture.Bounds.Size);

            }
            else
            {
                Direction = -Direction;
                Position = Position + Direction * Speed;
                Bound = new Rectangle(Position.ToPoint(), Texture.Bounds.Size);

            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sp = Game.Services.GetService<SpriteBatch>();
            sp.Begin();
            sp.Draw(Texture, Position, Shade);
            sp.End();
            base.Draw(gameTime);
        }
    }
}
