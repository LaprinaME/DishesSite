using System.ComponentModel.DataAnnotations;

namespace DishesSite.Models
{
    public class Rating
    {
        [Key]
        public int Рейтинг_Id { get; set; }

        public decimal Средний_рейтинг { get; set; }

        public int Количество_оценок { get; set; }
    }
}
