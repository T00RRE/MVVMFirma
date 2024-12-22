using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;
using Microsoft.Win32;

namespace MVVMFirma.ViewModels
{
    public class WszyscyPracownicyViewModel : WszystkieViewModel<Pracownik>
    {
        #region Fields
        private readonly Faktury2024Entities fakturyEntities;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public WszyscyPracownicyViewModel()
            : base("Pracownicy")
        {
            fakturyEntities = new Faktury2024Entities();
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Pracownik>(fakturyEntities.Pracownik.ToList());
        }
        public override void ShowAddWindow()
        {
            var nowyPracownik = new NowyRodzajViewModel();
            EventAggregator.PublishWorkspaceViewModel(nowyPracownik);
        }
        #endregion
    }
}