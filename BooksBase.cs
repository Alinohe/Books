namespace Books
{
    public abstract class BooksBase : Book, IBooks
    {

         public override string Title { get; set; }
        public override string Writer { get; set; }

        public BooksBase(string title, string writer) : base(title, writer)
        {

        }

        public abstract void AddRate(float rate);

        public abstract void AddRate(double rate);

        public abstract void AddRate(int rate);

        public void AddRate(string rate)
        {
            double convertedRateToDouble = char.GetNumericValue(rate[0]);
            if (rate.Length == 2 && char.IsDigit(rate[0]) && rate[0] <= '9' && (rate[1] == '+' || rate[1] == '-'))
            {
                switch (rate[1])
                {
                    case '+':
                        double ratePlus = convertedRateToDouble + 0.50;
                        if (ratePlus > 1 && ratePlus <= 9)
                        {
                            AddRate(ratePlus);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
                        }
                        break;

                    case '-':
                        double rateMinus = convertedRateToDouble - 0.250;

                        if ((rateMinus > 1 && rateMinus <= 9))
                        {
                            AddRate(rateMinus);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
                }
            }
            else
            {
                double rateDouble = 0;
                var isParsed = double.TryParse(rate, out rateDouble);
                if (isParsed && rateDouble > 0 && rateDouble <= 9)
                {
                    AddRate(rateDouble);
                }
                else
                {
                    throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
                }
            }
        }
        public abstract void ShowRates();
        public abstract Statistics GetStatistics();
        public abstract void AddRate(char rate);

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                ShowRates();
                Console.WriteLine($"{Title} {Writer} statistics:");
                //Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Total grades: {stat.Count}");
                // Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Highest grade: {stat.Max:N2}");
                // Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Lowest grade: {stat.Min:N2}");
                // Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Average: {stat.Average:N2}");
                Console.WriteLine();
                //Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Couldn't get statistics for {this.Title} {this.Writer} because no grade has been added.");
                Console.ResetColor();
            }
        }

        public void showRate()
        {
            throw new NotImplementedException();
        }

        public void showRates()
        {
            throw new NotImplementedException();
        }
    }
}






