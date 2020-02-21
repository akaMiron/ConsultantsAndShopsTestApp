using CAS.Data.Interfaces;
using CAS.Data.ProjectionModels;
using CAS.DataStorage;
using System.Collections.Generic;
using System.Linq;

namespace CAS.Data.Services
{
    public class StoreDataService : IStoreDataService
    {
        public void CreateStore(tblStoreModel storeModel)
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var store = storeModel.GetRecordData();

                db.tblStore.Add(store);

                db.SaveChanges();
            }
        }

        public void DeleteStore(int id)
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var store = GetStore(id);
                var record = store.GetRecordData();

                db.tblStore.Attach(record);
                db.Entry(record).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public tblStoreModel GetStore(int id)
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var result = (from store in db.tblStore
                              select new tblStoreModel
                              {
                                  st_Id = store.st_Id,
                                  st_Name = store.st_Name,
                                  st_Address = store.st_Address
                              }).AsQueryable();

                return result.Where(x => x.st_Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<tblStoreModel> GetStores()
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var result = (from store in db.tblStore
                              select new tblStoreModel
                              {
                                  st_Id = store.st_Id,
                                  st_Name = store.st_Name,
                                  st_Address = store.st_Address
                              }).AsQueryable();

                return result.ToArray();
            }
        }

        public void UpdateStore(tblStoreModel storeModel)
        {
            using (var db = new ConsultantsAndStoresDBEntities())
            {
                var store = storeModel.GetRecordData();

                db.tblStore.Add(store);
                db.Entry(store).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
