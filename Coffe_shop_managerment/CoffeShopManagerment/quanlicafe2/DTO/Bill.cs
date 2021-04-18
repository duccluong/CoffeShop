using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DTO
{
    public class Bill
    {
        public Bill(int idBills, DateTime? dateCheckOut, DateTime? dateCheckIn, int statusBill, int discount,int price)
        {
            this.ID = idBills;
            this.DateCheckOut = dateCheckOut;
            this.DateCheckIn = dateCheckIn;
            this.StatusBill = statusBill;
            this.Discount = discount;
            this.Price = price;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["idBills"];
            var dataCheckOutTemp = row["dateCheckOut"];
            if (dataCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)row["dateCheckOut"];
 
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            this.StatusBill = (int)row["statusBill"];
            if (row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];
            this.Price = (int)row["price"];
        }
        private int statusBill;
        private int price;
        private DateTime? dateCheckIn;
        private DateTime ? dateCheckOut;
        private int iD;
        private int discount;

        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public int Price { get => price; set => price = value; }
        public int StatusBill { get => statusBill; set => statusBill = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
