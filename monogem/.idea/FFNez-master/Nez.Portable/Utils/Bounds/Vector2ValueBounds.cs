using Microsoft.Xna.Framework;

namespace Nez
{
    public class Vector2ValueBounds : ValueBounds<Vector2>
    {
        public Vector2ValueBounds(Vector2 val) : base(val)
        {
        }

        public Vector2ValueBounds(Vector2 min, Vector2 max) : base(min, max)
        {
        }

        public Vector2 nextValue()
        {
            var nX = min.X + (max.X - min.X) * Random.nextFloat();
            var nY = min.Y + (max.Y - min.Y) * Random.nextFloat();
            return new Vector2(nX, nY);
        }
    }
}