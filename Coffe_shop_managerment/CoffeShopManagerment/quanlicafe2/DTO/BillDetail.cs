using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DTO
{
    public class BillDetail
    {
        public BillDetail(int idDetail, int idBill, int idDrinks, int count)
        {
            this.ID = idDetail;
            this.IdBill = idBill;
            this.IdDrinks = idDrinks;
            this.Count = count;
        }
        public BillDetail(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IdBill = (int)row["idBill"];
            this.IdDrinks = (int)row["idDrinks"];
            this.Count = (int)row["count"];
        }
        private int count;
        private int idDrinks;
        private int idBill;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdDrinks { get => idDrinks; set => idDrinks = value; }
        public int Count { get => count; set => count = value; }
    }
}
