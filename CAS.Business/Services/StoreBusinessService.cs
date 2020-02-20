using CAS.Business.Models;
using CAS.Business.Translators;
using CAS.Data.Interfaces;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business.Services
{

    public class StoreBusinessService : IStoreBusinessService
    {
        private IStoreDataService _storeDataService;

        public StoreBusinessService(IStoreDataService storeDataService)
        {
            _storeDataService = storeDataService;
        }

        public void DeleteStore(int id)
        {
            _storeDataService.DeleteStore(id);
        }

        public StoreModel GetStore(int id)
        {
            var record = _storeDataService.GetStore(id);
            var result = (record != null) ? StoreTranslator.FromDto(record) : null;

            return result;
        }

        public IEnumerable<StoreModel> GetStores()
        {
            var records = _storeDataService.GetStores();
            return records.Select(x => StoreTranslator.FromDto(x)).ToArray();
        }

        public void SaveStore(StoreModel storeModel)
        {
            var record = StoreTranslator.ToDto(storeModel);

            var item = GetStore(storeModel.Id);
            if (item != null)
            {
                _storeDataService.UpdateStore(record);
            }
            else
            {
                _storeDataService.CreateStore(record);
            }
        }
    }
}
