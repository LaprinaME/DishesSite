using System.ComponentModel.DataAnnotations;

namespace DishesSite.Models
{
    public class Dish
    {
        [Key]
        public int Блюдо_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Название_блюда { get; set; }

        public string Описание { get; set; }

        public string Информация { get; set; }
    }
}
