using BLLServiceManager.IService;
using BLLServiceManager.Service;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using ManagerWPFWork.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;

namespace ManagerWPFWork.Windows
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        public static UnityContainer Container;
        private ViewModelBase m_ViewModel;
       
        public WindowMain()
        {
            ConfigureUnity();
            InitializeComponent();
            DataContext = Container.Resolve<MainViewModel>();
            m_ViewModel = new ViewModelBase();

        }
        static private void ConfigureUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<IServiceCategory, ServiceCategory>()
                     .RegisterType<IServiceSupplier, ServiceSupplier>()
                     .RegisterType<IServiceProduct, ServiceProduct>()
                     .RegisterType<IServiceManager, ServiceManager>()
                     .RegisterType<ICategoryDAL, CategoryDAL>()
                     .RegisterType<ISupplierDAL, SupplierDAL>()
                     .RegisterType<IProductDAL, ProductDAL>()
                     .RegisterType<IManagerDAL, ManagerDAL>();
        }
    }
}
