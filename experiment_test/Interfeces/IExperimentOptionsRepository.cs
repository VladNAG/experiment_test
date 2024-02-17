using experiment_test.Data.Entityes;

namespace experiment_test.Interfeces
{
    public interface IExperimentOptionsRepository
    {
        public List<ExperimentOption> GetExpOptions(Experiment experiment);
    }
}
