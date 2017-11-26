using System;
using System.ComponentModel.DataAnnotations;

namespace BookMag.Models
{

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Название Книги")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        public void Update(Book newBookData)
        {
            Name = newBookData.Name;
            Genre = newBookData.Genre;
            Author = newBookData.Author;
            Genre = newBookData.Genre;
        }

        public string FullName
        {
            get
            {
                String result = String.Format("{0}, {1}, {2}",
                                              Name,
                                              Author,
                                              Genre);
                return result;
            }
        }
    }
}