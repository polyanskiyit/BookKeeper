using System.ComponentModel.DataAnnotations;

namespace BookKeeper.Models
{
    public class Book
    {
        private const string MinYear = "0";
        private const string MaxYear = "99999";
        private const string MinPrice = "0";
        private const string MaxPrice = "9999999";
        private const string PriceErrorMessage = "Ціну можна ввести в діапазоні від " + MinPrice + " до " + MaxPrice;


        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Назва книги"), 
            Required(ErrorMessage = "Введіть назву книги")]
        public string Name { get; set; }

        [Display(Name = "Автор"), 
            Required(ErrorMessage = "Введіть ім'я автора")]
        public string Author { get; set; }

        [Display(Name = "Категорія"), 
            Required(ErrorMessage = "Введіть до якої категорії належить книга")]
        public string Category { get; set; }

        [Display(Name = "Опис"), 
            Required(ErrorMessage = "Введіть опис книги")]
        public string Description { get; set; }

        [Display(Name = "Рік випуску"), 
            Required(ErrorMessage = "Введіть рік випуску книги"), 
            Range(typeof(int), MinYear, MaxYear, ErrorMessage = "Рік випуску можна ввести в діапазоні від "+ MinYear + " до "+ MaxYear)]
        public int Year { get; set; }

        [Display(Name = "Ціна, грн"), 
            Required(ErrorMessage = "Введіть ціну"),
            Range(typeof(double), MinPrice, MaxPrice, ErrorMessage = PriceErrorMessage)]
        public double Price { get; set; }
    }
}