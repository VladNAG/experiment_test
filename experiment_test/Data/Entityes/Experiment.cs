namespace experiment_test.Data.Entityes
{
    public class Experiment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartExp { get; set; }
        public List<ExperimentOption> ExperimentOptions { get; set; } = new List<ExperimentOption>();

    }
}
