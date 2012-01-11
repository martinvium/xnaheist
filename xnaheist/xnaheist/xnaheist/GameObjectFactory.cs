using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;

namespace xnaheist
{
    class GameObjectFactory
    {
        World _world;

        public GameObjectFactory(World world)
        {
            _world = world;
        }

        public GameObject getPlayer()
        {
            GameObject player = getCreature();
            player.Body = BodyFactory.CreateRectangle(_world, 300 / Game1.TILE_SIZE, 100 / Game1.TILE_SIZE, 1, new Vector2(5, 5));
            player.Body.BodyType = BodyType.Dynamic;
            player.Body.OnCollision += OnCollision;
            return player;
        }

        public GameObject getCreature()
        {
            GameObject creature = new GameObject();
            return creature;
        }

        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            return true;
        }
    }
}
