using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkrishta_StickyNotes
{
    
  public class CategoryBll
    {
        LoginBll loginBll = new LoginBll();
        DbConnection conn = new DbConnection();
        private int _CategoryID;
        private string _CategoryType;
        private int _UserID;
        public int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        public int CategoryID
        {
            get
            {
                return _CategoryID;
            }
            set
            {
                _CategoryID = value;
            }
        }
        public string CategoryType
        {
            get
            {
                return _CategoryType;
            }
            set
            {
                _CategoryType = value;
            }
        }
        public String insert()
        {
            string query;
            try
            {
                query = "insert into Category(CategoryType,UserID) values('" + CategoryType + "','" + UserID + "')";
                conn.manipulate(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "inserted";


        } 
        public void update()
        {
            try
            {
                string query = "update Category set CategoryType='" + CategoryType + "' where CategoryID=" + CategoryID;
                conn.manipulate(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void delete()
        {
            try
            {
                string query;
                query = "delete from Category where CategoryID=" + CategoryID;
                conn.manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
           
        }
        public DataTable displaydatas()
        {
            DataTable dt = new DataTable();
            dt = null;
            try
            {
                string query;
                query = "select CategoryID,CategoryType,UserID from Category where UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;            
                      
        }
        public DataTable edisplaydatas()
        {
            DataTable dt = new DataTable();
            dt = null;
            try
            {
                string query;
                query = "select CategoryType from Category where CategoryID =" + CategoryID;
                dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;

        }
    }
}
