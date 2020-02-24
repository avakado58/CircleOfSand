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
    class Bat : DrawableGameComponent
    {
        protected enum FlyDirection
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3
        }
        #region Объявление переменных 
        protected Texture2D textureBat;
        protected Rectangle[] upFrameOfTextureBat;
        protected Rectangle[] downFrameOfTextureBat;
        protected Rectangle[] leftFrameOfTextureBat;
        protected Rectangle[] rightFrameOfTextureBat;
        protected Rectangle rectangleSizeSprite;
        protected int iterUpFrame = 0;
        protected int iterDownFrame = 0;
        protected int iterRightFrame = 0;
        protected int iterLeftFrame = 0;
        protected Rectangle screenBounds;
        protected Vector2 positionBat;
        protected Vector2 newPosition;
        protected Vector2 speed;
        //public Rectangle SizeOfSprite { get; private set; }
        protected Random randNum;
        protected Color color;
        protected int stepNumber;
        protected FlyDirection flyDirection;
        protected MouseState mouseState;
        static public int CountObj { get; private set; } = 0;
        #endregion
        public Bat(Game game, ref Texture2D textureForBat, int speed) : base(game)
        {
            CountObj++;
            textureBat = textureForBat;
            randNum = new Random(speed);
            rectangleSizeSprite = new Rectangle(0, 0, 32, 32);
            screenBounds = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
            SetBeginPositions();
            while (HoweManyClollidee()>0)
            {
                SetBeginPositions();
            }
            
            color = new Color((byte)randNum.Next(0, 256), (byte)randNum.Next(0, 256), (byte)randNum.Next(0, 256));
            InitializeRectangle();
            stepNumber = 0;
            this.speed = new Vector2(5,5);
            
            
            flyDirection = FlyDirection.Down;
        }
        

        protected virtual void InitializeRectangle()
        {
            upFrameOfTextureBat = new Rectangle[]
            {
                new Rectangle(35,69,27,22),
                new Rectangle(66,70,29,13),
                new Rectangle(97,65,31,20)
            };
            downFrameOfTextureBat = new Rectangle[]
            {
                new Rectangle(35,5,27,23),
                new Rectangle(66,5,29,16),
                new Rectangle(97,1,31,21)
                

                
            };
            leftFrameOfTextureBat = new Rectangle[]
            {
                new Rectangle(38,97,17,21),
                new Rectangle(70,102,17,15),
                new Rectangle(102,102,15,21)

                
            };
            rightFrameOfTextureBat = new Rectangle[]
            {
                new Rectangle(41,33,17,21),
                new Rectangle(73,38,17,15),
                new Rectangle(107,38,15,21)
            };
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected void SetBeginPositions()
        {
            positionBat.X = (float)randNum.NextDouble() * (screenBounds.Width - rectangleSizeSprite.Width);
            positionBat.Y = (float)randNum.NextDouble() * (screenBounds.Height - rectangleSizeSprite.Height);
        }
        protected int HoweManyClollidee()
        {
            Bat bat;
            int howMany = 0;
            for (int i = 0; i < Game.Components.Count; i++)
            {
                if(Game.Components[i] is Bat)
                {
                    bat =(Bat)Game.Components[i];
                    if(this!=bat)
                    {
                        if(this.batCollide(bat))
                        {
                            howMany++;
                        }
                    }
                }
            }
            return howMany;
        }
        protected void IsSpriteCollide()
        {
            Bat bat;
            for (int i = 0; i < Game.Components.Count; i++)
            {
                if (Game.Components[i] is Bat)
                {
                    bat = (Bat)Game.Components[i];
                    if (bat !=this)
                    {
                        if (this.batCollide(bat))
                        {
                            this.speed *= -1;
                            this.positionBat += speed;
                        }
                    }
                }
            }

        }
        protected bool batCollide(Bat bat)
        {
           
            return (this.positionBat.X + this.rectangleSizeSprite.Width > bat.positionBat.X &&
                      this.positionBat.X < bat.positionBat.X + bat.rectangleSizeSprite.Width &&
                      this.positionBat.Y + this.rectangleSizeSprite.Height > bat.positionBat.Y &&
                      this.positionBat.Y < bat.positionBat.Y + bat.rectangleSizeSprite.Height);

        }
        protected void Check()
        {
            if (positionBat.X < screenBounds.Left)
            {
                speed.X *= -1;
                positionBat.X = screenBounds.Left;

            }
            if(positionBat.X>screenBounds.Width - rectangleSizeSprite.Width)
            {
                speed.X *= -1;
                positionBat.X = screenBounds.Width - rectangleSizeSprite.Width;

            }
            if(positionBat.Y<screenBounds.Top)
            {
                speed.Y *= -1;
                positionBat.Y = screenBounds.Top;

            }
            if(positionBat.Y>screenBounds.Height- rectangleSizeSprite.Height)
            {
                speed.Y *= -1;
                positionBat.Y = screenBounds.Height - rectangleSizeSprite.Height;

            }
                
        }
        protected virtual void Move(GameTime gameTime)
        {
            #region 
            if (stepNumber > 0)
            {
                stepNumber--;
                if (positionBat.X < newPosition.X)
                {
                    positionBat.X += speed.X;
                    flyDirection = FlyDirection.Right;

                    if (iterRightFrame < rightFrameOfTextureBat.Length - 1)
                    {
                        iterRightFrame++;
                    }
                    else
                    {
                        iterRightFrame = 0;
                    }

                }
                if (positionBat.X > newPosition.X)
                {
                    positionBat.X += speed.X;
                    flyDirection = FlyDirection.Left;
                    if (iterLeftFrame < leftFrameOfTextureBat.Length - 1)
                    {
                        iterLeftFrame++;
                    }
                    else
                    {
                        iterLeftFrame = 0;
                    }
                }
                if (positionBat.Y < newPosition.Y)
                {
                    positionBat.Y += speed.Y;
                    flyDirection = FlyDirection.Down;
                    if (iterDownFrame < downFrameOfTextureBat.Length - 1)
                    {
                        iterDownFrame++;
                    }
                    else
                    {
                        iterDownFrame = 0;
                    }
                }
                if (positionBat.Y > newPosition.Y)
                {
                    positionBat.Y += speed.Y;
                    flyDirection = FlyDirection.Up;
                    if (iterUpFrame < upFrameOfTextureBat.Length - 1)
                    {
                        iterUpFrame++;
                    }
                    else
                    {
                        iterUpFrame = 0;
                    }
                }


            }
            if (stepNumber == 0)
            {
                flyDirection = FlyDirection.Down;
                stepNumber = randNum.Next(10, 150);
                newPosition.X = (float)randNum.NextDouble() * (screenBounds.Width - downFrameOfTextureBat[0].Width);
                newPosition.Y = (float)randNum.NextDouble() * (screenBounds.Height - downFrameOfTextureBat[0].Height);
                color = new Color((byte)randNum.Next(0, 256), (byte)randNum.Next(0, 256), (byte)randNum.Next(0, 256));
            }
            #endregion
            //positionBat += speed;
        }
        protected bool IsMouseClollide()
        {
            return (this.positionBat.X + this.rectangleSizeSprite.Width > mouseState.X &&
                this.positionBat.X < mouseState.X &&
                this.positionBat.Y+this.rectangleSizeSprite.Height>mouseState.Y&&
                this.positionBat.Y<mouseState.Y);
        }
        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            base.Update(gameTime);
            Move(gameTime);
            Check();
            IsSpriteCollide();
            while (HoweManyClollidee()>0)
            {
                IsSpriteCollide();
            }
            if(mouseState.LeftButton== ButtonState.Pressed)
            {
                if(IsMouseClollide())
                {
                    Game.Components.Remove(this);
                    ((GameMain)Game).Score++;
                    this.Dispose();
                    
                }
            }
            
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            switch(flyDirection)
            {
                case FlyDirection.Down:
                    spriteBatch.Draw(textureBat, positionBat, downFrameOfTextureBat[iterDownFrame], color);
                    break;
                case FlyDirection.Up:
                    spriteBatch.Draw(textureBat, positionBat, upFrameOfTextureBat[iterUpFrame], color);
                    break;
                case FlyDirection.Left:
                    spriteBatch.Draw(textureBat, positionBat, leftFrameOfTextureBat[iterLeftFrame], color);
                    break;
                case FlyDirection.Right:
                    spriteBatch.Draw(textureBat, positionBat, rightFrameOfTextureBat[iterRightFrame], color);
                    break;

            }
            
            base.Draw(gameTime);
            
        }

    }
}
