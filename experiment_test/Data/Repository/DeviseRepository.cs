using experiment_test.Data.Entityes;
using experiment_test.Interfeces;

namespace experiment_test.Data.Repository
{
    public class DeviseRepository : IDeviseRepository
    {
        private readonly DataProviderDbContent _appDbContent;

        public DeviseRepository(DataProviderDbContent _appDbContent)
        {
            this._appDbContent = _appDbContent;
        }
        public Devise GetDevise(string token)
        {

            return _appDbContent.Devises.FirstOrDefault(p => p.Token == token);

        }
    }
}
