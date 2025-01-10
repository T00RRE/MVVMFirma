using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Views;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion
        #region Constructor
        public MainWindowViewModel()
        {
            //EventAggregator.WorkspaceViewModelRequested += OnWorkspaceViewModelRequested;
        }
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            //To jest Messenger który oczekuje na stringa i jak go złapie to wywołuje metode open która jest zdefiniowana w regionie prywatnych helpersów
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Towary",
                    new BaseCommand(() => this.ShowAllTowar())),

                new CommandViewModel(
                    "Towar",
                    new BaseCommand(() => this.CreateView(new NowyTowarViewModel()))),
                new CommandViewModel(
                    "Faktury",
                    new BaseCommand(() => this.ShowAllFaktury())),
                new CommandViewModel(
                    "Faktura",
                    new BaseCommand(() => this.CreateView(new NowaFakturaViewModel()))),
                 new CommandViewModel(
                "Pracownicy",
                new BaseCommand(() => this.ShowAllPracownicy())),
            new CommandViewModel(
                "Pracownik",
            new BaseCommand(() => this.CreateView(new NowyPracownikViewModel()))),
             new CommandViewModel(
                    "Statusy",
                    new BaseCommand(() => this.ShowAllStatusy())),
             new CommandViewModel(
                "NowyStatus",
            new BaseCommand(() => this.CreateView(new NowyStatusViewModel()))),
             new CommandViewModel(
            "Sposoby Płatności",
            new BaseCommand(() => this.ShowAllSposobyPlatnosci())),
        new CommandViewModel(
            "Sposób Płatności",
            new BaseCommand(() => this.CreateView(new NowySposobPlatnosciViewModel()))),
           new CommandViewModel(
            "Reklamacje",
            new BaseCommand(() => this.ShowAllReklamacje())),
        new CommandViewModel(
            "Reklamacja",
            new BaseCommand(() => this.CreateView(new NowaReklamacjaViewModel()))),
        new CommandViewModel(
            "Kontrahenci",
            new BaseCommand(() => this.ShowAllKontrahenci())),
        new CommandViewModel(
            "Kontrahent",
            new BaseCommand(() => this.CreateView(new NowyKontrahentViewModel()))),
        new CommandViewModel(
            "Rodzaje",
            new BaseCommand(() => this.ShowAllRodzaje())),
        new CommandViewModel(
            "Rodzaj",
            new BaseCommand(() => this.CreateView(new NowyRodzajViewModel()))),
        new CommandViewModel(
            "Adresy",
            new BaseCommand(() => this.ShowAllAdresy())),
        new CommandViewModel(
            "Adres",
            new BaseCommand(() => this.CreateView(new NowyAdresViewModel()))),
         new CommandViewModel(
            "Magazyny",
            new BaseCommand(() => this.ShowAllMagazyny())),
        new CommandViewModel(
            "Magazyn",
            new BaseCommand(() => this.CreateView(new NowyMagazynViewModel()))),

        new CommandViewModel(
            "Stany Magazynowe",
            new BaseCommand(() => this.ShowAllStanyMagazynowe())),
        new CommandViewModel(
            "Stan Magazynowy",
            new BaseCommand(() => this.CreateView(new NowyStanMagazynowyViewModel()))),
        new CommandViewModel(
            "Raporty Sprzedaży",
            new BaseCommand(() => this.CreateView(new RaportSprzedażyViewModel())))
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateView(WorkspaceViewModel nowy)
        {  
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }
        
        private void ShowAllTowar()
        {
            WszystkieTowaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
                as WszystkieTowaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFaktury()
        {
            WszystkieFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel)
                as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        public void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void ShowAllPracownicy()
        {
            WszyscyPracownicyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
                as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStatusy()
        {
            WszystkieStatusyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyViewModel)
                as WszystkieStatusyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatusyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllSposobyPlatnosci()
        {
            WszystkieSposobyPlatnosciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieSposobyPlatnosciViewModel)
                as WszystkieSposobyPlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSposobyPlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllReklamacje()
        {
            WszystkieReklamacjeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieReklamacjeViewModel)
                as WszystkieReklamacjeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieReklamacjeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllKontrahenci()
        {
            WszyscyKontrahenciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyKontrahenciViewModel)
                as WszyscyKontrahenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRodzaje()
        {
            WszystkieRodzajeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeViewModel)
                as WszystkieRodzajeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllAdresy()
        {
            WszystkieAdresyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel)
                as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllMagazyny()
        {
            WszystkieMagazynyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieMagazynyViewModel)
                as WszystkieMagazynyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieMagazynyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStanyMagazynowe()
        {
            WszystkieStanyMagazynoweViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieStanyMagazynoweViewModel)
                as WszystkieStanyMagazynoweViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStanyMagazynoweViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void open(string name) 
        {
            if (name == "TowaryAdd") //name to jest wysłany komunikat
                CreateView(new NowyTowarViewModel()); // jesli odbierzemy komunikat to wywołujemy zakładke do dodawania nowego towaru
            if (name == "FakturyAdd") 
                CreateView(new NowaFakturaViewModel());
            if (name == "PracownicyAdd")
                CreateView(new NowyPracownikViewModel());
            if (name == "StatusyAdd")
                CreateView(new NowyStatusViewModel());
            if (name == "Sposoby PłatnościAdd")
                CreateView(new NowySposobPlatnosciViewModel());
            if (name == "ReklamacjeAdd")
                CreateView(new NowaReklamacjaViewModel());
            if (name == "KontrahenciAdd")
                CreateView(new NowyKontrahentViewModel());
            if (name == "RodzajeAdd")
                CreateView(new NowyRodzajViewModel());
            if (name == "AdresyAdd")
                CreateView(new NowyAdresViewModel());
            if (name == "MagazynyAdd")
                CreateView(new NowyMagazynViewModel());
            if (name == "Stany MagazynoweAdd")
                CreateView(new NowyStanMagazynowyViewModel());
            if (name == "KontrahenciAll")
                ShowAllKontrahenci();
        }
        //private void OnWorkspaceViewModelRequested(WorkspaceViewModel viewModel)
        //{
        //    this.Workspaces.Add(viewModel);
        //    this.SetActiveWorkspace(viewModel);
        //}
        #endregion
    }
}
