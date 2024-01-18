namespace Books
{
    public class Book
    {
        public Book(string title, string writer)
        {
            this.Title = title;
            this.Writer = writer;
        }
        public virtual string Title { get; set; }
        public virtual string Writer {  get; set; }
    }
}
