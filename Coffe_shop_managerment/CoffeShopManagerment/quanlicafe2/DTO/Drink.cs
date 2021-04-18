using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DTO
{
    public class Drink
    {
        public Drink(int idDrinks, string nameDrinks, int idCategories, int price)
        {
            this.IdDrink = idDrinks;
            this.NameDrinks = nameDrinks;
            this.IdCategory = idCategories;
            this.Price = price;
        }
        public Drink(DataRow row)
        {
            this.IdDrink = (int)row["idDrinks"];
            this.NameDrinks = row["nameDrinks"].ToString();
            this.IdCategory = (int)row["idcategories"];
            this.Price = (int)Convert.ToDouble(row["price"].ToString());
        }
        private int idDtrink;
        public int IdDrink
        {
            get { return idDtrink; }
            set { idDtrink = value; }
        }
        private string nameDrinks;

        public string NameDrinks
        {
            get { return nameDrinks; }
            set { nameDrinks = value; }
        }
        private int idCategory;

        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
