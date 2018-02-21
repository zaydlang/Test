namespace Nez
{
    public class StartEndValueBounds<T>
    {
        public ValueBounds<T> start { get; set; } = new ValueBounds<T>();
        public ValueBounds<T> end { get; set; } = new ValueBounds<T>();

        public StartEndValueBounds(T val) : this(val, val)
        {
        }

        public StartEndValueBounds(T startMin, T startMax) : this(startMin, startMax, startMin, startMax)
        {
        }

        public StartEndValueBounds(T startMin, T startMax, T endMin, T endMax)
        {
            this.start.min = startMin;
            this.start.max = startMax;
            this.end.min = endMin;
            this.end.max = endMax;
        }
    }
}