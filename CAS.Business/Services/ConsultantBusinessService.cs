using CAS.Business.Interfaces;
using CAS.Business.Models;
using CAS.Business.Translators;
using CAS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Business.Services
{
    public class ConsultantBusinessService : IConsultantBusinessService
    {
        private IConsultantDataService _consultantDataService;

        public ConsultantBusinessService(IConsultantDataService consultantDataService)
        {
            _consultantDataService = consultantDataService;
        }

        public void DeleteConsultant(int id)
        {
            _consultantDataService.DeleteConsultant(id);
        }

        public ConsultantModel GetConsultant(int id)
        {
            var record = _consultantDataService.GetConsultant(id);
            var result = (record != null) ? ConsultantTranslator.FromDto(record) : null;

            return result;
        }

        public IEnumerable<ConsultantModel> GetConsultants()
        {
            var records = _consultantDataService.GetConsultants();
            return records.Select(x => ConsultantTranslator.FromDto(x)).ToArray();
        }

        public void SaveConsultant(ConsultantModel consultantModel)
        {
            var record = ConsultantTranslator.ToDto(consultantModel);

            var item = GetConsultant(consultantModel.Id);
            if (item != null)
            {
                _consultantDataService.UpdateConsultant(record);
            }
            else
            {
                _consultantDataService.CreateConsultant(record);
            }
        }

    }
}
