using System.Runtime.CompilerServices;
using static Books.BooksBase;

namespace Books
{
    public interface IBooks
    {
        string Title { get; set; }
        string Writer { get; set; }
        

       void AddRate(float rate);
        void AddRate(double rate);
        void AddRate(int rate);
        void AddRate(string rate);
        void AddRate(char rate);
        void showRates();

        Statistics GetStatistics();
        void ShowStatistics();
    }
}
