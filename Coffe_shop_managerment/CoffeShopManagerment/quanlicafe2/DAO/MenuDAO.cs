using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "SELECT dr.nameDrinks, bd.countt, dr.price, dr.price*bd.countt AS totalPrice FROM dbo.detailBills AS bd, dbo.bills AS b, dbo.drinks AS dr WHERE bd.idBill = b.idBills AND bd.idDrinks = dr.idDrinks AND b.statusBill = 0 AND b.idTable = " + id;
            DataTable data = dataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
