using CAS.Data.ProjectionModels;
using CAS.DataStorage;
using System.Collections.Generic;
using System.Linq;

namespace CAS.Data.Services
{
    public class ConsultantDataService : IConsultantDataService
    {
        public void CreateConsultant(tblConsultantModel consultantModel)
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var consultant = consultantModel.GetRecordData();

                db.tblConsultant.Add(consultant);

                db.SaveChanges();
            }
        }

        public void DeleteConsultant(int id)
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var consultant = GetConsultant(id);
                var record = consultant.GetRecordData();

                db.tblConsultant.Attach(record);
                db.Entry(record).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public tblConsultantModel GetConsultant(int id)
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var result = (from consultant in db.tblConsultant
                              select new tblConsultantModel
                              {
                                  cons_Id = consultant.cons_Id,
                                  cons_Name = consultant.cons_Name,
                                  cons_LastName = consultant.cons_LastName,
                                  cons_StoreId = consultant.cons_StoreId,
                                  cons_AssignmentDate = consultant.cons_AssignmentDate
                              }).Where(cons => cons.cons_Id == id).AsQueryable();

                return result.FirstOrDefault();
            }
        }

        public IEnumerable<tblConsultantModel> GetConsultants()
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var result = (from consultant in db.tblConsultant
                              select new tblConsultantModel
                              {
                                  cons_Id = consultant.cons_Id,
                                  cons_Name = consultant.cons_Name,
                                  cons_LastName = consultant.cons_LastName,
                                  cons_StoreId = consultant.cons_StoreId,
                                  cons_AssignmentDate = consultant.cons_AssignmentDate,
                              }).AsQueryable();

                return result.ToArray();
            }
        }

        public void UpdateConsultant(tblConsultantModel consultantModel)
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var consultant = consultantModel.GetRecordData();

                db.tblConsultant.Add(consultant);
                db.Entry(consultant).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
