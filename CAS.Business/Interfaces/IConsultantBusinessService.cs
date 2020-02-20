using CAS.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business.Interfaces
{
    public interface IConsultantBusinessService
    {
        void SaveConsultant(ConsultantModel consultantModel);
        ConsultantModel GetConsultant(int id);
        IEnumerable<ConsultantModel> GetConsultants();
        void DeleteConsultant(int id);
    }
}
