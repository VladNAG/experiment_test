using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

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
                return BadRequest();
            }

            if (devise is null)
            {
                //запит від девайсу в перше, зберігаємо та проводимо експеремент
                var newdevise = new Devise { Token = token, FirstRequst = DateTime.Now };
                await _service.AddNewDeviseAsync(newdevise);
                await _service.DoExperimentAsyc(experiment, newdevise);
                var _result = await _service.GetResultAsync(newdevise);
                return Ok($"key:{_result.Experiment.Name} value:{_result.result}");
            }

            if (devise.FirstRequst < experiment.StartExp)
            {
                //Умовно першою опціею експерименту завжди буде початкове значення до початку експерименту
                //якщо екперемент почався після першого запиту від девайсу повертаєм значення до початку експерименту
                return Ok($"key:{experiment.Name} value:{experiment.ExperimentOptions[0].Value}");
            }
            else
            {
                // девайс одного разу отримав значення, то він завжди отримуватиме лише його (в рамках аксеременту, повторні запита не впливають на статистику)
                // якщо девайс приймае учать в 1 експеременті, то про інші єксперементи він не знає
                var _result = await _service.GetResultAsync(devise);
                if (name_experiment != _result.Experiment.Name)
                {
                    return Ok($"key:{experiment.Name} value:{experiment.ExperimentOptions[0].Value}"); 
                }
                return Ok($"key:{_result.Experiment.Name} value:{_result.result}");
            }
        }

        [HttpGet]
        [Route("/[controller]/statistics/{name_experiment}")]
        public async Task<IActionResult> GetStatisticsAsunc([FromRoute] string name_experiment)
        {
            List<string> request = new(); 
            var experiment = await _service.GetExperimentAsync(name_experiment);
            if(experiment is null)
            { return BadRequest(); }
            var _result = await _service.GetListResultAsync(experiment);
            foreach (var result in _result)
            {
                var stat = new Statistic();
                stat.Name = result.Experiment.Name;
                stat.Name = result.result;
                var x = JsonSerializer.Serialize(stat);

                request.Add(x);
            }
            
            return Ok(request);
        }

    }
}