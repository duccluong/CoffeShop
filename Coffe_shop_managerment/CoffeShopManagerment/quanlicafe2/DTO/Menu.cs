using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DTO
{
    public class Menu
    {
        public Menu(string nameDrinks, int count, int price, int totalPrice)
        {
            this.NameDrinks = nameDrinks;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public Menu(DataRow row)
        {
            this.NameDrinks = row["nameDrinks"].ToString();
            this.Count = (int)row["countt"];
            this.Price = (int)row["price"];
            this.TotalPrice = (int)row["totalPrice"];
        }
        private string nameDrinks;
        private int count;
        private int price;
        private int totalPrice;

        public string NameDrinks { get => nameDrinks; set => nameDrinks = value; }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
