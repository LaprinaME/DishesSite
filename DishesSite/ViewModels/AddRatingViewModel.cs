using System.ComponentModel.DataAnnotations;

namespace DishesSite.ViewModels
{
    public class AddRatingViewModel
    {
        [Required(ErrorMessage = "Идентификатор рейтинга обязателен.")]
        [Display(Name = "Идентификатор рейтинга")]
        public int RatingId { get; set; }

        [Required(ErrorMessage = "Средний рейтинг обязателен.")]
        [Range(0, 5, ErrorMessage = "Рейтинг должен быть между 0 и 5.")]
        [Display(Name = "Средний рейтинг")]
        public decimal AverageRating { get; set; }

        [Required(ErrorMessage = "Количество оценок обязательно.")]
        [Display(Name = "Количество оценок")]
        public int NumberOfRatings { get; set; }

        [Required(ErrorMessage = "Идентификатор рецепта обязателен.")]
        [Display(Name = "Идентификатор рецепта")]
        public int RecipeId { get; set; }
    }
}
