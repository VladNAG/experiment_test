using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace experiment_test.Data.Repository
{
    public class ExperimentOptionsRepository : IExperimentOptionsRepository
    {
        private readonly DataProviderDbContent _appDbContent;

        public ExperimentOptionsRepository(DataProviderDbContent _appDbContent)
        {
            this._appDbContent = _appDbContent;
        }
        public List<ExperimentOption> GetExpOptions(Experiment experiment)
        {
            return _appDbContent.ExperimentOption.Include(p=>p.ExperimentId == experiment.Id).ToList();
        }
    }
}
