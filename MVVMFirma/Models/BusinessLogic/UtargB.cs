using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class UtargB : DatabaseClass
    {
        #region Konstruktor
        public UtargB(Faktury2024Entities db)
            :base(db)
        { }
        
        
        
        #endregion
        #region Funkcje Biznesowe
        //ta funkcja oblicza utarg danego towaru w danych okresie od do 
        public decimal? UtargOkresTowar(int idTowaru, DateTime dataOd,DateTime dataDo)
        {
            return (
                from pozycja in db.PozycjaFaktury // dla kazdej pozycji dla bazy danych z pozycji 
                where
                pozycja.IdTowaru== idTowaru && pozycja.Faktura.DataWystawienia>= dataOd && pozycja.Faktura.DataWystawienia<= dataDo // sprawdzamy czy ta pozycja dotyczy tego towaru i czy data miesci sie w naszym zakresie
                select pozycja.Cena*pozycja.Ilość
                ).Sum();
        }
        #endregion
    }
}
