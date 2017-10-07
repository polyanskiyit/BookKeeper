using System.ComponentModel.DataAnnotations;

namespace BookKeeper.Models
{
    public class Book
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть назву книги")]
        [Display(Name = "Назва книги")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введіть ім'я автора")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Введіть до якої категорії належить книга")]
        [Display(Name = "Категорія")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Введіть опис книги")]
        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введіть рік випуску книги")]
        [Display(Name = "Рік випуску")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Введіть ціну")]
        [Display(Name = "Ціна")]
        public int Price { get; set; }
    }
}