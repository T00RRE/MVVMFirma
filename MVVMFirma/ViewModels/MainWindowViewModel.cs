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

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
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
            new BaseCommand(() => this.CreateView(new NowySposobPlatnosciViewModel())))
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
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
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
        #endregion
    }
}
