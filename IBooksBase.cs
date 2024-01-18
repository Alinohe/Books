namespace Books
{
    public interface IBooksBase
    {
        string Title { get; set; }
        string Writer { get; set; }

        void AddRate(char rate);
        void AddRate(double rate);
        void AddRate(float rate);
        void AddRate(int rate);
        void AddRate(string rate);
        Statistics GetStatistics();
    }
}