﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace xnaheist.Levels
{
    interface Level
    {
        void Initialize(GameObjectFactory gameObjectFactory);
    }
}
