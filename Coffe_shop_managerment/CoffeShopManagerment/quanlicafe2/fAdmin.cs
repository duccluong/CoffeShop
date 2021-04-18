using quanlicafe2.DAO;
using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlicafe2
{
    public partial class fAdmin : Form
    {
        BindingSource drinkList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();
            load();
        }
        //HÀM LOAD
        void load()
        {
            dtgvDrink.DataSource = drinkList;
            loadDrinkList();
            addDrinkBinding();

            dtgvAccount.DataSource = accountList;
            loadAccountList();
            addAccountBinding();

            dtgvTable.DataSource = tableList;
            loadTableList();
            addTableBinding();

            dtgvCategory.DataSource = categoryList;
            loadCategoryList();
            addCategoryBinding();

            loadDateTimePickerBill();
            loadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            loadCategoryIntoCombobox(cbCategoty);
         
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        
        #region methods
        void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void loadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListDate(checkIn, checkOut);
        }

        void loadTableList()
        {
            string query = "SELECT idTable AS N'Mã bàn', nameTable AS N'Tên bàn', statusTable AS N'Trạng thái' FROM dbo.tableDrinks";
            tableList.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }
        void addTableBinding()
        {
            txbIdTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Mã bàn", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Tên bàn", true, DataSourceUpdateMode.Never));
            txbStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Trạng thái", true, DataSourceUpdateMode.Never));
        }

        void loadDrinkList()
        {
            string query = "SELECT idDrinks AS N'Mã đồ uống', idCategories AS N'Mã loại đồ uống',nameDrinks AS N'Tên', price AS N'Giá  tiền (VNĐ)' FROM dbo.drinks";
            drinkList.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }
        void addDrinkBinding()
        {
            //txbNameDrink.DataBindings.Add(new Binding("Text", dtgvDrink.DataSource, "nameDrinks"));
            txbDrinkID.DataBindings.Add(new Binding("Text", dtgvDrink.DataSource, "Mã đồ uống", true, DataSourceUpdateMode.Never));
            txbNameDrink.DataBindings.Add(new Binding("Text", dtgvDrink.DataSource, "Tên", true, DataSourceUpdateMode.Never));
            nmDrink.DataBindings.Add(new Binding("Value", dtgvDrink.DataSource, "Giá  tiền (VNĐ)", true, DataSourceUpdateMode.Never));
        }

        void loadAccountList()
        {
            string query = "SELECT  userName AS N'Tên đăng nhập', displayName AS N'Tên hiển thị', gender AS N'Giới tính',DOB AS N'Ngày tháng năm sinh', email AS N'Địa chỉ email',mobie AS N'Số điện thoại',typeAccount AS N'Loại tài khoản', addresss  AS N'Địa chỉ' FROM dbo.account";
            accountList.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }
        void addAccountBinding()
        {
            txbUserAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Tên đăng nhập", true, DataSourceUpdateMode.Never));
            txbDisplayAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Tên hiển thị", true, DataSourceUpdateMode.Never));
            txbEmail.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Địa chỉ email", true, DataSourceUpdateMode.Never));
            txbDOB.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Ngày tháng năm sinh", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never));
            txbMobie.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Số điện thoại", true, DataSourceUpdateMode.Never));
            nmAccount.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Loại tài khoản", true, DataSourceUpdateMode.Never));
            txbGender.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Giới tính", true, DataSourceUpdateMode.Never));

        }
        void loadCategoryList()
        {
            string query = "SELECT idCategories AS N'Mã loại nước uống', nameTypes AS N'Tên loại' FROM dbo.categories";
            categoryList.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }
        void addCategoryBinding()
        {
            txbIDCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Mã loại nước uống", true, DataSourceUpdateMode.Never));
            txbNameCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Tên loại", true, DataSourceUpdateMode.Never));
        }
        void loadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "nameTypes";
        }
        #endregion


        #region event
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            loadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        private void btnViewDrink_Click(object sender, EventArgs e)
        {
            loadDrinkList();
        }

        private void txbDrinks_textChanged(object sender, EventArgs e)
        {
            
        }
        private void txbNameDrink_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbDrinkID_textChanged(object sender, EventArgs e)
        {
            if (dtgvDrink.SelectedCells.Count > 0)
            {
                int id = (int)dtgvDrink.SelectedCells[0].OwningRow.Cells["Mã loại đồ uống"].Value;

                Category category = CategoryDAO.Instance.GetCategoryByID(id);
                cbCategoty.SelectedItem = category;

                int index = -1;
                int i = 0;
                foreach (Category item in cbCategoty.Items)
                {
                    if (item.IdCategories == category.IdCategories)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbCategoty.SelectedIndex = index;
            }
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            string name = txbNameDrink.Text;
            int categoryID = (cbCategoty.SelectedItem as Category).IdCategories;
            int idDrink = Convert.ToInt32(txbDrinkID.Text);
            int price = (int)nmDrink.Value;

            if (DrinkDAO.Instance.InsertDrink(idDrink, categoryID, name, price))
            {
                MessageBox.Show("Thêm thành công!!!!");
                loadDrinkList();
            }
            else
            {
                MessageBox.Show("Có lỗi!!!!");
            }
        }


        private void btnFixDrink_Click(object sender, EventArgs e)
        {
            string name = txbNameDrink.Text;
            int categoryID = (cbCategoty.SelectedItem as Category).IdCategories;
            int idDrink = Convert.ToInt32(txbDrinkID.Text);
            int price = (int)nmDrink.Value;

            if (DrinkDAO.Instance.UpdateDrink(idDrink, categoryID, name, price))
            {
                MessageBox.Show("Sửa thành công!!!");
                loadDrinkList();
            }
            else
            {
                MessageBox.Show("Có lỗi!!!");
            }
        }

        private void btnDeleteDrink_Click(object sender, EventArgs e)
        {
            int idDrink = Convert.ToInt32(txbDrinkID.Text);

            if (DrinkDAO.Instance.DeleteDrink(idDrink))
            {
                MessageBox.Show("Xoá thành công !!");
                loadDrinkList();
            }
            else
            {
                MessageBox.Show("Xoá không thành công!!!");
            }
        }
        //================= ACCOUNT =====================
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserAccount.Text;
            string displayName = txbDisplayAccount.Text;
            string email = txbEmail.Text;
            string dob = txbDOB.Text;
            string address = txbAddress.Text;
            string sdt = txbMobie.Text;
            string gender = txbGender.Text;
            int typeAccount = (int)nmAccount.Value;

            if (AccountDAO.Instance.InsertAccount(userName, displayName, gender, dob, email, sdt, address, typeAccount))
            {
                MessageBox.Show("Thêm thành công!!!");
                loadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi!!!");
            }
        }

        private void btnFixAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserAccount.Text;
            string displayName = txbDisplayAccount.Text;
            string email = txbEmail.Text;
            string dob = txbDOB.Text;
            string address = txbAddress.Text;
            string sdt = txbMobie.Text;
            string gender = txbGender.Text;
            int typeAccount = (int)nmAccount.Value;

            if (AccountDAO.Instance.updateAccount(userName, displayName, gender, dob, email, sdt, address, typeAccount))
            {
                MessageBox.Show("Sửa thành công!!!");
                loadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi!!!");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserAccount.Text;
            int typeAccount = (int)nmAccount.Value;

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xoá thành công!!!");
                loadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xoá!!!!");
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            loadAccountList();
        }
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string userName = txbUserAccount.Text;

            if (AccountDAO.Instance.resetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công!!!!");
                loadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!!!!");
            }
        }
        //==================== TABLE ================
        private void button1_Click(object sender, EventArgs e)
        {
            loadTableList();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string nameTable = txbTableName.Text;
            string statusTable = txbStatus.Text;
            int idTable = Convert.ToInt32(txbIdTable.Text);

            if (TableDAO.Instance.InsertTable(idTable, nameTable, statusTable))
            {
                MessageBox.Show("Thêm thành công!!!");
                loadTableList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm!!!");
            }
        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txbIdTable.Text);

            if (TableDAO.Instance.DeleteTable(idTable))
            {
                MessageBox.Show("Đã xoá thành công!!!");
                loadTableList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xoá!!!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int idCategories = Convert.ToInt32(txbIDCategory.Text);
            string nameTypes = txbNameCategory.Text;

            if (CategoryDAO.Instance.InsertCategory(idCategories, nameTypes))
            {
                MessageBox.Show("Đã thêm thành công!!!");
                loadCategoryList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm !!!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int idCategories = Convert.ToInt32(txbIDCategory.Text);

            if (CategoryDAO.Instance.DeleteCategory(idCategories))
            {
                MessageBox.Show("Đã xoá thành công!!!");
                loadCategoryList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xoá!!! ");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int idCategories = Convert.ToInt32(txbIDCategory.Text);
            string nameTypes = txbNameCategory.Text;

            if (CategoryDAO.Instance.UpdateCategory(idCategories, nameTypes))
            {
                MessageBox.Show("Đã sửa thành công!!!");
                loadCategoryList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa !!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadCategoryList();
        }
        #endregion

        
    }
}
