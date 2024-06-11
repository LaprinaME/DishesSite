using System.ComponentModel.DataAnnotations;

namespace DishesSite.ViewModels
{
    public class DeleteRecipesViewModel
    {
        public int Рецепт_Id { get; set; }

        public string Название_рецепта { get; set; }

        public string Описание { get; set; }

        public string Ингредиенты { get; set; }

        public string Инструкции { get; set; }
    }
}

