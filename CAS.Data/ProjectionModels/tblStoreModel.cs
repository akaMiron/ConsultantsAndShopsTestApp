﻿using CAS.DataStorage;
using System.Collections.Generic;

namespace CAS.Data.ProjectionModels
{
    public class tblStoreModel
    {
        public int st_Id { get; set; }
        public string st_Name { get; set; }
        public string st_Address { get; set; }
        public ICollection<tblConsultant> st_Consultants { get; set; }

        public tblStore GetRecordData()
        {
            return new tblStore()
            {
                st_Id = st_Id,
                st_Name = st_Name,
                st_Address = st_Address,
                tblConsultant = st_Consultants
            };
        }
    }

}
