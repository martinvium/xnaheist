using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;
using xnaheist.Content;

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

        public GameObject getPlayer()
        {
            GameObject player = getGameObject();
            player.Body = BodyFactory.CreateRectangle(_world, 357 / Game1.TILE_SIZE, 480 / Game1.TILE_SIZE, 1, new Vector2(5, 5));
            player.Body.BodyType = BodyType.Dynamic;
            player.Body.Mass = 5;
            player.Body.OnCollision += OnCollision;
            player.Sprite = new Sprite("chef");
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
            bg.Position = Vector2.Zero;
            return bg;
        }
    }
}
