using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleOfSand
{
    class Daron:MainCharacter
    {
        public Daron(Game game, Texture2D texture, Vector2 beginPosition, Rectangle window):base(game,  texture,  beginPosition,  window)
        {

        }
        protected override void RectangleInitialize()
        {
            base.RectangleInitialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MoveDown(Keys.S);
            MoveUp(Keys.W);
            MoveLeft(Keys.A);
            MoveRight(Keys.D);
        }
    }
}
