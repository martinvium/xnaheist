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

namespace xnaheist
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //drawing, just for testing and playing
        SpriteFont _font;
        Vector2 _textPos;


        //Debug view
        DebugViewXNA _debugView;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            _textPos = new Vector2(100, 100);

            // TODO: use this.Content to load your game content here

            
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
            spriteBatch.DrawString(_font, dummy, _textPos, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void HandleKeyboard()
        {
            KeyboardState _keyState = Keyboard.GetState();

            if (_keyState.IsKeyDown(Keys.Left))
            {
                _textPos = new Vector2(_textPos.X - 1, _textPos.Y);
            }
            if (_keyState.IsKeyDown(Keys.Right))
            {
                _textPos = new Vector2(_textPos.X + 1, _textPos.Y);
            }
            if (_keyState.IsKeyDown(Keys.Up))
            {
                _textPos = new Vector2(_textPos.X, _textPos.Y - 1);
            }
            if (_keyState.IsKeyDown(Keys.Down))
            {
                _textPos = new Vector2(_textPos.X, _textPos.Y + 1);
            }
            if (_keyState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

        }
    }
}
