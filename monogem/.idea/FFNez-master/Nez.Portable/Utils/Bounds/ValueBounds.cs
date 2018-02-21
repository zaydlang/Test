namespace Nez
{
    public class ValueBounds<T>
    {
        public T min { get; set; }
        public T max { get; set; }

        public ValueBounds() : this(default(T))
        {
        }

        public ValueBounds(T val) : this(val, val)
        {
        }

        public ValueBounds(T min, T max)
        {
            set(min, max);
        }

        public void set(T min, T max)
        {
            this.min = min;
            this.max = max;
        }

        public static implicit operator ValueBounds<T>(T val)
        {
            return new ValueBounds<T>(val);
        }
    }
}