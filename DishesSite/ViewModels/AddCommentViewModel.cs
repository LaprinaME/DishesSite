using System.ComponentModel.DataAnnotations;

namespace DishesSite.ViewModels
{
    public class AddCommentViewModel
    {
        [Required(ErrorMessage = "Идентификатор комментария обязателен.")]
        [Display(Name = "Идентификатор комментария")]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Идентификатор рецепта обязателен.")]
        [Display(Name = "Идентификатор рецепта")]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Автор обязателен.")]
        [StringLength(255, ErrorMessage = "Длина имени автора не может превышать 255 символов.")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Текст комментария обязателен.")]
        [Display(Name = "Текст комментария")]
        public string CommentText { get; set; }
    }
}
