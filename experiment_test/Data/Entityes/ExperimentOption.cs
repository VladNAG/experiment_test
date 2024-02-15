namespace experiment_test.Data.Entityes
{
    public class ExperimentOption
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public decimal Percent { get; set; }
        public int IdExperiment { get; set; }
        public Experiment? Experiment { get; set; }
    }
}
