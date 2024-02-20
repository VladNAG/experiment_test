using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace experiment_test.Data.Repository
{
    public class ExperimetRepository : IExperimetRepository
    {
        private readonly DataProviderDbContent _appDbContent;

        public ExperimetRepository(DataProviderDbContent _appDbContent)
        {
            this._appDbContent = _appDbContent;
        }

        public async Task<Experiment> GetExperimentAsync(string name_experiment)
        {
            return await _appDbContent.Experiments.Include(p => p.ExperimentOptions).FirstOrDefaultAsync(p => p.Name == name_experiment);
        }

        public async Task<List<Experiment>> GetListExperimentAsync()
        {
           return await _appDbContent.Experiments.Include(p => p.ExperimentOptions).ToListAsync();
        }
    }
}
