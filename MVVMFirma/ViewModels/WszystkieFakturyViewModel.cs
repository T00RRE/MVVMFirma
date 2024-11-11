using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieFakturyViewModel : WorkspaceViewModel // bo wszystkie zakładki dziedziczą po WVM
    {
        public WszystkieFakturyViewModel()
        {
            base.DisplayName = "Faktury";
        }
    }
}
