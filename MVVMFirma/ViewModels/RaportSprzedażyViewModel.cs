using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    internal class RaportSprzedażyViewModel:WorkspaceViewModel
    {
        #region DB
        Faktury2024Entities db;
        #endregion
        #region Konstruktor
        public RaportSprzedażyViewModel()
        {
            base.DisplayName = "Raport Sprzedaży";
            db = new Faktury2024Entities();
            DataOd=DateTime.Now;
            DataDo=DateTime.Now;
            Utarg = 0;
        }
        #endregion
        #region Pola
        //dla każdego pola istotnego dla obliczeń tworzymy pole i właściwość
        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
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
            get
            {
                return _DataDo;
            }
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
            get
            {
                return _IdTowaru;
            }
            set
            {
                if (_IdTowaru != value)
                {
                    _IdTowaru = value;
                    OnPropertyChanged(() => IdTowaru);
                }
            }
        }

        private decimal? _Utarg;
        public decimal? Utarg
        {
            get
            {
                return _Utarg;
            }
            set
            {
                if (_Utarg != value)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => Utarg);
                }
            }
        }
        // to jest propertis który uzupełni wszystkie towary w comboxie
        public IQueryable<KeyAndValue> TowaryItems
        {
            get
            {
                return new TowarB(db).GetTowaryKeyAndValueItems();
                    
                    
                    
            }
        }

        #endregion
        #region Komendy
        //to jest komenda która zostanie podpięta pod przycisk Oblicz i która wywoła funkcje obliczUtargClick
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get 
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => obliczUtargClick());
                return _ObliczCommand;
            }
        }
        private void obliczUtargClick()
        {
            Utarg = new UtargB(db).UtargOkresTowar(IdTowaru,DataOd,DataDo); // to jest użycie funkcji z klasy logiki biznesowej UtargB która liczy utarg dla wybranego towaru w wybranym okresie 
        }
        #endregion
    }
}
