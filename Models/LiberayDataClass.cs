namespace Library.Models
{
    public class LibraryData
    {

        public static List<Shelf> Shelves = new List<Shelf>
        {
            new Shelf { Id = 1, ShelfNumber = "A1", Location = "Section A", Capacity = 50 },
            new Shelf { Id = 2, ShelfNumber = "B1", Location = "Section B", Capacity = 40 },
            new Shelf { Id = 3, ShelfNumber = "C1", Location = "Section C", Capacity = 60 }
        };


    }
}
