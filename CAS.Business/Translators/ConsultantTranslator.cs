using CAS.Business.Models;
using CAS.Data.ProjectionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business.Translators
{
    public class ConsultantTranslator
    {
        public static ConsultantModel FromDto(tblConsultantModel dto)
        {
            return new ConsultantModel
            {
                Id = dto.cons_Id,
                Name = dto.cons_Name,
                LastName = dto.cons_LastName,
                AssignmentDate = dto.cons_AssignmentDate,
                StoreId = dto.cons_StoreId,
                Store = dto.cons_Store
            };
        }

        public static tblConsultantModel ToDto(ConsultantModel storeModel)
        {
            return new tblConsultantModel
            {
                cons_Id = storeModel.Id,
                cons_Name = storeModel.Name,
                cons_LastName = storeModel.LastName,
                cons_AssignmentDate = storeModel.AssignmentDate,
                cons_StoreId = storeModel.StoreId,
                cons_Store = storeModel.Store
            };
        }
    }
}
