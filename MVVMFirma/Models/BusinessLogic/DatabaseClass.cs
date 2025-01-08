using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class DatabaseClass
    {
        #region Context
        public Faktury2024Entities db { get; set; }
        #endregion
        #region Konstruktor
        public DatabaseClass(Faktury2024Entities db) 
        {
        this.db = db;
        }

        #endregion
    }
}
