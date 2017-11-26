using System.Data.Entity;

namespace BookMag.Models
{
    public class BookContext : DbContext
    {
        public BookContext()
        {
            //Для тестовой инициализации
            //Database.SetInitializer<BookContext>(new DbInitializer());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReview> Reviews { get; set; }
    }
}