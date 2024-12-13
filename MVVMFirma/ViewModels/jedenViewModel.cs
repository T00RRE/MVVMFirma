using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class jedenViewModel<T>:WorkspaceViewModel
    {
        #region DB
        protected Faktury2024Entities FakturyEntities;
        #endregion
        #region Item
        protected T item;
        #endregion
        #region Command 
        //to jest komenda, która zostanie podpieta pod przycisk zapisz i zamknij i ona wywola funkcje SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;

            }


        }
        #endregion
        #region Konstruktor
        public jedenViewModel(String displayName)
        {
            base.DisplayName = displayName;
            FakturyEntities = new Faktury2024Entities();
            
        }
        #endregion
        #region Helpers
        public abstract void Save();
        public  void SaveAndClose()
        {
            Save();
            base.OnRequestClose(); //zamkniecie zakladki
        }
        
        #endregion
    }
}
