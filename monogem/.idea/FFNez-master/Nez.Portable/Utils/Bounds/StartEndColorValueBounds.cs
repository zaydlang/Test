using Microsoft.Xna.Framework;

namespace Nez
{
    public class StartEndColorValueBounds : StartEndValueBounds<Color>
    {
        public StartEndColorValueBounds(Color val) : base(val)
        {
        }

        public StartEndColorValueBounds(Color startMin, Color startMax) : base(startMin, startMax)
        {
        }

        public StartEndColorValueBounds(Color startMin, Color startMax, Color endMin, Color endMax) : base(startMin,
            startMax, endMin, endMax)
        {
        }

        public (Color, Color) nextValues()
        {
            return (new ColorValueBounds(start.min, start.max).nextValue(), new ColorValueBounds(end.min, end.max)
                .nextValue());
        }
    }
}