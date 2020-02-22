using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleOfSand
{
    class MainCharacter:DrawableGameComponent
    {
        protected enum WalkingDirection
        {
            Up=0,
            Down=1,
            Left=2,
            Right=3
        }
        public Vector2 PositionMainCharacter;
        protected Texture2D textureMainCharacter;
        protected  Rectangle[] upFrameOfTextureMC;//MC - MainCharacter
        protected  Rectangle[] downFrameOfTextureMC;
        protected  Rectangle[] leftFrameOfTextureMC;
        protected  Rectangle[] rightFrameOfTextureMC;
        protected int iterUpFrame = 0;
        protected int iterDownFrame = 0;
        protected int iterRightFrame=0;
        protected int iterLeftFrame = 0;
        protected Rectangle window;
        protected WalkingDirection walkingDirection;

        public MainCharacter(Game game, Texture2D texture, Vector2 beginPosition, Rectangle window): base(game)
        {
            textureMainCharacter = texture;
            PositionMainCharacter = beginPosition;
            this.window = window;
            walkingDirection = WalkingDirection.Right;
            RectangleInitialize();
        }
        protected virtual void RectangleInitialize()
        {
            upFrameOfTextureMC = new Rectangle[] {
                new Rectangle(10,14,30,50),
                new Rectangle(57,14,30,50),
               new Rectangle(105,14,30,50)
            };
            downFrameOfTextureMC = new Rectangle[] {
                 new Rectangle(10,139,30,50),
                new Rectangle(57,139,30,50),
                new Rectangle(105,139,30,50)
            };
            leftFrameOfTextureMC = new Rectangle[] {
                new Rectangle(10,207,30,50),
                new Rectangle(57,207,30,50),
                new Rectangle(105,207,30,50)
            };
            rightFrameOfTextureMC = new Rectangle[] {
                new Rectangle(10,77,30,50),
                new Rectangle(60,77,30,50),
                new Rectangle(108,77,30,50)
            };
        }
        public override void Initialize()
        {
            base.Initialize();
            
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);





        }
        protected void MoveUp(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                walkingDirection = WalkingDirection.Up;
                if (PositionMainCharacter.Y > window.Top)
                {
                    PositionMainCharacter.Y -= 5;
                    if (iterUpFrame < 2)
                    {
                        iterUpFrame++;
                    }
                    else
                    {
                        iterUpFrame = 0;
                    }
                }

            }
        }
        protected void MoveDown(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                walkingDirection = WalkingDirection.Down;
                if (PositionMainCharacter.Y < window.Bottom)
                {
                    PositionMainCharacter.Y += 5;
                    if (iterDownFrame < 2)
                    {
                        iterDownFrame++;
                    }
                    else
                    {
                        iterDownFrame = 0;
                    }
                }

            }
        }
        protected void MoveLeft(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {

                if (PositionMainCharacter.X > window.Left)
                {
                    walkingDirection = WalkingDirection.Left;
                    PositionMainCharacter.X -= 5;
                    if (iterLeftFrame < 2)
                    {
                        iterLeftFrame++;
                    }
                    else
                    {
                        iterLeftFrame = 0;
                    }
                }

            }
        }
        protected void MoveRight(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {

                if (PositionMainCharacter.X < window.Right)
                {
                    walkingDirection = WalkingDirection.Right;
                    PositionMainCharacter.X += 5;
                    if (iterRightFrame < 2)
                    {
                        iterRightFrame++;
                    }
                    else
                    {
                        iterRightFrame = 0;
                    }
                }

            }
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            switch(walkingDirection)
            {
                case WalkingDirection.Up:
                    spriteBatch.Draw(textureMainCharacter, PositionMainCharacter, upFrameOfTextureMC[iterUpFrame], Color.White);
                    break;
                case WalkingDirection.Down:
                    spriteBatch.Draw(textureMainCharacter, PositionMainCharacter, downFrameOfTextureMC[iterDownFrame], Color.White);
                    break;
                case WalkingDirection.Left:
                    spriteBatch.Draw(textureMainCharacter, PositionMainCharacter, leftFrameOfTextureMC[iterLeftFrame], Color.White);
                    break;
                case WalkingDirection.Right:
                    spriteBatch.Draw(textureMainCharacter, PositionMainCharacter, rightFrameOfTextureMC[iterRightFrame], Color.White);
                    break;
            }
            
            base.Draw(gameTime);
        }
    }
}
