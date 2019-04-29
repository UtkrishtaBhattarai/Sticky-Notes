using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkrishta_StickyNotes
{
    public class UserBll:IndividualBll
    {
        DbConnection conn = new DbConnection();
        public override int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public override int UserTypeID
        {
            get { return _UserTypeID; }
            set { _UserTypeID = value; }
        }
        public override string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public override string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public override string UAddress
        {
            get { return _UAddress; }
            set { _UAddress = value; }
        }
        public override string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        public override string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public override string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        public override string UPassword
        {
            get { return _UPassword; }
            set { _UPassword = value; }
        }
        DataTable dt = new DataTable();
        public void insert()
        {
            try
            {
                string query;
                query = "insert into Users(FirstName,LastName,UAddress,PhoneNumber,Gender,UserTypeID,Username,UPassword) values('"
                 + FirstName + "','" + LastName + "','" + UAddress + "'," + PhoneNumber + ",'" + Gender + "','" + 2 + "','" + Username + "','" + UPassword + "')";
                conn.manipulate(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
        public DataTable display()
        {
            try
            {
                string query;
                query = "select u.UserID,u.FirstName,u.LastName,u.UAddress,u.PhoneNumber,u.Gender,u.Username,u.UPassword,ut.UserTypeName " +
                    "from Users u,UserType ut where u.UserTypeID=ut.UserTypeID order by UserID desc";
                 dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
            return dt;
        }
         public override DataTable edisplay()
        {
            try
            {
                string query;
                query = "select u.FirstName,u.LastName,u.UAddress,u.PhoneNumber,u.Gender,u.Username,u.UPassword,ut.UserTypeName" +
                    " from Users u,UserType ut where u.UserTypeID=ut.UserTypeID and  UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
                return dt;
           
        }
        public DataTable displaycmb()
        {
            try
            {
                string query;
                query = "select UserTypeID,UserTypeName from UserType";
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
