using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace xnaheist.Content
{
    class ResourceManager
    {
        SpriteBatch _spriteBatch;
        ContentManager _content;

        SpriteFont _font;

        public ResourceManager(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _content = content;
        }

        public void Load(List<GameObject> gameObjects)
        {
            _font = _content.Load<SpriteFont>("times new roman");

            foreach(GameObject gameObject in gameObjects) {
                gameObject.Sprite.Load(_content);
            }
        }

        public SpriteBatch GetSpriteBatch()
        {
            return _spriteBatch;
        }

        public SpriteFont GetFont()
        {
            return _font;
        }
    }
}
