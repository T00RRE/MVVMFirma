using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Linq;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class ZamowieniaKlientaB : DatabaseClass
    {
        #region Konstruktor
        public ZamowieniaKlientaB(Faktury2024Entities db)
            : base(db)
        { }
        #endregion

        #region Funkcje biznesowe
        public decimal? WartoscZamowienKlienta(int idKontrahenta, DateTime dataOd, DateTime dataDo)
        {
            return (
                from faktura in db.Faktura
                where faktura.IdKontrahenta == idKontrahenta
                && faktura.DataWystawienia >= dataOd
                && faktura.DataWystawienia <= dataDo
                join pozycja in db.PozycjaFaktury
                on faktura.IdFaktury equals pozycja.IdFaktury
                select pozycja.Ilość * pozycja.Cena
                ).Sum();
        }
        #endregion
    }
}