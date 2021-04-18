using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DAO
{
    public class BillDetailDAO
    {
        private static object instance;

        public static BillDetailDAO Instance
        {
            get { if (instance == null) instance = new BillDetailDAO(); return (BillDetailDAO)BillDetailDAO.instance; }
            private set { BillDetailDAO.instance = value; }
        }
        private BillDetailDAO() { }
        public List<BillDetail> GetListBillDetail(int id)
        {
            List<BillDetail> listBillDetail = new List<BillDetail>();

            DataTable data = dataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.detailBills WHERE idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillDetail info = new BillDetail(item);
                listBillDetail.Add(info);
            }

            return listBillDetail;
        }
        public void InsertBillDetail(int idBill, int idDrink, int countt)
        {
            dataProvider.Instance.ExecuteNonQuery("USP_InsertBillDetail @idBill , @idDrink , @countt", new object[] { idBill, idDrink, countt });
        }
    }
}
