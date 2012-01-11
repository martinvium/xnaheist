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
        private Vector2 _screenCenter;

 
        private float _aspectRatio;
        private Matrix _projection;
        private Vector2 _half;

        public Camera(Vector2 position, Viewport viewport)
        {
            _position = position;
            _half = new Vector2(viewport.Width * 0.5f, viewport.Height * 0.5f);
            _aspectRatio = (float)viewport.Width / (float)viewport.Height;
            _projection = Matrix.CreatePerspectiveFieldOfView(
                                    MathHelper.ToRadians(40.0f),
                                    this._aspectRatio,
                                    1.0f,
                                    10000.0f);
        }

        internal void Update(Vector2 playerPosition)
        {
            ////todo->Set cam position
         
            if (Math.Abs(_position.X + _half.X) < playerPosition.X * Globals.METER_IN_PIXEL)
            {
                _position.X += 1.0f;
            }
      
            if (Math.Abs(_position.X + _half.X) > playerPosition.X * Globals.METER_IN_PIXEL)
            {
                _position.X -= 1.0f;
            }
            
            UpdateScreenCenter();
        }
        private void UpdateScreenCenter()
        {
            _screenCenter = new Vector2(_position.X + _half.X, _position.Y + _half.Y);
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
        public Vector2 ScreenCenter
        {
            get { return _screenCenter; }
            set { _screenCenter = value; }
        }
         #endregion
    }
}
