using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DTO
{
    public class Category
    {
        public Category(int idCategories, string nameTypes)
        {
            this.IdCategories = idCategories;
            this.NameTypes = nameTypes;
        }

        public Category(DataRow row)
        {
            this.IdCategories = (int)row["idCategories"];
            this.NameTypes = row["nameTypes"].ToString();
        }

        private string nameTypes;

        public string NameTypes
        {
            get { return nameTypes; }
            set { nameTypes = value; }
        }

        private int idCategories;

        public int IdCategories
        {
            get { return idCategories; }
            set { idCategories = value; }
        }
    }
}
