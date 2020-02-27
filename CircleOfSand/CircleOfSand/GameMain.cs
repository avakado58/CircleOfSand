using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CircleOfSand
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D textureMap;
        Rectangle floor;
        Vector2 vectorPositionFloor;
        Random random = new Random();
        Control control;
        public int CountEnemy = 10;
        public int Score { get; set; } = 0;
        private bool flagWin = false;
        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            floor = new Rectangle(96, 1, 16, 16);
            vectorPositionFloor = new Vector2(0, 0);
            TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 50);

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
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
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
            textureMap = Content.Load<Texture2D>("Floor");
            
            CreateObj();
            
        }

        protected virtual void CreateObj()
        {
            
            Texture2D textureForBat = Content.Load<Texture2D>("textureForBat");
            for (int i = 0; i < CountEnemy; i++)
            {
                Components.Add(new Bat(this, ref textureForBat, i*i-(int)Math.Cos(i)));
            }
            control = new Control(this);
            Components.Add(control);

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

            if(Score==CountEnemy&&!flagWin)
            {
                Window.Title = "Победа! Прошло времени " + gameTime.TotalGameTime.ToString();
               
                
                flagWin = true;
            }
            else if(Score!=CountEnemy)
            {
                Window.Title ="Счет "+ Score+" прошло времени "+ gameTime.TotalGameTime.ToString();

            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
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
