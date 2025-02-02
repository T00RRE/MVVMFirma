using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    internal class RaportZamowienKlientaViewModel : WorkspaceViewModel
    {
        #region DB
        Faktury2024Entities db;
        #endregion

        #region Konstruktor
        public RaportZamowienKlientaViewModel()
        {
            base.DisplayName = "Raport Zamówień Klienta";
            db = new Faktury2024Entities();
            DataOd = DateTime.Now.AddMonths(-1); // domyślnie ostatni miesiąc
            DataDo = DateTime.Now;
            WartoscZamowien = 0;
        }
        #endregion

        #region Pola
        private DateTime _DataOd;
        public DateTime DataOd
        {
            get { return _DataOd; }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }

        private DateTime _DataDo;
        public DateTime DataDo
        {
            get { return _DataDo; }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }

        private int _IdKontrahenta;
        public int IdKontrahenta
        {
            get { return _IdKontrahenta; }
            set
            {
                if (_IdKontrahenta != value)
                {
                    _IdKontrahenta = value;
                    OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }

        private decimal? _WartoscZamowien;
        public decimal? WartoscZamowien
        {
            get { return _WartoscZamowien; }
            set
            {
                if (_WartoscZamowien != value)
                {
                    _WartoscZamowien = value;
                    OnPropertyChanged(() => WartoscZamowien);
                }
            }
        }

        public IQueryable<KeyAndValue> KontrahenciItems
        {
            get
            {
                return (
                    from kontrahent in db.Kontrahent
                    select new KeyAndValue
                    {
                        Key = kontrahent.IdKontrahenta,
                        Value = kontrahent.Nazwa + " " + kontrahent.NIP
                    }
                    ).ToList().AsQueryable();
            }
        }
        #endregion

        #region Komendy
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => obliczWartoscZamowienClick());
                return _ObliczCommand;
            }
        }

        private void obliczWartoscZamowienClick()
        {
            WartoscZamowien = new ZamowieniaKlientaB(db).WartoscZamowienKlienta(IdKontrahenta, DataOd, DataDo);
        }
        #endregion
    }
}