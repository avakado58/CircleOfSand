using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleOfSand
{
    class Control:GameComponent
    {
        CompDraw compDraw1;
        CompDraw compDraw2;
        Blast blast;
        Rectangle window;
        public Control(Game game):base(game)
        {
            CreateObj();
        }
        protected virtual void CreateObj()
        {
            Rectangle[] rectanglesBlast = new Rectangle[]
            {
                new Rectangle(13,14,19,18),
                new Rectangle(50,7,31,28),
                new Rectangle(90,4,38,36),
                new Rectangle(131,0,42,43),
                new Rectangle(173,0,43,42),
                new Rectangle(1,45,44,41),
                new Rectangle(47,47,40,39),
                new Rectangle(101,62,27,11)
            };
            window = new Rectangle(5, 0, 760, 535);
            Texture2D textureBlast = Game.Content.Load<Texture2D>("blast");
            //daron = new Daron(this, Content.Load<Texture2D>("main-character-walk-frame"), new Vector2(100,100), window);
            //lidia = new Lidia(this, Content.Load<Texture2D>("main-character-walk-frame"), new Vector2(300, 100), window);
            //Components.Add(lidia);
            //Components.Add(daron);
            compDraw1 = new CompDraw(Game, Game.Content.Load<Texture2D>("male"), new Vector2(100, 100), new Rectangle(0, 0, 23, 50));
            compDraw2 = new CompDraw(Game, Game.Content.Load<Texture2D>("female"), new Vector2(100, 200), new Rectangle(1, 0, 25, 48));
            blast = new Blast(Game, ref textureBlast, rectanglesBlast, compDraw1.position);
            Game.Components.Add(compDraw1);
            Game.Components.Add(compDraw2);
            Game.Components.Add(blast);
            
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MoveUp(compDraw1, Keys.W);
            MoveDown(compDraw1, Keys.S);
            MoveLeft(compDraw1, Keys.A);
            MoveRight(compDraw1, Keys.D);

            MoveUp(compDraw2, Keys.Up);
            MoveDown(compDraw2, Keys.Down);
            MoveLeft(compDraw2, Keys.Left);
            MoveRight(compDraw2, Keys.Right);
        }
        private void MoveUp(CompDraw compDraw, Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                if (compDraw.position.Y > window.Top)
                {
                    compDraw.position.Y -= 5;
                }
                blast.beginPositionBlast = compDraw.position;
                blast.positionBlast = compDraw.position;
            }

        }
        private void MoveDown(CompDraw compDraw, Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                if (compDraw.position.Y < window.Bottom)
                {
                    compDraw.position.Y += 5;
                }
                blast.beginPositionBlast = compDraw.position;
                blast.positionBlast = compDraw.position;
            }

        }
        private void MoveLeft(CompDraw compDraw, Keys keys)
        {

            if (Keyboard.GetState().IsKeyDown(keys))
            {
                if (compDraw.position.X > window.Left)
                {
                    compDraw.position.X -= 5;
                }
                blast.beginPositionBlast = compDraw.position;
                blast.positionBlast = compDraw.position;
            }
        }
        private void MoveRight(CompDraw compDraw, Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                if (compDraw.position.X < window.Right)
                {
                    compDraw.position.X += 5;
                }
                blast.beginPositionBlast = compDraw.position;
                blast.positionBlast = compDraw.position;
            }
        }

    }
}
