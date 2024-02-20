 namespace experiment_test.Data.Entityes
{
    public class Result
    {
        public int Id { get; set; }
        public int DeviseId { get; set; }
        public Devise? Devise { get; set; }
        public int ExperimentId { get; set; }
        public Experiment? Experiment { get; set; }
        public string? result { get; set; }
    }
}
