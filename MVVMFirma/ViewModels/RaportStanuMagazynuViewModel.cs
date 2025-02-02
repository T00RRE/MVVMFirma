using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    internal class RaportStanuMagazynuViewModel : WorkspaceViewModel
    {
        #region DB
        Faktury2024Entities db;
        #endregion

        #region Konstruktor
        public RaportStanuMagazynuViewModel()
        {
            base.DisplayName = "Raport Stanu Magazynu";
            db = new Faktury2024Entities();
            DataDo = DateTime.Now;
            StanMagazynu = 0;
        }
        #endregion

        #region Pola
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

        private int _IdTowaru;
        public int IdTowaru
        {
            get { return _IdTowaru; }
            set
            {
                if (_IdTowaru != value)
                {
                    _IdTowaru = value;
                    OnPropertyChanged(() => IdTowaru);
                }
            }
        }

        private decimal? _StanMagazynu;
        public decimal? StanMagazynu
        {
            get { return _StanMagazynu; }
            set
            {
                if (_StanMagazynu != value)
                {
                    _StanMagazynu = value;
                    OnPropertyChanged(() => StanMagazynu);
                }
            }
        }

        public IQueryable<KeyAndValue> TowaryItems
        {
            get
            {
                return new TowarB(db).GetTowaryKeyAndValueItems();
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
                    _ObliczCommand = new BaseCommand(() => obliczStanMagazynuClick());
                return _ObliczCommand;
            }
        }

        private void obliczStanMagazynuClick()
        {
            StanMagazynu = new StanMagazynuB(db).StanMagazynuNaDzien(IdTowaru, DataDo);
        }
        #endregion
    }
}