using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using experiment_test.ServiseEntityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace experiment_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperimentController : ControllerBase
    {
        private readonly IServise _service;

        public ExperimentController(IServise service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/[controller]/{name_experiment}")]
        public async Task<IActionResult> GetValueAsunc([FromRoute] string name_experiment, [FromQuery] string token)
        {
            var experiment = await _service.GetExperimentAsync(name_experiment);
            var devise = await _service.GetDeviseAsync(token);

            if (experiment is null)
            {
                return Ok($"Experiment {name_experiment} Doesn't Exist");
            }

            if (devise is null)
            {
                //запит від девайсу в перше, зберігаємо та проводимо експеремент
                var newdevise = new Devise { Token = token, FirstRequst = DateTime.Now };
                await _service.AddNewDeviseAsync(newdevise);
                await _service.DoExperimentAsyc(experiment, newdevise);
                var _result = await _service.GetResultAsync(newdevise);
                var experimentResultResponse = new ExperimentResultResponse { Key = _result.Experiment.Name, Value = _result.result };
                return Ok(experimentResultResponse);
            }

            if (devise.FirstRequst < experiment.StartExp)
            {
                //Умовно першою опціею експерименту завжди буде початкове значення до початку експерименту
                //якщо екперемент почався після першого запиту від девайсу повертаєм значення до початку експерименту
                var experimentResultResponse = new ExperimentResultResponse { Key = experiment.Name, Value = experiment.ExperimentOptions[0].Value };
                return Ok(experimentResultResponse);
            }
            else
            {
                // девайс одного разу отримав значення, то він завжди отримуватиме лише його (в рамках аксеременту, повторні запита не впливають на статистику)
                // якщо девайс приймае учать в 1 експеременті, то про інші єксперементи він не знає
                var _result = await _service.GetResultAsync(devise);
                if (name_experiment != _result.Experiment.Name)
                {
                    var _experimentResultResponse = new ExperimentResultResponse { Key = experiment.Name, Value = experiment.ExperimentOptions[0].Value };
                    return Ok(_experimentResultResponse);
                }
                var experimentResultResponse = new ExperimentResultResponse { Key = _result.Experiment.Name, Value = _result.result };
                return Ok(experimentResultResponse);
            }
        }

        [HttpGet]
        [Route("/[controller]/statistics")]
        public async Task<IActionResult> GetStatisticsAsunc()
        {
            var experiment_list = await _service.GetListExperimentAsync();
            if (experiment_list is null)
            { return Ok($"Experiments Doesn't Exist"); }
            var statisticResultResponse = await _service.GetAllStatisticAsync(experiment_list);
            return Ok(statisticResultResponse);
        }

    }
}