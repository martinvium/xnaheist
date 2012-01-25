using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using xnaheist.Content;
using Microsoft.Xna.Framework;

namespace xnaheist
{
    class GameObject
    {
        string name;
        Body body;
        Sprite _sprite;
        Vector2 _position;
        
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

        public Vector2 Position
        {
            get 
            {
                if (body != null)
                {
                    return body.Position * Globals.METER_IN_PIXEL;
                }
                else if (_position != null)
                {
                    return _position;
                }
                else
                {
                    throw new InvalidOperationException("GameObject missing position: " + this);
                }
            }
            set { _position = value; }
        }
    }
}
