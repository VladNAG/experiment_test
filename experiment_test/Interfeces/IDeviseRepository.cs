using experiment_test.Data.Entityes;

namespace experiment_test.Interfeces
{
    public interface IDeviseRepository
    {
        public Devise GetDevise(string token);
    }
}
