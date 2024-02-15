using experiment_test.Data.Entityes;
using experiment_test.Interfeces;

namespace experiment_test.Servises
{
    public class ExperimentServise : IServise
    {
        private readonly IExperimetRepository _experimetRepository;
        private readonly IDeviseRepository _deviseRepository;
        public ExperimentServise(IExperimetRepository experimetRepository, IDeviseRepository deviseRepository)
        {
            _experimetRepository = experimetRepository;
            _deviseRepository = deviseRepository;
        }

        public Devise GetDevise(string token)
        {
            return _deviseRepository.GetDevise(token);
        }

        public Experiment GetExperiment(string name_experiment)
        {
            return _experimetRepository.GetExperiment(name_experiment);
        }
    }
}
