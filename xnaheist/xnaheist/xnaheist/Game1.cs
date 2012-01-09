using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using FarseerPhysics.DebugViews;
using FarseerPhysics.Dynamics;
using FarseerPhysics;
using FarseerPhysics.Factories;

namespace xnaheist
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;

        //drawing, just for testing and playing
        SpriteFont _font;
        
        Body _textBody;

        World _world = new World(new Vector2(2, 20));

        //Debug view
        bool _showDebug = false;
        DebugViewXNA _debugView;
        Vector2 _screenCenter;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);           
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

            //_graphics.IsFullScreen = true;

            //borders
            BodyFactory.CreateEdge(_world, new Vector2(0, 0) / 64f, new Vector2(0, _graphics.PreferredBackBufferWidth) / 64f);
            BodyFactory.CreateEdge(_world, new Vector2(0, 0) / 64f, new Vector2(_graphics.PreferredBackBufferHeight, 0) / 64f);
            BodyFactory.CreateEdge(_world, new Vector2(0, _graphics.PreferredBackBufferWidth) / 64f, new Vector2(_graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth) / 64f);
            BodyFactory.CreateEdge(_world, new Vector2(_graphics.PreferredBackBufferHeight, 0) / 64f, new Vector2(_graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth) / 64f);

            Content.RootDirectory = "Content";
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //todo->test things
            _font = Content.Load<SpriteFont>("times new roman");
            _textBody = BodyFactory.CreateRectangle(_world, 100, 20, 1, new Vector2(5,5));
            _textBody.BodyType = BodyType.Dynamic;
            

            // TODO: use this.Content to load your game content here

            _screenCenter = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2f,
                                                _graphics.GraphicsDevice.Viewport.Height / 2f);
            _debugView = new DebugViewXNA(_world);
            _debugView.AppendFlags(DebugViewFlags.DebugPanel);
            _debugView.DefaultShapeColor = Color.Black;
            _debugView.SleepingShapeColor = Color.LightGray;
            _debugView.LoadContent(GraphicsDevice, Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            
            //todo-> test things
            HandleKeyboard();
            // TODO: Add your update logic here
            _world.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);
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
            // TODO: Add your drawing code here
            string dummy = "The fish is flying high to day!";
            spriteBatch.DrawString(_font, dummy, _textBody.Position * 64f, Color.White);

            spriteBatch.End();

            // calculate the projection and view adjustments for the debug view
            Matrix projection = Matrix.CreateOrthographicOffCenter(0f, _graphics.GraphicsDevice.Viewport.Width / 64,
                                                             _graphics.GraphicsDevice.Viewport.Height / 64, 0f, 0f,
                                                             1f);
            Matrix view = Matrix.CreateTranslation(new Vector3((Vector2.Zero/ 64) - (_screenCenter / 64), 0f)) * Matrix.CreateTranslation(new Vector3((_screenCenter / 64), 0f));

            if (_showDebug)
                _debugView.RenderDebugData(ref projection, ref view);


            base.Draw(gameTime);
        }

        private void HandleKeyboard()
        {
            KeyboardState _keyState = Keyboard.GetState();

            if (_keyState.IsKeyDown(Keys.Left))
            {
                _textBody.ApplyForce(new Vector2(20, 0));
            }
            if (_keyState.IsKeyDown(Keys.Right))
            {
                _textBody.ApplyLinearImpulse(new Vector2(3, 0));
            }
            if (_keyState.IsKeyDown(Keys.Up))
            {
                _textBody.ApplyLinearImpulse(new Vector2(0, -3.0f));
            }
            if (_keyState.IsKeyDown(Keys.Down))
            {
                _textBody.ApplyLinearImpulse(new Vector2(0, 3.0f));
            }
            if (_keyState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (_keyState.IsKeyDown(Keys.LeftAlt))
            {
                _showDebug = true;
            }
            else
            {
                _showDebug = false;
            }

        }
    }
}
