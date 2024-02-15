 namespace experiment_test.Data.Entityes
{
    public class Result
    {
        public int Id { get; set; }
        public int IdDevise { get; set; }
        public Devise? Devise { get; set; }
        public int IdExperiment { get; set; }
        public Experiment? Experiment { get; set; }
        public string? result { get; set; }
    }
}
