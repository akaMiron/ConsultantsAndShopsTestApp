using CAS.Data.ProjectionModels;
using System.Collections.Generic;

namespace CAS.Data
{
    public interface IConsultantDataService
    {
        void CreateConsultant(tblConsultantModel consultantModel);
        tblConsultantModel GetConsultant(int id);
        IEnumerable<tblConsultantModel> GetConsultants();
        void UpdateConsultant(tblConsultantModel consultantModel);
        void DeleteConsultant(int id);
    }
}
