using System.ComponentModel.DataAnnotations;

namespace DishesSite.ViewModels
{
    public class AddDishViewModel
    {
        [Required(ErrorMessage = "Идентификатор блюда обязателен.")]
        [Display(Name = "Идентификатор блюда")]
        public int DishId { get; set; }

        [Required(ErrorMessage = "Название блюда обязательно.")]
        [StringLength(255, ErrorMessage = "Длина названия блюда не может превышать 255 символов.")]
        [Display(Name = "Название блюда")]
        public string DishName { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Информация")]
        public string Information { get; set; }
    }
}
