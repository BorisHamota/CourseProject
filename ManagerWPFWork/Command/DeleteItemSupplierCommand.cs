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
    class DeleteItemSupplierCommand : ICommand
    {

        private SupplierViewModel _supplierViewModel;

        public DeleteItemSupplierCommand(SupplierViewModel supplierViewModel)
        {
            _supplierViewModel = supplierViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _supplierViewModel.serviceSupplier.DeleteObject(_supplierViewModel.SelectedSupplier.Id);
           
                MessageBox.Show("Successfully delete supplier!", "Information");
           
          

        }
    }
}
