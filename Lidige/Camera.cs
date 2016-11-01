using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige
{

    //http://gamedev.stackexchange.com/questions/59301/xna-2d-camera-scrolling-why-use-matrix-transform
    public class Camera
    {
        private readonly Viewport _viewport;
        private Vector2 _position;
        private Vector2 _origin;

        public Camera(Viewport viewport)
        {
            _viewport = viewport;
            _origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            _position = Vector2.Zero;
        }

        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-_position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-_origin, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(_origin, 0.0f));
        }

        public void LookAt(Vector2 position)
        {
            Position = (position * 32) - new Vector2(_viewport.Width / 2.0f, _viewport.Height / 2.0f);
        }

        public Vector2 Position {
            get
            {
                return _position;
            }

            set
            {
                var screenWidth = 1024;
                var screenHeight = 800;

                var maximumX = (32 * 64) - (screenWidth);
                var maximumY = (32 * 64) - (screenHeight);

                var maximumPos = new Vector2(maximumX, maximumY);
                var minimumPos = new Vector2(0, 0);

                _position = Vector2.Clamp(value, minimumPos, maximumPos);
            }
        }

        public Vector2 Origin
        {
            get
            {
                return _origin;
            }

            set
            {
                _origin = value;
            }
        }
    }
}
