using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CircleOfSand
{
    enum BlastState
    {
        None = 0,
        Normal = 1,
        Explosion
    }
    class Blast : DrawableGameComponent
    {

        Texture2D textureBlast;
        bool isLeftButtonPres = false;
        BlastState blastState;
        Vector2 positionClic = new Vector2();
        public Vector2 beginPositionBlast;
        public Vector2 positionBlast;
        Rectangle[] rectangle;
        Game game;
        public bool FlagAnim { get; private set; } = false;
        bool isLeftAlreadyPres = false;
        int iteration = -1;
        public Blast(Game game, ref Texture2D textureBlast, Rectangle[] rectangle, Vector2 beginPositionBlast) : base(game)
        {
            this.textureBlast = textureBlast;
            this.beginPositionBlast.X = beginPositionBlast.X;
            this.beginPositionBlast.Y = beginPositionBlast.Y;
            positionBlast = beginPositionBlast;
            this.rectangle = rectangle;
            this.game = game;
            blastState = BlastState.None;
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState(game.Window);



            if (mouseState.LeftButton == ButtonState.Pressed && !isLeftAlreadyPres)
            {
                isLeftAlreadyPres = true;
                isLeftButtonPres = true;
                blastState = BlastState.Normal;
                positionClic.X = mouseState.X - rectangle[0].Width/2;
                positionClic.Y = mouseState.Y - rectangle[0].Height / 2;
                //positionClic = mouseState.Position.ToVector2();
                
            }



            if (isLeftButtonPres && FlagAnim)
            {

                #region
                //pX = (int)positionClic.X;
                //pY = (int)positionClic.Y;
                //pBX = (int)beginPositionBlast.X;
                //pBY = (int)beginPositionBlast.Y;
                //if (pX - pBX > 0)
                //{
                //    beginPositionBlast.X += 1;
                //}
                //else if (pX - pBX < 0)
                //{
                //    beginPositionBlast.X -= 10;
                //}
                //else
                //{

                //}
                //if (pY - pBY > 0)
                //{
                //    beginPositionBlast.Y += 1;
                //}
                //else if (pY - pBY < 0)
                //{
                //    beginPositionBlast.Y -= 10;
                //}
                //else
                //{

                //}
                //if (pX - pBX == 0 && pY - pBY == 0)
                //{
                //    blastState = BlastState.Explosion;


                //}
                #endregion
                if (beginPositionBlast == positionClic)
                {
                    blastState = BlastState.Explosion;


                }
                beginPositionBlast = positionClic;



                if (blastState == BlastState.Explosion)
                {
                    iteration++;
                    if (iteration == 7)
                    {
                        iteration = -1;
                        blastState = BlastState.None;
                        beginPositionBlast = positionBlast;
                        FlagAnim = false;
                        isLeftAlreadyPres = false;

                    }
                }


            }




            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {

            SpriteBatch spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            switch (blastState)
            {
                case BlastState.Normal:
                    FlagAnim = true;
                    spriteBatch.Draw(textureBlast, beginPositionBlast, rectangle[0],
                    Color.FloralWhite, 0, Vector2.Zero, 1.1f, SpriteEffects.None, 1);



                    break;
                case BlastState.Explosion:
                    spriteBatch.Draw(textureBlast, beginPositionBlast, rectangle[iteration],
                    Color.FloralWhite, 0, Vector2.Zero, 1.1f, SpriteEffects.None, 1);
                    break;
                default:
                    break;
            }
            base.Draw(gameTime);
        }
    }
}
