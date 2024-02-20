using experiment_test.Data.Entityes;

namespace experiment_test.Interfeces
{
    public interface IResultRepository
    {
        public Task AddResultAsync(Result result);
        public Task<Result> GetResultAsync(Devise devise);
        public Task<List<Result>> GetListResultAsync(Experiment experiment);
    }
}
