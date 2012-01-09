using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;

namespace xnaheist
{
    class GameObject
    {
        Body body;

        public Body Body
        {
            get { return body; }
            set { body = value; }
        }
    }
}
