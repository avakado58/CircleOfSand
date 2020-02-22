using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleOfSand
{
    class CompDraw:DrawableGameComponent
    {
        Texture2D texture;
        public Vector2 position;
        Rectangle rectangle;
        public CompDraw(Game game, Texture2D texture, Vector2 position, Rectangle rectangle) :base(game)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.position = position;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            spriteBatch.Draw(texture, position, Color.White);
            base.Draw(gameTime);
        }
    }
}
