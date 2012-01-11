using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace xnaheist.Content
{
    class Sprite
    {
        string _name = "";
        Texture2D _texture;
        Vector2 _size;

        public Sprite(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public void Load(ContentManager content)
        {
            _texture = content.Load<Texture2D>(_name);
            _size = new Vector2(_texture.Width, _texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Vector2 normalizedPos = Vector2.Subtract(position, Vector2.Divide(_size, 2));
            spriteBatch.Draw(_texture, normalizedPos, Color.White);
        }
    }
}
