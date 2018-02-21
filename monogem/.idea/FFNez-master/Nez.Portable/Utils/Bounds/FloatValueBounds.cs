namespace Nez
{
    public class FloatValueBounds : ValueBounds<float>
    {
        public FloatValueBounds(float val) : base(val)
        {
        }

        public FloatValueBounds(float min, float max) : base(min, max)
        {
        }

        public void setMidpoint(float mid)
        {
            var diff = max - min;
            min = mid - diff / 2;
            max = mid + diff / 2;
        }

        public float nextValue()
        {
            return min + (max - min) * Random.nextFloat();
        }
    }
}