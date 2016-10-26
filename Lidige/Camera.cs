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
        private float _rotation;
        private float _zoom;

        public Camera(Viewport viewport)
        {
            _viewport = viewport;

            _rotation = 0;
            _zoom = 1;
            _origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            _position = Vector2.Zero;
        }

        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }

        public Vector2 Position {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
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

        public float Rotation
        {
            get
            {
                return _rotation;
            }

            set
            {
                _rotation = value;
            }
        }

        public float Zoom
        {
            get
            {
                return _zoom;
            }

            set
            {
                _zoom = value;
            }
        }
    }
}
