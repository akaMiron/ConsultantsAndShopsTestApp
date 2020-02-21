using CAS.DataStorage;
using System;

namespace CAS.Data.ProjectionModels
{
    public class tblConsultantModel
    {
        public int cons_Id { get; set; }
        public string cons_Name { get; set; }
        public string cons_LastName { get; set; }
        public int? cons_StoreId { get; set; }
        public DateTime? cons_AssignmentDate { get; set; }

        public tblConsultant GetRecordData()
        {
            return new tblConsultant
            {
                cons_Id = cons_Id,
                cons_Name = cons_Name,
                cons_LastName = cons_LastName,
                cons_StoreId = cons_StoreId,
                cons_AssignmentDate = cons_AssignmentDate != DateTime.MinValue ? cons_AssignmentDate : null
            };
        }
    }
}
