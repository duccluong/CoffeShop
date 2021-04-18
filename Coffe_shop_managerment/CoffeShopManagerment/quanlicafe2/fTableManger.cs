using quanlicafe2.DAO;
using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlicafe2
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount.TypeAccount); }
        }

        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchTable);
        }
        #region Method
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "nameTypes";
        }

        void LoadDrinkListByCategoryID(int id)
        {
            List<Drink> listDrink = DrinkDAO.Instance.GetDrinkByCategoryID(id);
            cbDrink.DataSource = listDrink;
            cbDrink.DisplayMember = "nameDrinks";
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.NameTable + Environment.NewLine + item.StatusTable;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.StatusTable)
                {
                    case "Trống":
                        btn.BackColor = Color.LightBlue;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }

        }
        void ShowBill(int id)
        {   
            lsvBill.Items.Clear();
            List<quanlicafe2.DTO.Menu> listBillDetail = MenuDAO.Instance.GetListMenuByTable(id);
            int totalPrice = 0;
            foreach (quanlicafe2.DTO.Menu item in listBillDetail)
            {
                ListViewItem lsvItem = new ListViewItem(item.NameDrinks.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTotalPrice.Text = totalPrice.ToString("c", culture);
        }
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "NameTable";
        }
        #endregion


        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).IdTable;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
        }
        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAccountProfie f = new fAccountProfie();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.IdCategories;

            LoadDrinkListByCategoryID(id);
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.IdTable);
            int idDrink = (cbDrink.SelectedItem as Drink).IdDrink;
            int countt = (int)nmDrinkCount.Value;


            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.IdTable);
                BillDetailDAO.Instance.InsertBillDetail(BillDAO.Instance.GetMaxIDBill(), idDrink, countt);
            }
            else
            {
                BillDetailDAO.Instance.InsertBillDetail(idBill, idDrink, countt);
            }
            ShowBill(table.IdTable);
            LoadTable();
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.IdTable);
            int discount = (int)nmDiscount.Value;

            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0].Replace(".", ""));
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn " + table.NameTable +"\nTổng tiền: " + finalTotalPrice , "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (int)finalTotalPrice);
                    ShowBill(table.IdTable);
                    LoadTable();
                }
            }
        }
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            //Table table = lsvBill.Tag as Table;
            //double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            //int discount = (int)nmDiscount.Value;
            //double finaltotalPrice = totalPrice - ((totalPrice / 100) * discount);
            //CultureInfo culture = new CultureInfo("vi-VN");
            //txbTotalPrice.Text = finaltotalPrice.ToString("c", culture);
        }
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Table).IdTable;

            int id2 = (cbSwitchTable.SelectedItem as Table).IdTable;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển {0} qua {1}", (lsvBill.Tag as Table).NameTable, (cbSwitchTable.SelectedItem as Table).NameTable), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }
        #endregion
    }
}
