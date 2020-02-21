using CAS.Business.Models;
using CAS.Data.ProjectionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business.Translators
{
    public class StoreTranslator
    {
        public static StoreModel FromDto(tblStoreModel dto)
        {
            return new StoreModel
            {
                Id = dto.st_Id,
                Name = dto.st_Name,
                Address = dto.st_Address
            };
        }

        public static tblStoreModel ToDto(StoreModel storeModel)
        {
            return new tblStoreModel
            {
                st_Id = storeModel.Id,
                st_Name = storeModel.Name,
                st_Address = storeModel.Address
            };
        }
    }
}
