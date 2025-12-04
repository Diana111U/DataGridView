namespace DataGridView.Manager.Contracts
{
    /// <summary>
    /// Класс для статистики абитуриентов
    /// </summary>
    public class ApplicantStatistics
    {
        /// <summary>
        /// Кол-во абитуриентов
        /// </summary>
        public int ApplicantCount { get; set; }

        /// <summary>
        /// Кол-во абитуриентов с баллами больше 150
        /// </summary>
        public int CountScoreMoreThan150 { get; set; }

        /// <summary>
        /// Кол-во абитуриентов, которые проходят по баллам
        /// </summary>
        public int CountPassing { get; set; }
    }
}