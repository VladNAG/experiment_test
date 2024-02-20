using experiment_test.Data.Entityes;
using System.Reflection.Metadata;

namespace experiment_test.Interfeces
{
    public interface IServise
    {
        public Task DoExperimentAsyc(Experiment experiment, Devise devise);
        public Task<Devise> GetDeviseAsync(string token);
        public Task AddNewDeviseAsync(Devise devise);
        public Task<Experiment> GetExperimentAsync(string name_experiment);
        public Task AddResultAsync(Result result);
        public Task<Result> GetResultAsync(Devise devise);

        public Task<List<Result>> GetListResultAsync(Experiment experiment);

    }
}
