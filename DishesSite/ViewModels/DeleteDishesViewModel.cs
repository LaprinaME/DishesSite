using System.ComponentModel.DataAnnotations;

namespace DishesSite.ViewModels
{
    public class DeleteDishesViewModel
    {
        public int Блюдо_Id { get; set; }

        public string Название_блюда { get; set; }

        public string Описание { get; set; }

        public string Информация { get; set; }
    }
}
