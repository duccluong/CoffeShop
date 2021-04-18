using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DAO
{
    public class CategoryDAO
    {
        private static object instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return (CategoryDAO)CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from categories";

            DataTable data = dataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }
        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = " SELECT * FROM dbo.categories WHERE idCategories =" + id;

            DataTable data = dataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }
        public bool InsertCategory(int idCategories, string nameTypes)
        {
            string query = string.Format("INSERT INTO dbo.categories(idCategories,nameTypes)VALUES({0},N'{1}')", idCategories, nameTypes);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateCategory(int idCategories, string nameTypes)
        {
            string query = string.Format("UPDATE dbo.categories SET nameTypes=N'{0}' WHERE idCategories={1}", nameTypes, idCategories);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteCategory(int idCategories)
        {
            string query = string.Format("DELETE FROM dbo.categories WHERE idCategories = {0}", idCategories);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
