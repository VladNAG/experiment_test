using experiment_test.Data.Entityes;
using experiment_test.Interfeces;

namespace experiment_test.Servises
{
    public class ExperimentServise : IServise
    {
        private readonly IResultRepository _resultRepository;
        private readonly IExperimetRepository _experimetRepository;
        private readonly IDeviseRepository _deviseRepository;
        public ExperimentServise(IExperimetRepository experimetRepository, IDeviseRepository deviseRepository, IResultRepository resultRepository)
        {
            _experimetRepository = experimetRepository;
            _deviseRepository = deviseRepository;
            _resultRepository = resultRepository;
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
            
        }

        public void AddResult(Result result)
        {
            _resultRepository.AddResult(result);
        }
    }
}
