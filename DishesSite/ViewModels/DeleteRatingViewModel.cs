namespace DishesSite.ViewModels
{
    public class DeleteRatingViewModel
    {
        public int Рейтинг_Id { get; set; }
        public decimal Средний_рейтинг { get; set; }
        public int Количество_оценок { get; set; }
        public int Рецепт_Id { get; set; }
    }
}
