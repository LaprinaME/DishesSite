using System.ComponentModel.DataAnnotations;

namespace DishesSite.ViewModels
{
    public class AddRecipesViewModel
    {
        [Required(ErrorMessage = "Идентификатор рецепта обязателен.")]
        [Display(Name = "Идентификатор рецепта")]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Название рецепта обязательно.")]
        [StringLength(255, ErrorMessage = "Длина названия рецепта не может превышать 255 символов.")]
        [Display(Name = "Название рецепта")]
        public string RecipeName { get; set; }

        [Display(Name = "Описание рецепта")]
        public string Description { get; set; }

        [Display(Name = "Ингредиенты")]
        public string Ingredients { get; set; }

        [Display(Name = "Инструкции")]
        public string Instructions { get; set; }
    }
}
