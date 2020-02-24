using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleOfSand
{
    class Control : GameComponent
    {

        Blast blast;
        Daron daron;
        Lidia lidia;
        Rectangle window;
        protected int iterUpFrame = 0;
        protected int iterDownFrame = 0;
        protected int iterRightFrame = 0;
        protected int iterLeftFrame = 0;
        public Control(Game game) : base(game)
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
            daron = new Daron(Game, Game.Content.Load<Texture2D>("main-character-walk-frame"), new Vector2(100,100), window);
            lidia = new Lidia(Game, Game.Content.Load<Texture2D>("main-character-walk-frame"), new Vector2(300, 100), window);
            blast = new Blast(Game, ref textureBlast, rectanglesBlast, daron.Position);
            Game.Components.Add(lidia);
            Game.Components.Add(daron);
            Game.Components.Add(blast);
            
            //Game.Components.Add(compDraw1);
            //Game.Components.Add(compDraw2);
            //Game.Components.Add(blast);

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MoveUp(daron, Keys.W);
            MoveDown(daron, Keys.S);
            MoveLeft(daron, Keys.A);
            MoveRight(daron, Keys.D);

            MoveUp(lidia, Keys.Up);
            MoveDown(lidia, Keys.Down);
            MoveLeft(lidia, Keys.Left);
            MoveRight(lidia, Keys.Right);
        }
        private Rectangle collideObj1 = new Rectangle();
        private Rectangle collideObj2 = new Rectangle();
        protected bool IsCollide(MainCharacter character1, MainCharacter character2)
        {
            collideObj1.X = (int)character1.Position.X;
            collideObj1.Y = (int)character1.Position.Y;
            collideObj1.Width = character1.sizeOfSprite.Width;
            collideObj1.Height = character1.sizeOfSprite.Height;

            collideObj2.X = (int)character2.Position.X;
            collideObj2.Y = (int)character2.Position.Y;
            collideObj2.Width = character2.sizeOfSprite.Width;
            collideObj2.Height = character2.sizeOfSprite.Height;

            return collideObj1.Intersects(collideObj2);
        }
        protected bool IsCollide2(MainCharacter character1, MainCharacter character2)
        {
            if(character1.Position.X<character2.Position.X+character2.sizeOfSprite.Width&&
               character1.Position.X+character1.sizeOfSprite.Width>character2.Position.X&&
               character1.Position.Y<character2.Position.Y+character2.sizeOfSprite.Height&&
               character1.Position.Y+character1.sizeOfSprite.Height>character2.Position.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void BlastAnim(MainCharacter character)
        {
            if (!blast.FlagAnim)
            {
                blast.beginPositionBlast.X = character.Position.X + 5;
                blast.beginPositionBlast.Y = character.Position.Y + 15;
                blast.positionBlast = blast.beginPositionBlast;
            }
        }
        private void MoveUp(MainCharacter character, Keys keys)
        {
            
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                character.walkingDirection = WalkingDirection.Up;
                
                if (character.Position.Y > window.Top)
                {
                    //if(IsCollide())
                    //{
                    //    flag = true;
                    //}
                    character.Position.Y -= 5;
                    if (IsCollide2(lidia,daron))
                    {
                        character.Position.Y += 5;
                    }
                    if (character.IterUpFrame < character.NumberSpriteForAnimation)
                    {
                        character.IterUpFrame++;
                    }
                    else
                    {
                        character.IterUpFrame = 0;
                    }
                }
                BlastAnim(character);


            }

        }
        private void MoveDown(MainCharacter character, Keys keys)
        {
            
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                character.walkingDirection = WalkingDirection.Down;
                if (character.Position.Y < window.Bottom)
                {
                    //if (IsCollide())
                    //{
                    //    flag = true;
                    //}
                    character.Position.Y += 5;
                    if (IsCollide2(lidia,daron))
                    {
                        character.Position.Y -= 5;
                    }
                    if (character.IterDownFrame < character.NumberSpriteForAnimation)
                    {
                        character.IterDownFrame++;
                    }
                    else
                    {
                        character.IterDownFrame = 0;
                    }
                }

                BlastAnim(character);
            }

        }
        private void MoveLeft(MainCharacter character, Keys keys)
        {
            
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                
                if (character.Position.X > window.Left)
                {
                    //if (IsCollide())
                    //{
                    //    flag = true;
                    //}
                    character.walkingDirection = WalkingDirection.Left;
                    character.Position.X -= 5;
                    if (IsCollide2(lidia,daron))
                    {
                        character.Position.X += 5;
                    }
                    if (character.IterLeftFrame < character.NumberSpriteForAnimation)
                    {
                        character.IterLeftFrame++;
                    }
                    else
                    {
                        character.IterLeftFrame = 0;
                    }
                }
                BlastAnim(character);
            }
        }
        private void MoveRight(MainCharacter character, Keys keys)
        {
            
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                if (character.Position.X < window.Right)
                {
                    //if(IsCollide())
                    //{
                    //    flag = true;
                    //}
                    character.Position.X += 5;
                    character.walkingDirection = WalkingDirection.Right;
                    if (IsCollide2(lidia,daron))
                    {
                        character.Position.X -= 5;
                    }
                    
                    if (character.IterRightFrame < character.NumberSpriteForAnimation)
                    {
                        character.IterRightFrame++;
                    }
                    else
                    {
                        character.IterRightFrame = 0;
                    }
                }
                BlastAnim(character);

            }
        }

    }
}