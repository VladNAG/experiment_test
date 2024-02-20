using experiment_test.Data.Entityes;

namespace experiment_test.Interfeces
{
    public interface IExperimetRepository
    {
        public Task<Experiment> GetExperimentAsync(string name_experiment);
        public Task<List<Experiment>> GetListExperimentAsync();

    }
}
