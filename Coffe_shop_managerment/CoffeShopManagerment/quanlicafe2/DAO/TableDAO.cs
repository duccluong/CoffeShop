using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return (TableDAO)TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        public static int TableWidth = 100;
        public static int TableHeight = 100;
        private TableDAO() { }

        public void SwitchTable(int id1, int id2)
        {
            dataProvider.Instance.ExecuteQuery("USP_SwitchTabel @idTable1 , @idTabel2", new object[] { id1, id2 });
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = dataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public bool InsertTable(int idTable, string nameTable, string statusTable)
        {
            string query = string.Format("INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)VALUES({0}, N'{1}',N'{2}')", idTable, nameTable, statusTable);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteTable(int idTable)
        {
            string query = string.Format("DELETE FROM dbo.tableDrinks WHERE idTable={0}", idTable);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        
    }
}
