using experiment_test.Data.Entityes;
using System.Reflection.Metadata;

namespace experiment_test.Interfeces
{
    public interface IServise
    {
        public void DoExperiment(Experiment experiment, string token);
        public Devise GetDevise(string token);
        public void AddNewDevise(Devise devise);
        public Experiment GetExperiment(string name_experiment);
        public void AddResult(Result result);

    }
}
