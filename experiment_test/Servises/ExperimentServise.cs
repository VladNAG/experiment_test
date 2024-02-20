using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using experiment_test.StatisticEntityes;
using System.Drawing;

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
        public async Task<List<Experiment>> GetListExperimentAsync()
        {
            return await _experimetRepository.GetListExperimentAsync();
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

        public async Task<Result> GetResultAsync(Devise devise)
        {
            return await _resultRepository.GetResultAsync(devise);
        }

        public async Task<List<Result>> GetListResultAsync(Experiment experiment)
        {
            return await _resultRepository.GetListResultAsync(experiment);
        }

        public async Task<List<object>> GetAllStatisticAsync(List<Experiment> experiment_list)
        {

            List<object> statisticHeadList = new();
            foreach (var experiment in experiment_list)
            {
                var _result = await _resultRepository.GetListResultAsync(experiment);
                var statisticHead = new StatisticHead();
                statisticHead.TotalDevisesExperimant = _result.Count;
                statisticHead.ExperementNeme = experiment.Name;

                try  //якщо результатів немає, перехопимо вичлючення
                {
                    for (int i = 0; i < _result[0].Experiment.ExperimentOptions.Count; i++)
                    {
                        var statistic = new Statistic();
                        statistic.NameOption = _result[0].Experiment.ExperimentOptions[i].Percent.ToString();
                        statistic.ValueOptions = _result[0].Experiment.ExperimentOptions[i].Value;
                        statistic.TotalDevisesOptions = _result.Count(x => x.result == _result[0].Experiment.ExperimentOptions[i].Value);
                        statisticHead.Statistics.Add(statistic);
                    }
                    statisticHeadList.Add(statisticHead);
                }
                catch (ArgumentOutOfRangeException)
                { statisticHeadList.Add($"ExperementNeme:{experiment.Name} - NO RESULT"); }
            }
            return statisticHeadList;
        }
        
    }
}
