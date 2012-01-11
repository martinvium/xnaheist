using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;

namespace xnaheist
{
    class GameObject
    {
        string name;
        Body body;
        
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

        public override string ToString()
        {
            return name;
        }
    }
}
