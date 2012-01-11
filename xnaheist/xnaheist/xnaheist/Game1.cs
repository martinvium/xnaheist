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
using FarseerPhysics.Dynamics.Contacts;

namespace xnaheist
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public const float TILE_SIZE = 64f;
        public const int WIDTH = 1280;
        public const int HEIGHT = 720;
        public const float VELOCITY = 3.0f;

        GraphicsDeviceManager _graphics;

        World _world = new World(new Vector2(0, 20));

        //Debug view
        bool _showDebug = false;
        DebugViewXNA _debugView;
        Vector2 _screenCenter;
        InputManager _inputManager;
        GameObject _player;
        GameObjectFactory _gameObjectFactory;
        ResourceManager _resources;

        Camera.Camera _cam;

        public bool ShowDebug
        {
            set { _showDebug = value; }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);           
            _graphics.PreferredBackBufferWidth = WIDTH;
            _graphics.PreferredBackBufferHeight = HEIGHT;

            //_graphics.IsFullScreen = true;

            //borders
            //top
            BodyFactory.CreateEdge(_world, new Vector2(0, 0) / TILE_SIZE, new Vector2(0, WIDTH) / TILE_SIZE);
            //left
            BodyFactory.CreateEdge(_world, new Vector2(0, 0) / TILE_SIZE, new Vector2(WIDTH, 0) / TILE_SIZE);
            //right
            BodyFactory.CreateEdge(_world, new Vector2(WIDTH, 0) / TILE_SIZE, new Vector2(WIDTH, HEIGHT) / TILE_SIZE);
            //bottom
            BodyFactory.CreateEdge(_world, new Vector2(0, HEIGHT) / TILE_SIZE, new Vector2(WIDTH, HEIGHT) / TILE_SIZE);

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
            _resources = new ResourceManager(Content, new SpriteBatch(GraphicsDevice));
            _gameObjectFactory = new GameObjectFactory(_world);
            _player = _gameObjectFactory.getPlayer();
            _player.Name = "Mr. Shizzle";

            _inputManager = new InputManager(this);
            _inputManager.Player = _player;

            _cam = new Camera.Camera(new Vector2(0, 0), GraphicsDevice.Viewport);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _resources.Load();
            

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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

            _inputManager.Update();
            _world.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);
            _cam.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch spriteBatch = _resources.GetSpriteBatch();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _cam.ViewMatrix);
            spriteBatch.DrawString(_resources.GetFont(), _player.ToString(), _player.Body.Position * TILE_SIZE, Color.White);
            spriteBatch.End();

            // calculate the projection and view adjustments for the debug view
            Matrix projection = Matrix.CreateOrthographicOffCenter(0f, _graphics.GraphicsDevice.Viewport.Width / TILE_SIZE,
                                                             _graphics.GraphicsDevice.Viewport.Height / TILE_SIZE, 0f, 0f,
                                                             1f);
            Matrix view = Matrix.CreateTranslation(new Vector3((Vector2.Zero / TILE_SIZE) - (_screenCenter / TILE_SIZE), 0f)) * Matrix.CreateTranslation(new Vector3((_screenCenter / TILE_SIZE), 0f));

            if (_showDebug)
                _debugView.RenderDebugData(ref projection, ref view);


            base.Draw(gameTime);
        }

        
    }
}
