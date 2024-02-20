using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace experiment_test.Data.Repository
{
    public class DeviseRepository : IDeviseRepository
    {
        private readonly DataProviderDbContent _appDbContent;

        public DeviseRepository(DataProviderDbContent _appDbContent)
        {
            this._appDbContent = _appDbContent;
        }

        public async Task AddNewDeviseAsync(Devise devise)
        {
           await _appDbContent.Devises.AddAsync(devise);
           await _appDbContent.SaveChangesAsync();
        }

        public async Task<Devise> GetDeviseAsync(string token)
        {

            return await _appDbContent.Devises.FirstOrDefaultAsync(p => p.Token == token);

        }
    }
}
