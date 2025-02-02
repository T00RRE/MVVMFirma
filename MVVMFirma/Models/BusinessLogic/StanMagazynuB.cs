using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class StanMagazynuB : DatabaseClass
    {
        #region Konstruktor
        public StanMagazynuB(Faktury2024Entities db)
            : base(db)
        { }
        #endregion

        #region Funkcje biznesowe
        public decimal? StanMagazynuNaDzien(int idTowaru, DateTime dataDo)
        {
            return (
                from magazyn in db.Magazyn
                join stanMagazynowy in db.StanMagazynowy
                on magazyn.IdMagazynu equals stanMagazynowy.IdMagazynu
                where stanMagazynowy.IdTowaru == idTowaru
                join pozycjaFaktury in db.PozycjaFaktury
                on stanMagazynowy.IdTowaru equals pozycjaFaktury.IdTowaru into faktury
                from f in faktury.DefaultIfEmpty()
                where f == null || f.Faktura.DataWystawienia <= dataDo
                group f by stanMagazynowy into g
                select new
                {
                    StanPoczatkowy = g.Key.Ilosc,
                    Sprzedaz = g.Sum(x => x != null ? x.Ilość : 0)
                }
                ).Select(x => x.StanPoczatkowy - x.Sprzedaz)
                .FirstOrDefault();
        }
        #endregion
    }
}