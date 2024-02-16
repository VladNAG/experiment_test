using experiment_test.Data.Entityes;
using experiment_test.Interfeces;

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
    }
}
