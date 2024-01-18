namespace Books
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WritelineColor(ConsoleColor.Magenta, "Hello to the [Book's Rate] console.");

            bool CloseApp = false;

            while (!CloseApp)
            {
                Console.WriteLine();
                WritelineColor(ConsoleColor.Cyan,
                    "1 - Add Book's rate to the program memory and show statistics\n" +
                    "2 - Add Book's rate to the .txt file and show statistics\n" +
                    "X - Close app\n");

                WritelineColor(ConsoleColor.Yellow, "What you want to do? \nPress key 1, 2 or X: ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        AddRatesToMemory();
                        break;

                    case "2":
                        AddRatesToFile();
                        break;

                    case "X":
                        CloseApp = true;
                        break;

                    default:
                        WritelineColor(ConsoleColor.Red, "Invalid operation.\n");
                        continue;
                }
            }
            WritelineColor(ConsoleColor.DarkYellow, "\n\nBye Bye! Press any key to leave.");
            Console.ReadKey();
        }

        private static void AddRatesToMemory()
        {
            string title = GetValueFromUser("Please insert book title:");
            string writer = GetValueFromUser("Please insert book writer:");
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(writer))
            {
                var inMemoryBook = new BooksInMemory(title, writer);
                EnterRate(inMemoryBook);
                inMemoryBook.ShowStatistics();
            }
            else
            {
                WritelineColor(ConsoleColor.Red, "book's title and writen name can not be empty!");
            }
        }

        private static void AddRatesToFile()
        {
            string title = GetValueFromUser("Please insert book's Title: ");
            string writer = GetValueFromUser("Please insert book's Writer name: ");
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(writer))
            {
                var savedBook = new BooksInFile(title, writer);
                EnterRate(savedBook);
                savedBook.ShowStatistics();
            }
            else
            {
                WritelineColor(ConsoleColor.Red, "Student's firstname and lastname can not be empty!");
            }
        }

        private static void EnterRate(IBooks book)
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, $"Enter rate for {book.Title} {book.Writer}:");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    book.AddRate(input);
                }
                catch (FormatException ex)
                {
                    WritelineColor(ConsoleColor.Red, ex.Message);
                }
                catch (ArgumentException ex)
                {
                    WritelineColor(ConsoleColor.Red, ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    WritelineColor(ConsoleColor.Red, ex.Message);
                }
                finally
                {
                    WritelineColor(ConsoleColor.DarkMagenta, $"To leave and show {book.Title} {book.Writer} statistics enter 'q'.");
                }
            }
        }

        private static void WritelineColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static string GetValueFromUser(string comment)
        {
            WritelineColor(ConsoleColor.Yellow, comment);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }



}