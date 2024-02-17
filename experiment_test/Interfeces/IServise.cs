using experiment_test.Data.Entityes;
using System.Reflection.Metadata;

namespace experiment_test.Interfeces
{
    public interface IServise
    {
        public void DoExperiment(Experiment experiment, Devise devise);
        public Devise GetDevise(string token);
        public void AddNewDevise(Devise devise);
        public Experiment GetExperiment(string name_experiment);
        public void AddResult(Result result);

        public List<ExperimentOption> GetExpOptions(Experiment experiment);

    }
}
