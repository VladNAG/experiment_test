using experiment_test.Data.Entityes;
using experiment_test.Interfeces;

namespace experiment_test.Servises
{
    public class ExperimentServise : IServise
    {
        private readonly IResultRepository _resultRepository;
        private readonly IExperimetRepository _experimetRepository;
        private readonly IDeviseRepository _deviseRepository;
        private readonly IExperimentOptionsRepository _experimentOptionsRepository;
        public ExperimentServise(IExperimetRepository experimetRepository, IDeviseRepository deviseRepository, IResultRepository resultRepository, IExperimentOptionsRepository experimentOptionsRepository)
        {
            _experimetRepository = experimetRepository;
            _deviseRepository = deviseRepository;
            _resultRepository = resultRepository;
            _experimentOptionsRepository = experimentOptionsRepository;
        }

        public Devise GetDevise(string token)
        {
            return _deviseRepository.GetDevise(token);
        }
        public void AddNewDevise(Devise devise)
        {
            _deviseRepository.AddNewDevise(devise);
        }

        public Experiment GetExperiment(string name_experiment)
        {
            return _experimetRepository.GetExperiment(name_experiment);
        }

        public void DoExperiment(Experiment experiment, string token)
        {
            experiment.ExperimentOptions = _experimentOptionsRepository.GetExpOptions(experiment);
        }

        public void AddResult(Result result)
        {
            _resultRepository.AddResult(result);
        }
    }
}
