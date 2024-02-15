using experiment_test.Data.Entityes;
using System.Reflection.Metadata;

namespace experiment_test.Interfeces
{
    public interface IServise
    {
        public Devise GetDevise(string token);
        public Experiment GetExperiment(string name_experiment);

    }
}
