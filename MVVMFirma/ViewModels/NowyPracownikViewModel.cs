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
            DataZatrudnienia = DateTime.Now; // ustawiamy domyślną datę zatrudnienia
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
                item.DataZatrudnienia = value;
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
            fakturyEntities.Pracownik.Add(item);
            fakturyEntities.SaveChanges();
        }
        #endregion
    }
}