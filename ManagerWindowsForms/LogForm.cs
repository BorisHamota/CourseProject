using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using BLLServiceManager.IService;

namespace ManagerWindowsForms
{
    
    public partial class LogForm : Form
    {
        IServiceProduct _productService;
        IServiceCategory _categoryService;
        IServiceSupplier _supplierService;
        IServiceManager _managerService;
        public LogForm(IServiceProduct product, IServiceCategory category, IServiceSupplier supplier, IServiceManager manager)
        {
            _productService = product;
            _categoryService = category;
            _supplierService = supplier;
            _managerService = manager;
            InitializeComponent();
           
        }

        private void ButtonSingIn_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                MessageBox.Show("input e-mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPassword.Text == "")
            {
                MessageBox.Show("input password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String loginUser = textBoxEmail.Text;
            var tempObj = _managerService.GetObj(loginUser);
            if (tempObj == null)
            {
                MessageBox.Show("Coudnt find u","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            Byte[] passUser = hash(textBoxPassword.Text, tempObj.Salt.ToString());
            bool hasAccount = true;
            
            if (loginUser == tempObj.Email)
            {
               for(int i = 0; i < passUser.Length; i++)
                {
                    if (passUser[i] != tempObj.Password[i])
                    {
                        hasAccount = false;
                    }
                }
            }


            if (hasAccount == true )
            {
                
                this.Hide();
                MainForm mainForm = new MainForm(_productService,_categoryService,_supplierService,_managerService);
                mainForm.Show();
                

            }
            else
            {
                MessageBox.Show("Incorrect password or login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void labelSingUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm(_productService,_categoryService,_supplierService,_managerService);
            registerForm.Show();
        }

        private void labelExite_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private byte[] hash(string pass, string salt)
        {
            var algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(pass + salt));
        }
    }
}
