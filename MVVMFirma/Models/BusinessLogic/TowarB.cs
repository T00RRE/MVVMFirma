using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class TowarB : DatabaseClass
    {
        #region Konstruktor
        public TowarB(Faktury2024Entities db)
            :base(db)
        {}
        #endregion
        #region Funkcje biznesowe
        //dodamy funkcje która będzie zwracała id towarów oraz ich nazwy w KeyAndValue i Kod
        public IQueryable<KeyAndValue> GetTowaryKeyAndValueItems() 
        {
            return (
                    from towar in db.Towar
                    select new KeyAndValue
                    {
                        Key = towar.IdTowaru,
                        Value = towar.Nazwa + " " + towar.Kod
                    }
                    ).ToList().AsQueryable();
        }
        #endregion
    }
}
