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
        Daron daron;
        Lidia lidia;
        Texture2D textureMap;
        Rectangle floor;
        Vector2 vectorPositionFloor;
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
            Rectangle window = new Rectangle(5,0,760,535);
            daron = new Daron(this, Content.Load<Texture2D>("main-character-walk-frame"), new Vector2(100,100), window);
            lidia = new Lidia(this, Content.Load<Texture2D>("main-character-walk-frame"), new Vector2(300, 100), window);
            Components.Add(lidia);
            Components.Add(daron);
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

            // TODO: Add your update logic here

            base.Update(gameTime);
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
