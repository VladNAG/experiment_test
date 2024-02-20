namespace experiment_test.StatisticEntityes
{
    public class StatisticHead
    {
        public int TotalDevisesExperimant { get; set; }
        public string? ExperementNeme { get; set; }
        public List<Statistic>? Statistics { get; set; } = new List<Statistic>();
    }
}
