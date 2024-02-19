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

        public async Task<Devise> GetDeviseAsync(string token)
        {
            return await _deviseRepository.GetDeviseAsync(token);
        }
        public async Task AddNewDeviseAsync(Devise devise)
        {
           await _deviseRepository.AddNewDeviseAsync(devise);
        }

        public async Task<Experiment> GetExperimentAsync(string name_experiment)
        {
            return await _experimetRepository.GetExperimentAsync(name_experiment);
        }

        public async Task DoExperimentAsyc(Experiment experiment, Devise devise)
        {
            var random = new Random();
            int randomNum = random.Next(101);
            var value = "";
            decimal x = 0;

            for (int i = 0; i < experiment.ExperimentOptions.Count; i++)
            {
                x += experiment.ExperimentOptions[i].Percent;
                if (randomNum <= x)
                {
                    value = experiment.ExperimentOptions[i].Value;
                    break;
                }
                if (x > 100)
                {
                    throw new Exception();
                }
            }
            var result = new Result { DeviseId = devise.Id, ExperimentId = experiment.Id, result = value };
           await _resultRepository.AddResultAsync(result);

        }

        public async Task AddResultAsync(Result result)
        {
           await _resultRepository.AddResultAsync(result);
        }

        //YAGNI
        public List<ExperimentOption> GetExpOptions(Experiment experiment)
        {
            return _experimentOptionsRepository.GetExpOptions(experiment);
        }

        public async Task<Result> GetResultAsync(Devise devise)
        {
           return await _resultRepository.GetResultAsync(devise);
        }

        public async Task<List<Result>> GetListResultAsync(Experiment experiment)
        {
           return await _resultRepository.GetListResultAsync(experiment);
        }
    }
}
