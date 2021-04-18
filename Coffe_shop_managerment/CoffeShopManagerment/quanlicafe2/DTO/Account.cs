using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlicafe2.DTO
{
    public class Account
    {
        private string userName;
        private string displayName;
        private string passWord;
        private string gender;
        private string DOB;
        private string email;
        private string mobie;
        private string addresss;
        private int typeAccount;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string Gender { get => gender; set => gender = value; }
        public string DOB1 { get => DOB; set => DOB = value; }
        public string Email { get => email; set => email = value; }
        public string Mobie { get => mobie; set => mobie = value; }
        public string Addresss { get => addresss; set => addresss = value; }
        public int TypeAccount { get => typeAccount; set => typeAccount = value; }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Addresss = row["addresss"].ToString();
            this.DOB1 = row["DOB"].ToString();
            this.Email = row["email"].ToString();
            this.Gender = row["gender"].ToString();
            this.Mobie = row["mobie"].ToString();
            this.TypeAccount = (int)row["typeAccount"];
            this.PassWord = row["passWords"].ToString();

        }
        public Account(string userName, string displayName, string gender, string DOB, string email, string mobie, string addresss, int typeAccount, string passWord = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Addresss = addresss;
            this.DOB1 = DOB;
            this.Email = email;
            this.Gender = gender;
            this.Mobie = mobie;
            this.TypeAccount = typeAccount;
            this.PassWord = passWord;
        }
    }
}
