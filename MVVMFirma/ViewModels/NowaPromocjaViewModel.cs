using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class NowaPromocjaViewModel : jedenViewModel<Promocja>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Konstruktor
        public NowaPromocjaViewModel() : base("Promocja")
        {
            item = new Promocja();
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion

        #region Properties
        public string NazwaPromocji
        {
            get
            {
                return item.NazwaPromocji;
            }
            set
            {
                item.NazwaPromocji = value;
                OnPropertyChanged(() => NazwaPromocji);
            }
        }

        public DateTime DataRozpoczecia
        {
            get
            {
                return item.DataRozpoczecia;
            }
            set
            {
                item.DataRozpoczecia = value;
                OnPropertyChanged(() => DataRozpoczecia);
            }
        }

        public DateTime DataZakonczenia
        {
            get
            {
                return item.DataZakonczenia;
            }
            set
            {
                item.DataZakonczenia = value;
                OnPropertyChanged(() => DataZakonczenia);
            }
        }

        public decimal? WysokoscRabatu
        {
            get
            {
                return item.WysokoscRabatu;
            }
            set
            {
                item.WysokoscRabatu = value;
                OnPropertyChanged(() => WysokoscRabatu);
            }
        }

        public string OpisPromocji
        {
            get
            {
                return item.OpisPromocji;
            }
            set
            {
                item.OpisPromocji = value;
                OnPropertyChanged(() => OpisPromocji);
            }
        }

        public bool? CzyAktywna
        {
            get
            {
                return item.CzyAktywna;
            }
            set
            {
                item.CzyAktywna = value;
                OnPropertyChanged(() => CzyAktywna);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.Promocja.Add(item);
            fakturyEntities.SaveChanges();
        }

        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(NazwaPromocji):
                    return string.IsNullOrEmpty(NazwaPromocji) ? "Nazwa promocji jest wymagana" : string.Empty;

                case nameof(DataRozpoczecia):
                    return DateTime.MinValue == DataRozpoczecia ? "Data rozpoczęcia jest wymagana" : string.Empty;

                case nameof(DataZakonczenia):
                    if (DateTime.MinValue == DataZakonczenia)
                        return "Data zakończenia jest wymagana";
                    if (DataZakonczenia < DataRozpoczecia)
                        return "Data zakończenia nie może być wcześniejsza niż data rozpoczęcia";
                    return string.Empty;

                case nameof(WysokoscRabatu):
                    if (!WysokoscRabatu.HasValue)
                        return "Wysokość rabatu jest wymagana";
                    if (WysokoscRabatu < 0 || WysokoscRabatu > 100)
                        return "Wysokość rabatu musi być wartością między 0 a 100";
                    return string.Empty;

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}