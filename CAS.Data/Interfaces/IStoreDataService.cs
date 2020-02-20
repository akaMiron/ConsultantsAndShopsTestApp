using CAS.Data.ProjectionModels;
using System.Collections.Generic;

namespace CAS.Data.Interfaces
{
    public interface IStoreDataService
    {
        void CreateStore(tblStoreModel storeModel);
        tblStoreModel GetStore(int id);
        IEnumerable<tblStoreModel> GetStores();
        void UpdateStore(tblStoreModel storeModel);
        void DeleteStore(int id);
    }
}
