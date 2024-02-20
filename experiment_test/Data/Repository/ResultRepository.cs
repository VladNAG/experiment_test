using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace experiment_test.Data.Repository

{
    public class ResultRepository : IResultRepository
    {
        private readonly DataProviderDbContent _appDbContent;

        public ResultRepository(DataProviderDbContent _appDbContent)
        {
            this._appDbContent = _appDbContent;
        }

        public async Task AddResultAsync(Result result)
        {
           await _appDbContent.Results.AddAsync(result);
           await _appDbContent.SaveChangesAsync();
        }

        public async Task<Result> GetResultAsync(Devise devise)
        {
           return await _appDbContent.Results.FirstOrDefaultAsync(p => p.DeviseId == devise.Id);
        }

        public async Task<List<Result>> GetListResultAsync(Experiment experiment)
        {
            return await _appDbContent.Results.Include(c => c.Devise).Where(p => p.ExperimentId == experiment.Id).ToListAsync();
        }

    }
}
