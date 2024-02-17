using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using System.Drawing;

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

        public void DoExperiment(Experiment experiment, Devise devise)
        {
            var random = new Random();
            int randomNum = random.Next(100);
            var value = "";
            if (randomNum < experiment.ExperimentOptions[0].Percent )
            {
                value = experiment.ExperimentOptions[0].Value;
            }
            if (randomNum < experiment.ExperimentOptions[0].Percent + experiment.ExperimentOptions[1].Percent)
            {
                value = experiment.ExperimentOptions[1].Value;
            }
            if (randomNum < experiment.ExperimentOptions[0].Percent + experiment.ExperimentOptions[1].Percent + experiment.ExperimentOptions[2].Percent)
            {
                value = experiment.ExperimentOptions[2].Value;
            }
            if (randomNum < experiment.ExperimentOptions[0].Percent + experiment.ExperimentOptions[1].Percent + experiment.ExperimentOptions[2].Percent + experiment.ExperimentOptions[3].Percent)
            {
                value = experiment.ExperimentOptions[3].Value;
            }
            var result = new Result { DeviseId = devise.Id, ExperimentId = experiment.Id, result = value };
            _resultRepository.AddResult(result);

        }

        public void AddResult(Result result)
        {
            _resultRepository.AddResult(result);
        }

        public List<ExperimentOption> GetExpOptions(Experiment experiment)
        {
           return _experimentOptionsRepository.GetExpOptions(experiment);
        }
    }
}
