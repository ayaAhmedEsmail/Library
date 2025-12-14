namespace Library.Models
{
    public interface ILibrary
    {
        public string name { get; }

        public Book Book { get; }
        public Shelf Shelf { get; }


        

    }
}
