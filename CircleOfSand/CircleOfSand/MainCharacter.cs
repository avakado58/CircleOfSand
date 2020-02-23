using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleOfSand
{
    enum WalkingDirection
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
    abstract class MainCharacter:DrawableGameComponent
    {
        public delegate void DelegateForEvet(object sender, ChangeDirectionEventArgs e);
        public event DelegateForEvet ChangePosition;
        public int NumberSpriteForAnimation => upFrameOfTextureMC.Length - 1;
        public Vector2 Position;
        protected Texture2D textureMainCharacter;
        protected  Rectangle[] upFrameOfTextureMC;//MC - MainCharacter
        protected  Rectangle[] downFrameOfTextureMC;
        protected  Rectangle[] leftFrameOfTextureMC;
        protected  Rectangle[] rightFrameOfTextureMC;
        public Rectangle sizeOfSprite;
        public int IterUpFrame { get; set; } = 0;
        public int IterDownFrame { get; set; } = 0;
        public int IterRightFrame { get; set; }  = 0;
        public int IterLeftFrame { get; set; } = 0;
        protected Rectangle window;
        public WalkingDirection walkingDirection;

        public MainCharacter(Game game, Texture2D texture, Vector2 beginPosition, Rectangle window): base(game)
        {
            textureMainCharacter = texture;
            Position = beginPosition;
            this.window = window;
            walkingDirection = WalkingDirection.Right;
            RectangleInitialize();
            sizeOfSprite = new Rectangle(0, 0, upFrameOfTextureMC[0].Width, upFrameOfTextureMC[0].Height);
            this.ChangePosition += MainCharacter_ChangePosition;

        }

        private void MainCharacter_ChangePosition(object sender, ChangeDirectionEventArgs e)
        {
            IterUpFrame = e.IterUpFrame;
            IterDownFrame = e.IterDownFrame;
            IterLeftFrame = e.IterLeftFrame;
            IterRightFrame = e.IterRightFrame;
            walkingDirection = e.WalkingDirection;
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
                if (Position.Y > window.Top)
                {
                    Position.Y -= 5;
                    if (IterUpFrame < upFrameOfTextureMC.Length-1)
                    {
                        IterUpFrame++;
                    }
                    else
                    {
                        IterUpFrame = 0;
                    }
                }

            }
        }
        protected void MoveDown(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {
                walkingDirection = WalkingDirection.Down;
                if (Position.Y < window.Bottom)
                {
                    Position.Y += 5;
                    if (IterDownFrame < downFrameOfTextureMC.Length-1)
                    {
                        IterDownFrame++;
                    }
                    else
                    {
                        IterDownFrame = 0;
                    }
                }

            }
        }
        protected void MoveLeft(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {

                if (Position.X > window.Left)
                {
                    walkingDirection = WalkingDirection.Left;
                    Position.X -= 5;
                    if (IterLeftFrame < leftFrameOfTextureMC.Length-1)
                    {
                        IterLeftFrame++;
                    }
                    else
                    {
                        IterLeftFrame = 0;
                    }
                }

            }
        }
        protected void MoveRight(Keys keys)
        {
            if (Keyboard.GetState().IsKeyDown(keys))
            {

                if (Position.X < window.Right)
                {
                    walkingDirection = WalkingDirection.Right;
                    Position.X += 5;
                    if (IterRightFrame < rightFrameOfTextureMC.Length-1)
                    {
                        IterRightFrame++;
                    }
                    else
                    {
                        IterRightFrame = 0;
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
                    spriteBatch.Draw(textureMainCharacter, Position, upFrameOfTextureMC[IterUpFrame], Color.White);
                    break;
                case WalkingDirection.Down:
                    spriteBatch.Draw(textureMainCharacter, Position, downFrameOfTextureMC[IterDownFrame], Color.White);
                    break;
                case WalkingDirection.Left:
                    spriteBatch.Draw(textureMainCharacter, Position, leftFrameOfTextureMC[IterLeftFrame], Color.White);
                    break;
                case WalkingDirection.Right:
                    spriteBatch.Draw(textureMainCharacter, Position, rightFrameOfTextureMC[IterRightFrame], Color.White);
                    break;
            }
            
            base.Draw(gameTime);
        }
    }
}
