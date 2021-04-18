using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DTO
{
    public class Table
    {
        public Table(int idTable, string nameTable, string statusTable) 
        {
            this.IdTable = idTable;
            this.NameTable = nameTable;
            this.StatusTable = statusTable;
        }
        public Table(DataRow row)
        {
            this.IdTable = (int)row["idTable"];
            this.NameTable = row["nameTable"].ToString();
            this.StatusTable = row["statusTable"].ToString();
        }
        private String nameTable;
        private int idTable;
        private String statusTable;

        public int IdTable { get => idTable; set => idTable = value; }
        public string NameTable { get => nameTable; set => nameTable = value; }
        public string StatusTable { get => statusTable; set => statusTable = value; }
    }
}
