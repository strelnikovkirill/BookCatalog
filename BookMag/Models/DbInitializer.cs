using System.Collections.Generic;
using System.Data.Entity;

namespace BookMag.Models
{
    public class DbInitializer: DropCreateDatabaseAlways<BookContext>
    {

        protected override void Seed(BookContext context)
        {
            List<Book> books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Author = "Тлстой Л.Н." ,
                    Genre = "Исторический Роман",
                    Name = "Война и Мир"
                },
                new Book
                {
                    Id = 2,
                    Author = "Гоголь Н.В.",
                    Genre = "Политика, Сатира",
                    Name = "Мёртвые Души"
                },
                new Book
                {
                    Id = 2,
                    Author = "Пушкин А.С.",
                    Genre = "Роман",
                    Name = "Дубровский"
                }
            };

            foreach (Book book in books)
                context.Books.Add(book);

            List<BookReview> reviews = new List<BookReview>
            {
                new BookReview
                {
                    Id = 1,
                    Name = "Вася",
                    Review = "Прикольно",
                    BookId = 1,
                    Likes = 5
                },
                new BookReview
                {
                    Id = 2,
                    Name = "Иван",
                    Review = "Класс",
                    BookId = 2,
                    Likes = 0
                },
            };

            foreach (BookReview review in reviews)
                context.Reviews.Add(review);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}