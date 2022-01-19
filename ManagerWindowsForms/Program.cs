using System;
using System.Windows.Forms;
using Unity;
using BLLServiceManager.IService;
using BLLServiceManager.Service;
using DataAccessLogic.Interfaces;
using DataAccessLogic.ADO;


namespace ManagerWindowsForms
{
    static class Program
    {
        public static UnityContainer Container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureUnity();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<LogForm>());
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
