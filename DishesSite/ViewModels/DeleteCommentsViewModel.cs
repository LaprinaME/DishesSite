using System.ComponentModel.DataAnnotations;

namespace DishesSite.ViewModels
{
    public class DeleteCommentsViewModel
    {
        public int Комментарий_Id { get; set; }

        public int Рецепт_Id { get; set; }

        public string Автор { get; set; }

        public string Текст_комментария { get; set; }
    }
}
