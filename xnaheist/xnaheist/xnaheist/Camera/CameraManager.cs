﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace xnaheist.Camera
{
    class CameraManager
    {
        //todo->Create camera
        private Camera _camera;
        internal void GetCamera(Vector2 position, Viewport viewport)
        {
           _camera = new Camera(position, viewport);
        }
        //todo->move that shit
        private void Center()
        {
            
        }
        internal void Update(GameObject player)
        {

        }
    }
}
