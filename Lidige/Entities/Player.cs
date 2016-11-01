using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidige.Entities
{
    public enum Direction {
        Up,
        Down,
        Left,
        Right
    }

    public class Player
    {
        private Texture2D _texture;
        private Vector2 _position = new Vector2(0, 0);

        // http://gamedev.stackexchange.com/questions/34365/how-can-i-accomplish-pokemon-style-movement-over-tiles-in-java
        private float _duration = 0.25f;
        private float _t;
        private Vector2 _targetPosition;

        public Player(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update(float delta)
        {
            _t = delta / _duration;
            _position = _position + (_targetPosition - _position) * _t;
        }

        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Down:
                    _targetPosition = _position + new Vector2(0, 1);
                    break;

                case Direction.Up:
                    _targetPosition = _position - new Vector2(0, 1);
                    break;

                case Direction.Right:
                    _targetPosition = _position + new Vector2(1, 0);
                    break;

                case Direction.Left:
                    _targetPosition = _position - new Vector2(1, 0);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)_position.X * 32, (int)_position.Y * 32, 48, 64), new Rectangle(0, 0, 48, 64), Color.White);
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }
    }
}
