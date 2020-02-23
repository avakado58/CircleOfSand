using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleOfSand
{
    class Bat:DrawableGameComponent
    {
        protected Texture2D textureBat;
        protected Rectangle rectangleForTexture;
        protected Rectangle screenBounds;
        protected Vector2 positionBat;
        protected Vector2 newPosition;
        protected Vector2 speed;
        protected Random randNum;
        protected Color color;
        protected int stepNumber;
        public Bat(Game game, ref Texture2D textureForBat, Rectangle rectangleForTexture, int speed):base(game)
        {
            textureBat = textureForBat;
            this.rectangleForTexture = rectangleForTexture;
            randNum = new Random(speed);
            screenBounds = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
            positionBat.X = (float)randNum.NextDouble() * (screenBounds.Width - rectangleForTexture.Width);
            positionBat.Y = (float)randNum.NextDouble() * (screenBounds.Height - rectangleForTexture.Height);
            color = new Color((byte)randNum.Next(0, 256), (byte)randNum.Next(0, 256), (byte)randNum.Next(0, 256));
            stepNumber = 0;
            this.speed = new Vector2();
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        protected void Check()
        {
            if (positionBat.X < screenBounds.Left)
            {
                positionBat.X = screenBounds.Left;
            }
            if(positionBat.X>screenBounds.Width -rectangleForTexture.Width)
            {
                positionBat.X = screenBounds.Width - rectangleForTexture.Width;
            }
            if(positionBat.Y<screenBounds.Top)
            {
                positionBat.Y = screenBounds.Top;
            }
            if(positionBat.Y>screenBounds.Height-rectangleForTexture.Height)
            {
                positionBat.Y = screenBounds.Height - rectangleForTexture.Height;
            }
                
        }
        protected virtual void Move()
        {
            if(stepNumber>0)
            {
                stepNumber--;
                if (positionBat.X < newPosition.X) positionBat.X += speed.X;
                if (positionBat.X > newPosition.X) positionBat.X -= speed.X;
                if (positionBat.Y < newPosition.Y) positionBat.Y += speed.Y;
                if (positionBat.Y > newPosition.Y) positionBat.Y -= speed.Y;
                

            }
            if(stepNumber==0)
            {
                stepNumber = randNum.Next(50, 200);
                newPosition.X = (float)randNum.NextDouble() * (screenBounds.Width - rectangleForTexture.Width);
                newPosition.Y = (float)randNum.NextDouble() * (screenBounds.Height - rectangleForTexture.Height);
                speed.X = randNum.Next(0, 8);
                speed.Y = randNum.Next(0, 8);
                color = new Color((byte)randNum.Next(0, 256), (byte)randNum.Next(0, 256), (byte)randNum.Next(0, 256));
            }
            Check();
        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            Move();

        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            spriteBatch.Draw(textureBat, positionBat, rectangleForTexture, color);
            base.Draw(gameTime);
            
        }

    }
}
