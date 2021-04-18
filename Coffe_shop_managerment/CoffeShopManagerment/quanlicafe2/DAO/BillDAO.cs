using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DAO
{
    public class BillDAO
    {
        private static object instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return (BillDAO)BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }
        public DataTable GetBillListDate(DateTime checkIn, DateTime checkOut)
        {
            return dataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillDate @checkIn , @checkOut", new object[] { checkIn, checkOut });

        }

        //Thành công: Bill ID
        //Thất bại: -1
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = dataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.bills WHERE idTable = " + id + " AND statusBill = 0");      

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }
        public void CheckOut(int id, int discount, int price)
        {
            string query = "UPDATE dbo.bills SET dateCheckOut = GETDATE(), statusBill = 1, " + "discount = " + discount +", price = " + price + " WHERE idBills = " + id;
            dataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            dataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { id });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)dataProvider.Instance.ExecuteScalar("SELECT MAX(idBills) FROM dbo.bills");
            }
            catch
            {
                return 1;
            }
        }
    }
}
