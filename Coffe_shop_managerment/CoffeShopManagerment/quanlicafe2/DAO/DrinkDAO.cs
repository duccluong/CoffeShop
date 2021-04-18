using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DAO
{
    public class DrinkDAO
    {
        private static DrinkDAO instance;
        public static DrinkDAO Instance
        {
            get { if (instance == null) instance = new DrinkDAO(); return DrinkDAO.instance; }
            private set { DrinkDAO.instance = value; }
        }
        private DrinkDAO() { }
        
        public List<Drink> GetDrinkByCategoryID(int id)
        {
            List<Drink> list = new List<Drink>();

            string query = "select * from drinks where idCategories = " + id;

            DataTable data = dataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);
                list.Add(drink);
            }

            return list;
        }

        public List<Drink> GetListDrink()
        {
            List<Drink> list = new List<Drink>();

            string query = "select * from drinks";

            DataTable data = dataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);
                list.Add(drink);
            }

            return list;
        }

        public bool InsertDrink(int idDrink, int categoryID, string name, int price)
        {
            string query = string.Format(" INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price) VALUES({0},{1},N'{2}',{3})", idDrink, categoryID, name, price);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateDrink(int idDrink, int categoryID, string name, int price)
        {
            string query = string.Format(" UPDATE dbo.drinks SET  idCategories={0} , nameDrinks = N'{1}' , price={2} WHERE idDrinks = {3}", categoryID, name, price, idDrink);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteDrink(int idDrink)
        {
            string query = string.Format(" DELETE FROM dbo.drinks WHERE idDrinks={0}", idDrink);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
