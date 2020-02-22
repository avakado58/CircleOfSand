using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleOfSand
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Daron daron;
        //Lidia lidia;
        Texture2D textureMap;
        Rectangle floor;
        Vector2 vectorPositionFloor;
        CompDraw compDraw1;
        CompDraw compDraw2;
        Blast blast;
        Rectangle window;
        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            floor = new Rectangle(96, 1, 16, 16);
            vectorPositionFloor = new Vector2(0, 0);

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            this.IsMouseVisible = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
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
            window = new Rectangle(5,0,760,535);
            Texture2D textureBlast = Content.Load<Texture2D>("blast");
            //daron = new Daron(this, Content.Load<Texture2D>("main-character-walk-frame"), new Vector2(100,100), window);
            //lidia = new Lidia(this, Content.Load<Texture2D>("main-character-walk-frame"), new Vector2(300, 100), window);
            //Components.Add(lidia);
            //Components.Add(daron);
            compDraw1 = new CompDraw(this, Content.Load<Texture2D>("male"),new Vector2(100,100),new Rectangle(0,0,23,50));
            compDraw2 = new CompDraw(this, Content.Load<Texture2D>("female"), new Vector2(100, 200), new Rectangle(1,0,25,48));
            blast = new Blast(this, ref textureBlast, rectanglesBlast, compDraw1.position);
            Components.Add(compDraw1);
            Components.Add(compDraw2);
            Components.Add(blast);
            textureMap = Content.Load<Texture2D>("Floor");
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MoveUp(compDraw1, Keys.W);
            MoveDown(compDraw1, Keys.S);
            MoveLeft(compDraw1, Keys.A);
            MoveRight(compDraw1, Keys.D);

            MoveUp(compDraw2, Keys.Up);
            MoveDown(compDraw2, Keys.Down);
            MoveLeft(compDraw2, Keys.Left);
            MoveRight(compDraw2, Keys.Right);
            base.Update(gameTime);
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
                blast.positionBlast= compDraw.position;
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


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            #region 
            //while (true)
            //{
            //    spriteBatch.Draw(textureMap, vectorPositionFloor, floor, Color.FloralWhite, 0, Vector2.Zero, 1.1f, SpriteEffects.None, 1);
            //    if(vectorPositionFloor.X<Window.ClientBounds.Width)
            //    {
            //        vectorPositionFloor.X += 16;
            //    }
            //    else if(vectorPositionFloor.Y < Window.ClientBounds.Height )
            //    {
            //        vectorPositionFloor.Y += 16;
            //        vectorPositionFloor.X = 0;
            //    }
            //    else
            //    {
            //        break;
            //    }

            //}
            //vectorPositionFloor = new Vector2(0, 0);
            #endregion
            spriteBatch.Draw(textureMap, new Rectangle(0, 0, 800, 600), Color.White);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
