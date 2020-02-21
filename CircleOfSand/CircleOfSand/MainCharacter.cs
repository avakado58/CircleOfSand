using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleOfSand
{
    class MainCharacter:DrawableGameComponent
    {
        public Vector2 PositionMainCharacter { get; private set; }

        public MainCharacter(Game game, Texture texture): base(game)
        {

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
            base.Draw(gameTime);
        }
    }
}
