using experiment_test.Data.Entityes;

namespace experiment_test.Interfeces
{
    public interface IExperimetRepository
    {
        public Experiment GetExperiment(string name_experiment);

    }
}
