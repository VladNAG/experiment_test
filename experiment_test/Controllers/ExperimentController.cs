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
        private readonly IServise _serviceProvider;



        public ExperimentController(IServise serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        [Route("/[controller]/{name_experiment}")]
        public IActionResult GetValue([FromRoute] string name_experiment, [FromQuery] string token)
        {
            Experiment experiment = _serviceProvider.GetExperiment(name_experiment);
            Devise devise = _serviceProvider.GetDevise(token);
            if (experiment is null)
            {
                return BadRequest(experiment);
            }
            if (devise is null)
            {
                Devise newdevise = new Devise { Token = token, FirstRequst = DateTime.Now };
                _serviceProvider.AddNewDevise(newdevise);
                _serviceProvider.DoExperiment(experiment, token);
                //return $"key:{Result.exp} value:{Result.result}"
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
    }
}