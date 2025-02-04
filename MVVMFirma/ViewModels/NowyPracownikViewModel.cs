using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyPracownikViewModel : jedenViewModel<Pracownik>
    {
        #region Konstruktor
        public NowyPracownikViewModel() : base("Pracownik")
        {
            item = new Pracownik();
            item.DataZatrudnienia = DateTime.Now;
            
        }
        #endregion

        #region Properties
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }

        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }

        public string PESEL
        {
            get
            {
                return item.PESEL;
            }
            set
            {
                item.PESEL = value;
                OnPropertyChanged(() => PESEL);
            }
        }

        public DateTime? DataZatrudnienia
        {
            get
            {
                return item.DataZatrudnienia;
            }
            set
            {
                item.DataZatrudnienia = (DateTime)value;
                OnPropertyChanged(() => DataZatrudnienia);
            }
        }

        public string Stanowisko
        {
            get
            {
                return item.Stanowisko;
            }
            set
            {
                item.Stanowisko = value;
                OnPropertyChanged(() => Stanowisko);
            }
        }

        public decimal? Pensja
        {
            get
            {
                return item.Pensja;
            }
            set
            {
                item.Pensja = value;
                OnPropertyChanged(() => Pensja);
            }
        }

        public string NumerTelefonu
        {
            get
            {
                return item.NumerTelefonu;
            }
            set
            {
                item.NumerTelefonu = value;
                OnPropertyChanged(() => NumerTelefonu);
            }
        }

        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            FakturyEntities.Pracownik.Add(item);
            FakturyEntities.SaveChanges();
        }
        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(Imie):
                    return string.IsNullOrEmpty(Imie) ? "Imię jest wymagane" : string.Empty;

                case nameof(Nazwisko):
                    return string.IsNullOrEmpty(Nazwisko) ? "Nazwisko jest wymagane" : string.Empty;

                case nameof(PESEL):
                    return string.IsNullOrEmpty(PESEL) ? "PESEL jest wymagany" : string.Empty;

                case nameof(DataZatrudnienia):
                    return !DataZatrudnienia.HasValue ? "Data zatrudnienia jest wymagana" : string.Empty;

                case nameof(Stanowisko):
                    return string.IsNullOrEmpty(Stanowisko) ? "Stanowisko jest wymagane" : string.Empty;

                case nameof(Pensja):
                    return !Pensja.HasValue ? "Pensja jest wymagana" : string.Empty;

                case nameof(NumerTelefonu):
                    return string.IsNullOrEmpty(NumerTelefonu) ? "Numer telefonu jest wymagany" : string.Empty;

                case nameof(Email):
                    return string.IsNullOrEmpty(Email) ? "Email jest wymagany" : string.Empty;

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}