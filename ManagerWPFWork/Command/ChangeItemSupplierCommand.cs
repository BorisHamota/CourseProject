using ManagerWPFWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ManagerWPFWork.Command
{
    class ChangeItemSupplierCommand : ICommand
    {

        private SupplierViewModel _supplierViewModel;

        public ChangeItemSupplierCommand(SupplierViewModel productViewModel)
        {

            this._supplierViewModel = productViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _supplierViewModel.serviceSupplier.ChangeValueObj(_supplierViewModel.SelectedSupplier.Id,_supplierViewModel.EnteredChangeNameSupplier);

            MessageBox.Show("Successfully change supplier's name !", "Information");


        }
    
    }
}
