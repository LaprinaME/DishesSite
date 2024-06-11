using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishesSite.Models
{
    public class Rating
    {
        [Key]
        public int Рейтинг_Id { get; set; }

        public decimal Средний_рейтинг { get; set; }

        public int Количество_оценок { get; set; }

        // Внешний ключ на таблицу Рецепты
        [ForeignKey("Recipe")]
        public int Рецепт_Id { get; set; }
        public Recipe Recipe { get; set; }
    }
}
