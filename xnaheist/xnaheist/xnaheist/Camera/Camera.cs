using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace xnaheist.Camera
{
    class Camera
    {
        private Vector2 _position;
        private float _aspectRatio;
        private Matrix _projection;

        public Camera(Vector2 position, Viewport viewport)
        {
            _position = position;
            _aspectRatio = (float)viewport.Width / (float)viewport.Height;
            _projection = Matrix.CreatePerspectiveFieldOfView(
                                    MathHelper.ToRadians(40.0f),
                                    this._aspectRatio,
                                    1.0f,
                                    10000.0f);
        }

        internal void Update()
        {
            _position.X += Globals.CAMERA_STEP;
        }
         #region Properties
        public Vector2 Position
        {
            get { return _position; }
        }
        public Matrix ViewMatrix
        {
            get
            {
                return Matrix.CreateTranslation(_position.X, _position.Y, 0);
            }
        }
         #endregion
    }
}
