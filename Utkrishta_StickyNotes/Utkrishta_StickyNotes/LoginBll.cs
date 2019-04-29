using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkrishta_StickyNotes
{
    public class LoginBll
    {
        DbConnection conn = new DbConnection();
        protected string _Username, _UPassword, query;
        
        public int Userid;

        public int UserID
        {
            get { return UserID; }
            set { UserID = value; }
        }
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string UPassword
        {
            get { return _UPassword; }
            set { _UPassword = value; }
        }
        DataTable dt = new DataTable();
        public int selectID()
        {
            try
            {
                string query;
                query = "select UserID from Users where Username='" + Username + "'";
                dt= conn.retrieve(query);
                Userid = int.Parse(dt.Rows[0][0].ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Userid;
        }
        public bool check()
        {
            try
            {
                query = "select UserID,Username,UPassword from Users where Username='" + Username + "' and UPassword='" + UPassword + "'";
                dt = conn.retrieve(query);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
