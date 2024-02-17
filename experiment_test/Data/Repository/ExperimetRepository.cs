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

        public Experiment GetExperiment(string name_experiment)
        {
            var experiment = _appDbContent.Experiments.FirstOrDefault(p => p.Name == name_experiment);
            var experimentExperimentOptions = _appDbContent.Experiments.Include(p=>p.ExperimentOptions).ToList();
            return experiment;
        }
    }
}
