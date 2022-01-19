using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTO.Model;
using System.Security.Cryptography;
using BLLServiceManager.IService;

namespace ManagerWindowsForms
{
    public partial class RegisterForm : Form
    {
        IServiceProduct _productService;
        IServiceCategory _categoryService;
        IServiceSupplier _supplierService;
        IServiceManager _managerService;
        public RegisterForm(IServiceProduct product, IServiceCategory category, IServiceSupplier supplier, IServiceManager manager)
        {
            InitializeComponent();
            textBoxName.Text = "Name";
            textBoxName.ForeColor = Color.Gray;
            textBoxEmail.Text = "...@gmail.com";
            textBoxEmail.ForeColor = Color.Gray;
            textBoxPassword.Text = "password";
            textBoxPassword.ForeColor = Color.Gray;
           _productService = product;
            _categoryService = category;
            _supplierService = supplier;
            _managerService = manager;

        }
        bool isUserExists(Manager currManager)
        {
            bool res = false;
            foreach (var manager in _managerService.GetProducts())
            {
                if (manager.Email == currManager.Email)
                {
                    res = true;
                }
            }
            return res;
        }
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelSingIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogForm loginForm = new LogForm(_productService,_categoryService,_supplierService,_managerService);
            loginForm.Show();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name")
            {
                MessageBox.Show("input first name");
                return;
            }
            if (textBoxEmail.Text == "...@gmail.com")
            {
                MessageBox.Show("input e-mail");
                return;
            }
            if (textBoxPassword.Text == "password")
            {
                MessageBox.Show("input password");
                return;
            }
            Guid salt =  Guid.NewGuid();
            Manager newManager = new Manager();
            newManager.Name = textBoxName.Text;
            newManager.TimeUpdate = DateTime.Now;
            newManager.TimeInsert = DateTime.Now;
            newManager.Email = textBoxEmail.Text;
            newManager.Password = hash(textBoxPassword.Text,salt.ToString());
            newManager.Salt = salt;

            if (isUserExists(newManager) == false)
            {
                _managerService.AddObj(newManager);
                MessageBox.Show("Account created", "Succses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LogForm loginForm = new LogForm(_productService, _categoryService, _supplierService, _managerService);
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Already existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private byte[] hash(string pass, string salt)
        {
            var algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(pass + salt));
        }
    }
}
