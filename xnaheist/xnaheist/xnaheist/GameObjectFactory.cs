using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;
using xnaheist.Content;
using Microsoft.Xna.Framework.Graphics;

namespace xnaheist
{
    class GameObjectFactory
    {
        World _world;
        List<GameObject> _gameObjects = new List<GameObject>();

        public GameObjectFactory(World world)
        {
            _world = world;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Sprite.Draw(spriteBatch, gameObject.Position);
            }
        }

        public GameObject getPlayer()
        {
            float width = 357 / Globals.METER_IN_PIXEL;
            float height = 480 / Globals.METER_IN_PIXEL;

            GameObject player = getGameObject();
            player.Body = BodyFactory.CreateRectangle(_world, width, height, 1, new Vector2(5, 5));
            player.Body.BodyType = BodyType.Dynamic;
            player.Body.Mass = 5;
            player.Body.OnCollision += OnCollision;
            player.Sprite = new Sprite("player");
            return player;
        }

        public GameObject getGameObject()
        {
            GameObject creature = new GameObject();
            _gameObjects.Add(creature);
            return creature;
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            return true;
        }

        public List<GameObject> getAll()
        {
            return _gameObjects;
        }

        public GameObject getBackground(string file)
        {
            GameObject bg = getGameObject();
            bg.Sprite = new Sprite(file);
            bg.Position = new Vector2(1280 / 2, 720 / 2);
            return bg;
        }
    }
}
