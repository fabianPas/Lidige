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
        Up = 0,
        Down = 3,
        Left = 6,
        Right = 9
    }

    public class Player
    {
        private readonly Texture2D _texture;

        private Vector2 _position = new Vector2(0, 0);
        private Vector2 _targetPosition;
        private bool _isMoving;
        private Direction _direction;

        private const float Duration = 0.10f;

        public Player(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update(float delta)
        {
            if (Vector2.Distance(_position, _targetPosition) < 0.1f)
            {
                _position = _targetPosition;
                _isMoving = false;
            }

            var t = delta / Duration;
            _position = _position + (_targetPosition - _position) * t;
        }

        public void Move(Direction direction)
        {
            if (_isMoving)
                return;

            _isMoving = true;

            switch (direction)
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

            _direction = direction;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)_position.X * 32, (int)_position.Y * 32, 48, 64), new Rectangle((int)_direction * 48, 0, 48, 64), Color.White);
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
