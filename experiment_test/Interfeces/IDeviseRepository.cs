using experiment_test.Data.Entityes;

namespace experiment_test.Interfeces
{
    public interface IDeviseRepository
    {
        public Task<Devise> GetDeviseAsync(string token);

        public Task AddNewDeviseAsync(Devise devise);
    }
}
