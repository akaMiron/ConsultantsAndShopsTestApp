using CAS.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business
{
    public interface IStoreBusinessService
    {
        void SaveStore(StoreModel storeModel);
        StoreModel GetStore(int id);
        IEnumerable<StoreModel> GetStores();
        void DeleteStore(int id);
    }
}
