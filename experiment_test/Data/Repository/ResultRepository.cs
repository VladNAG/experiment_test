using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace experiment_test.Data.Repository

{
    public class ResultRepository : IResultRepository
    {
        private readonly DataProviderDbContent _appDbContent;

        public ResultRepository(DataProviderDbContent _appDbContent)
        {
            this._appDbContent = _appDbContent;
        }

        public void AddResult(Result result)
        {
            _appDbContent.Results.Add(result);
            _appDbContent.SaveChanges();
        }

        public async Task<Result> GetResultAsync(Devise devise)
        {
           return await _appDbContent.Results.FirstOrDefaultAsync(p => p.DeviseId == devise.Id);
        }
    }
}
