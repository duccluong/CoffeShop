using quanlicafe2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DAO
{
    public class AccountDAO
    {
        private static object instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return (AccountDAO)AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = dataProvider.Instance.ExecuteQuery(" SELECT * FROM dbo.account WHERE userName = '" + userName +"'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public DataTable GetlistAccount()
        {
            return dataProvider.Instance.ExecuteQuery("SELECT  userName AS N'Tên đăng nhập', displayName AS N'Tên hiển thị', gender AS N'Giới tính',DOB AS N'Ngày tháng năm sinh', email AS N'Địa chỉ email',mobie AS N'Số điện thoại',typeAccount AS N'Loại tài khoản', addresss  AS N'Địa chỉ' FROM dbo.account ");
        }
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = dataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = dataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        public bool InsertAccount(string userName, string displayName, string gender, string DOB, string email, string mobie, string addresss, int typeAccount)
        {
            string query = string.Format("INSERT INTO dbo.account(userName,displayName,DOB, gender,email,mobie,addresss,typeAccount)VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',{7})", userName, displayName, gender, DOB, email, mobie, addresss, typeAccount);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool updateAccount(string userName, string displayName, string gender, string DOB, string email, string mobie, string addresss, int typeAccount)
        {
            string query = string.Format("UPDATE dbo.account SET displayName=N'{0}', gender='{1}',addresss=N'{2}',mobie=N'{3}',email=N'{4}',DOB=N'{5}',typeAccount ={6} WHERE userName=N'{7}'", displayName, gender, addresss, mobie, email, DOB, typeAccount, userName);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string userName)
        {
            string query = string.Format("DELETE FROM dbo.account WHERE userName=N'{0}'", userName);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool resetPassword(string userName)
        {
            string query = string.Format("UPDATE dbo.account SET passWords=N'0' WHERE userName=N'{0}'", userName);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateAccountinfo(string userName, string displayName, string pass, string newPass)
        {
            int result = dataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount  @userName ,@displayName ,@password,@newPassword ", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }
    }
}
