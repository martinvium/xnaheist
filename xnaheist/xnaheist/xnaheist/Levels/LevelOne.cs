using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xnaheist.Levels
{
    class LevelOne : Level
    {
        private GameObject _bg;

        public void Initialize(GameObjectFactory gameObjectFactory)
        {
            _bg = gameObjectFactory.getBackground("background");
        }
    }
}
