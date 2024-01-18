using System.Text;

namespace Books
{
    public class BooksInMemory : BooksBase
    {
        private List<double> rates;
        private string title;
        private string writer;

        public override string Title
        {
            get
            {
                return $"{char.ToUpper(title[0])} {title.Substring(1, title.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    title = value;
                }
            }
        }

        public override string Writer
        {
            get
            {
                return $"{char.ToUpper(writer[0])}.";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    writer = value;
                }
            }
        }
        public BooksInMemory(string title, string writer) : base(title, writer)
        {
            rates = new List<double>();
        }


        public void ChangeTitle(string newTitle)
        {
            string oldTitle = this.title;
            foreach (char c in newTitle)
            {
                if (char.IsDigit(c))
                {
                    this.Title = oldTitle;
                    break;
                }
                else
                {
                    this.Title = newTitle;
                }
            }
        }
        public override void AddRate(double rate)
        {
            if (rate > 0 && rate <= 9)
            {
                rates.Add(rate);
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
            }
        }

        public override void ShowRates()
        {
            StringBuilder sb = new StringBuilder($"{this.Title} {this.Writer} rates are: ");
            for (int i = 0; i < rates.Count; i++)
            {
                if (i == rates.Count - 1)
                {
                    sb.Append($"{rates[i]}.");
                }
                else
                {
                    sb.Append($"{rates[i]}; ");
                }
            }
            Console.WriteLine($"\n{sb}");
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var rate in rates)
            {
                result.Add(rate);
            }
            return result;
        }
    }

}
