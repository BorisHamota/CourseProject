using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLogic.Interfaces;
using DataAccessLogic.ADO;
using DTO.Model;
using BLLServiceManager.IService;

namespace ManagerWindowsForms
{
    public partial class MainForm : Form
    {
        readonly private IServiceProduct productsService;
        readonly private IServiceCategory categoriesService;
        readonly private IServiceSupplier suppliersService;
        readonly private IServiceManager managersService ;
        public MainForm(IServiceProduct productsServ, IServiceCategory categoriesServ, IServiceSupplier suppliersServ, IServiceManager managersServ)
        {
            InitializeComponent();
            pictureBoxHomeFirsrslide.BringToFront();
            productsService = productsServ;
            categoriesService = categoriesServ;
            suppliersService = suppliersServ;
            managersService = managersServ;

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managerServiceDataSet2.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.managerServiceDataSet2.Supplier);
            // TODO: This line of code loads data into the 'managerServiceDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.managerServiceDataSet.Category);


            dataGridViewProducts.DataSource = productsService.GetProducts();
            dataGridViewCategory.DataSource = categoriesService.GetProducts();
            dataGridViewSupplier.DataSource = suppliersService.GetProducts();
            dataGridViewStaff.DataSource = managersService.GetProductsWithoutPassword();
            
        }
        private void labelExite_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBoxHomeShowImagine_Click(object sender, EventArgs e)
        {
            pictureBoxHomeFirsrslide.BringToFront();
            pictureBoxShowTabControl.SendToBack();
        }
        private void pictureBoxShowTabControl_Click(object sender, EventArgs e)
        {
            pictureBoxShowTabControl.BringToFront();
            pictureBoxHomeFirsrslide.SendToBack();
        }
        private void pictureBoxRefreshProduct_Click(object sender, EventArgs e)
        {
            this.supplierTableAdapter.Fill(this.managerServiceDataSet2.Supplier);
            this.categoryTableAdapter.Fill(this.managerServiceDataSet.Category);
            productsService.ReadFromDataBase();
            BindingSource bs = new BindingSource();
            bs.DataSource = productsService.GetProducts();

            dataGridViewProducts.DataSource = bs;
            dataGridViewProducts.Refresh();
        }
        private void pictureBoxRefreshBlocked_Click(object sender, EventArgs e)
        {
            List<Product> productsBlocked = new List<Product>();
            productsService.ReadFromDataBase();
            
            foreach (var cat in categoriesService.GetProducts())
            {
                foreach (var prod in productsService.GetProducts())
                {
                    if (cat.IDCat == prod.CategoryID)
                    {
                        if (cat.IsBlocked == true)
                        {
                            productsBlocked.Add(prod);
                        }
                    }
                }
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = productsBlocked.ToArray();
            dataGridViewBlockedPr.DataSource = bs;
            dataGridViewBlockedPr.Refresh();
        }
        private void pictureBoxRefreshCategory_Click(object sender, EventArgs e)
        {
            categoriesService.ReadFromDataBase();
            BindingSource bs = new BindingSource();
            bs.DataSource = categoriesService.GetProducts();

            dataGridViewCategory.DataSource = bs;
            dataGridViewCategory.Refresh();
        }
        private void pictureBoxRefreshSupplier_Click(object sender, EventArgs e)
        {
            suppliersService.ReadFromDataBase();
            BindingSource bs = new BindingSource();
            bs.DataSource = suppliersService.GetProducts();

            dataGridViewSupplier.DataSource = bs;
            dataGridViewSupplier.Refresh();
        }
        private void pictureBoxRefreshStaff_Click(object sender, EventArgs e)
        {
            managersService.ReadFromDataBase();
            BindingSource bs = new BindingSource();
            bs.DataSource = managersService.GetProductsWithoutPassword();
            
            dataGridViewStaff.DataSource = bs;
            dataGridViewStaff.Refresh();

        }
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNameProduct.Text == "")
                {
                    MessageBox.Show("Input name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBoxPriceInProduct.Text == "" )
                {
                    MessageBox.Show("Input price in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBoxPriceoutProduct.Text == "")
                {
                    MessageBox.Show("Input price out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var index = comboBoxCategory.SelectedIndex;
                var index1 = comboBoxSupplier.SelectedIndex;
                Product newProduct = new Product();
                newProduct.NameObj = textBoxNameProduct.Text;
                newProduct.PriceIn = Convert.ToInt32(textBoxPriceInProduct.Text);
                newProduct.PriceOut = Convert.ToInt32(textBoxPriceoutProduct.Text);
                newProduct.RowInsertTime = DateTime.Now;
                newProduct.RowUpdateTime = DateTime.Now;
                newProduct.CategoryID =idCategory(index);
                newProduct.SupplierID = idSupplier(index1);

                productsService.AddObj(newProduct);
                MessageBox.Show("Already create", "Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxPriceoutProduct.Text = "";
                textBoxPriceInProduct.Text = "";
                textBoxNameProduct.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int idCategory(int index)
        {
            int currI = 0;
            for(int i=0; i < categoriesService.GetProducts().Count; i++)
            {
                if (i == index)
                {
                    currI= categoriesService.GetProducts()[i].IDCat;
                }
            }
            return currI;
        }
        private int idProduct(int index)
        {
            int currI = 0;
            for (int i = 0; i < productsService.GetProducts().Count; i++)
            {
                if (i == index)
                {
                    currI = productsService.GetProducts()[i].Id;
                }
            }
            return currI;
        }
        private int idSupplier(int index)
        {
            int currId = 0;
            for (int i = 0; i < suppliersService.GetProducts().Count; i++)
            {
                if (i == index)
                {
                    currId = suppliersService.GetProducts()[i].Id;
                }
            }
            return currId;
        }
        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxCategoryType.Text == "")
                {
                    MessageBox.Show("Input type ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Category newCategory = new Category();
                newCategory.TypeProduct = textBoxCategoryType.Text;
                newCategory.IsBlocked = checkBoxIsBlocked.Checked;
                newCategory.RowInsertTime = DateTime.Now;
                newCategory.RowUpdateTime = DateTime.Now;

                categoriesService.AddObj(newCategory);
                MessageBox.Show("Already create", "Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxCategoryType.Text = "";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNameSupplier.Text == "")
                {
                    MessageBox.Show("Input name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Supplier newSupplier = new Supplier();
                newSupplier.NameSupplier = textBoxNameSupplier.Text;
                newSupplier.ArrivingTime = dateTimePickerSupplier.Value;
                newSupplier.RowUpdateTime = dateTimePickerSupplier.Value;

                suppliersService.AddObj(newSupplier);
                MessageBox.Show("Already create", "Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxNameSupplier.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonEditCategoryBlocked_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxIdSelectedCategory.Text);
                string name = textBoxTypeSelectedCategory.Text;
                categoriesService.ChangeValueObj(id, name);
                bool op = checkBoxIsBlockedSelectedCategory.Checked;
                categoriesService.DeleteObject(id, op);
                MessageBox.Show("Already edited", "Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxIdSelectedCategory.Text = "";
                textBoxTypeSelectedCategory.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            int idCat = idCategory(e.RowIndex);
            var temp = categoriesService.GetObj(idCat);
            textBoxIdSelectedCategory.Text = Convert.ToString(idCat);
            checkBoxIsBlockedSelectedCategory.Checked= temp.IsBlocked;
            textBoxTypeSelectedCategory.Text = temp.TypeProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
        
            int idSupp = idCategory(e.RowIndex);
            var temp = suppliersService.GetObj(idSupp);
            textBoxIndexSupplierDelete.Text = Convert.ToString(temp.Id);
            textBoxEditNameSupplier.Text = temp.NameSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonEditNameSupplier_Click(object sender, EventArgs e)
        {
            try 
            {
            int id = Convert.ToInt32(textBoxIndexSupplierDelete.Text);
            string newname = textBoxEditNameSupplier.Text;
            suppliersService.ChangeValueObj(id,newname);
            MessageBox.Show("Already edited", "Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxIndexSupplierDelete.Text = "";
                textBoxEditNameSupplier.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonDeleteSupplier_Click(object sender, EventArgs e)
        {
            try { 
            int id = Convert.ToInt32(textBoxIndexSupplierDelete.Text);
            suppliersService.DeleteObject(id);
            MessageBox.Show("Already delete", "Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxIndexSupplierDelete.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int idProd = Convert.ToInt32(textBoxIndexProductDelete.Text);
                productsService.DeleteObject(idProd);
                MessageBox.Show("Already daleted", "Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxIndexProductDelete.Text = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idProd = idProduct(e.RowIndex);
                var temp = productsService.GetObj(idProd);
                textBoxIndexProductDelete.Text = Convert.ToString(idProd);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
