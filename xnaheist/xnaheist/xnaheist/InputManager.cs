using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace xnaheist
{
    class InputManager
    {
        const float VELOCITY = 3.0f;

        GameObject gameObject;
        Game1 game;

      

        public InputManager(Game1 game)
        {
            
            this.game = game;  
   
        }

        public GameObject Player
        {
            get { return gameObject; }
            set { gameObject = value; }
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            GamePadState padState = GamePad.GetState(PlayerIndex.One);

            if (padState.ThumbSticks.Left.X > 0)//left
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(VELOCITY, 0));
                
            }
            if (padState.ThumbSticks.Left.X < 0)//right
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(-VELOCITY, 0));
            }
            if (padState.ThumbSticks.Left.Y > 0)//up
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(0, -VELOCITY));
            }
            if (padState.ThumbSticks.Left.Y < 0)//down
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(0, VELOCITY));
            }



            if (padState.ThumbSticks.Right.X > 0)//left
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(VELOCITY, 0));
                
            }
            if (padState.ThumbSticks.Right.X < 0)//right
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(-VELOCITY, 0));
            }
            if (padState.ThumbSticks.Right.Y > 0)//up
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(0, -VELOCITY));
            }
            if (padState.ThumbSticks.Right.Y < 0)//down
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(0, VELOCITY));

            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(-VELOCITY, 0));
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(VELOCITY, 0));
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(0, -VELOCITY));
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                gameObject.Body.ApplyLinearImpulse(new Vector2(0, VELOCITY));
            }

            if (keyState.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }

            if (keyState.IsKeyDown(Keys.LeftAlt))
            {
                game.ShowDebug = true;
            }
            else
            {
                game.ShowDebug = false;
            }
        }
    }
}
