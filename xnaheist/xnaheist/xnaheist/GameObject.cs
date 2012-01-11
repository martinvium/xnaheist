using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using xnaheist.Content;

namespace xnaheist
{
    class GameObject
    {
        string name;
        Body body;
        Sprite _sprite;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Body Body
        {
            get { return body; }
            set { body = value; }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
