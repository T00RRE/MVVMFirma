using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NoweZamowienieHurtoweViewModel : jedenViewModel<ZamowienieHurtowe>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        private ObservableCollection<KontrahentForComboBox> _kontrahenciList;
        #endregion

        #region Constructor
        public NoweZamowienieHurtoweViewModel() : base("ZamowienieHurtowe")
        {
            item = new ZamowienieHurtowe();
            fakturyEntities = new Faktury2024Entities();
            item.DataZamowienia = DateTime.Now;

            KontrahenciList = new ObservableCollection<KontrahentForComboBox>(
                fakturyEntities.Kontrahent.Select(kontrahent => new KontrahentForComboBox
                {
                    IdKontrahenta = kontrahent.IdKontrahenta,
                    NazwaKontrahenta = kontrahent.Nazwa + " (NIP: " + kontrahent.NIP + ")"
                }).ToList()
            );

            Messenger.Default.Register<Kontrahent>(this, getWybranyKontrahent);
        }
        #endregion

        #region Properties
        public DateTime DataZamowienia
        {
            get
            {
                return item.DataZamowienia;
            }
            set
            {
                item.DataZamowienia = value;
                OnPropertyChanged(() => DataZamowienia);
            }
        }

        public DateTime? TerminRealizacji
        {
            get
            {
                return item.TerminRealizacji;
            }
            set
            {
                item.TerminRealizacji = value;
                OnPropertyChanged(() => TerminRealizacji);
            }
        }

        public string Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                item.Status = value;
                OnPropertyChanged(() => Status);
            }
        }

        public decimal? WartoscZamowienia
        {
            get
            {
                return item.WartoscZamowienia;
            }
            set
            {
                item.WartoscZamowienia = value;
                OnPropertyChanged(() => WartoscZamowienia);
            }
        }

        public int? IdKontrahenta
        {
            get
            {
                return item.IdKontrahenta;
            }
            set
            {
                item.IdKontrahenta = value;
                OnPropertyChanged(() => IdKontrahenta);
            }
        }

        public ObservableCollection<KontrahentForComboBox> KontrahenciList
        {
            get { return _kontrahenciList; }
            set
            {
                _kontrahenciList = value;
                OnPropertyChanged(() => KontrahenciList);
            }
        }

        private BaseCommand _ShowKontrahenci;
        public ICommand ShowKontrahenci
        {
            get
            {
                if (_ShowKontrahenci == null)
                    _ShowKontrahenci = new BaseCommand(() => showKontrahenci());
                return _ShowKontrahenci;
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            fakturyEntities.ZamowienieHurtowe.Add(item);
            fakturyEntities.SaveChanges();
        }

        public class KontrahentForComboBox
        {
            public int IdKontrahenta { get; set; }
            public string NazwaKontrahenta { get; set; }
        }

        private void getWybranyKontrahent(Kontrahent kontrahent)
        {
            IdKontrahenta = kontrahent.IdKontrahenta;
        }

        protected override string ValidateProperty(string propertyname)
        {
            switch (propertyname)
            {
                case nameof(DataZamowienia):
                    return DataZamowienia == DateTime.MinValue ? "Data zamówienia jest wymagana" : string.Empty;

                case nameof(TerminRealizacji):
                    if (TerminRealizacji == DateTime.MinValue)
                        return "Termin realizacji jest wymagany";
                    if (TerminRealizacji < DataZamowienia)
                        return "Termin realizacji nie może być wcześniejszy niż data zamówienia";
                    return string.Empty;

                case nameof(WartoscZamowienia):
                    if (WartoscZamowienia <= 0)
                        return "Wartość zamówienia musi być większa od 0";
                    return string.Empty;

                case nameof(IdKontrahenta):
                    return !IdKontrahenta.HasValue ? "Kontrahent jest wymagany" : string.Empty;

                default:
                    return string.Empty;
            }
        }

        private void showKontrahenci()
        {
            Messenger.Default.Send("KontrahenciAll");
        }
        #endregion
    }
}