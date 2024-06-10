using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishesSite.Models
{
    public class Recipe
    {
        [Key]
        public int Рецепт_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Название_рецепта { get; set; }

        public string Описание { get; set; }

        public string Ингредиенты { get; set; }

        public string Инструкции { get; set; }

        public ICollection<Comment> Комментарии { get; set; }
    }
}
