using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkrishta_StickyNotes
{
    public class IndividualBll
    {
        LoginBll loginBll = new LoginBll();
        protected  int _UserID;
        protected string _FirstName;
        protected string _LastName;
        protected string _UAddress;
        protected string _PhoneNumber;
        protected string _Gender;
        protected string _Username;
        protected string _UPassword;
        protected int _UserTypeID;
        DbConnection conn = new DbConnection(); 
        public virtual int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        
        public virtual int UserTypeID
        {
            get { return _UserTypeID; }
            set { _UserTypeID = value; }
        }
        public virtual string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public virtual string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public virtual string UAddress
        {
            get { return _UAddress; }
            set { _UAddress = value; }
        }
        public virtual string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        public virtual string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public virtual string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
       
        public virtual string UPassword
        {
            get { return _UPassword; }
            set { _UPassword = value; }
        }
        DataTable dt = new DataTable();
        public virtual string update()
        {
            try
            {
                string query = "update Users set FirstName='" + FirstName + "',LastName='" + LastName + "',UAddress='" + UAddress +
                    "',PhoneNumber='" + PhoneNumber + "',Gender='" + Gender + "',Username='" + Username + "',UPassword='" + UPassword +
                    "' where UserID=" + UserID;
                conn.manipulate(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Done";
        }
        public DataTable display()
        {
            try
            {
             string query;
           query = "select u.UserID,u.FirstName,u.LastName,u.UAddress,u.PhoneNumber,u.Gender,u.Username,u.UPassword,ut.UserTypeName from Users u,UserType ut where" +
                   " u.UserTypeID=ut.UserTypeID and UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

    public virtual DataTable edisplay()
    {
    try
    {
    string query;
    query = "select u.FirstName,u.LastName,u.UAddress,u.PhoneNumber,u.Gender,u.Username,u.UPassword,ut.UserTypeName from Users u,UserType ut where" +
                    " u.UserTypeID=ut.UserTypeID and UserID=" + UserID;
    dt = conn.retrieve(query);
    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public void delete()
        {
            try
            {
                string query;
                query = "delete from Users where userID=" + UserID;
                conn.manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
        
    }
}
