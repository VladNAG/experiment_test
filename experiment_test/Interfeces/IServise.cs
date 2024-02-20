using experiment_test.Data.Entityes;
using System.Reflection.Metadata;
using experiment_test.StatisticEntityes;

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
        public Task<List<Experiment>> GetListExperimentAsync();
        public Task<List<object>> GetAllStatisticAsync(List<Experiment> experiment_list);
    }
}
