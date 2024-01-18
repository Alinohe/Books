
namespace Books
{
    public class Statistics
    {
        public double Max { get; private set; }
        public double Min { get; private set; }
        public double Sum {  get; private set; }
        public int Count { get; private set; }

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            Max = double.MinValue;
            Min = double.MaxValue;
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public void Add(double value)
        {
            Sum += value;
            Count += 1;
            Min = Math.Min(value, Min);
            Max = Math.Max(value, Max);
        }
    }
}
