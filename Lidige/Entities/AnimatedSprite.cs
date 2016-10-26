using Microsoft.Xna.Framework.Graphics;

namespace Lidige.Entities
{
    public class AnimatedSprite
    {
        private int _currentFrame;
        private int _totalFrames;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            _currentFrame = 0;
            _totalFrames = rows * columns;

            Texture = texture;
            Rows = rows;
            Columns = columns;
          }


        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

       
    }
}