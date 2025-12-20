
using Microsoft.EntityFrameworkCore;

namespace Library.Models.Sales
{
    public class SalesRepository(ApplicationDBContext context) : ISalesRepository
    {
        public List<Sales> GetAllSales()
        {
            // include is imp to load book data.
            var result = context.Sales.Include(s => s.Book).ToList();
            return context.Sales.ToList();
            
        }
    }
}
