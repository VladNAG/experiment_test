using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using Microsoft.AspNetCore.Mvc;
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
            var experiment = _service.GetExperiment(name_experiment);
            var devise = _service.GetDevise(token);
            if (experiment is null)
            {
                return BadRequest(experiment);
            }
            if (devise is null)
            {
                var newdevise = new Devise { Token = token, FirstRequst = DateTime.Now };
                _service.AddNewDevise(newdevise);
                _service.DoExperiment(experiment, newdevise);
                var _result = await _service.GetResultAsync(newdevise);
                return Ok($"key:{_result.Experiment.Name} value:{_result.result}");
            }
            if (devise.FirstRequst > experiment.StartExp)
            {
                //return "для него нет експееремента возвращаем полследнее значенее";или бед реквст
            }
            else
            {
                //проводим експеремент 
                //return $"key:{Result.exp} value:{Result.result}"
            }
            return BadRequest(experiment);
        }

        /*[HttpGet]
        [Route("/[controller]/[statistics]")]
        public IActionResult GetStatistics()
        {

            return BadRequest();
        }*/

    }
}