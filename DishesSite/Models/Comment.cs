using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishesSite.Models
{
    public class Comment
    {
        [Key]
        public int Комментарий_Id { get; set; }

        [ForeignKey("Recipe")]
        public int Рецепт_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Автор { get; set; }

        [Required]
        public string Текст_комментария { get; set; }

        public Recipe Recipe { get; set; }
    }
}
