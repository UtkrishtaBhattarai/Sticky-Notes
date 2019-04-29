 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utkrishta_StickyNotes
{
    public class StickyNotesBll
    {
        DbConnection conn = new DbConnection();
        private int _UserID;
        private int _NoteID;
        private int _CategoryID;
        private string _searchvalue;
        private string _Contents;
        private bool _Sticked;
        private bool _Completed;
        private string _Title;
        String FName;
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public bool Sticked
        {
            get { return _Sticked; }
            set { _Sticked = value; }
        }
        public bool Completed
        {
            get { return _Completed; }
            set { _Completed = value; }
        }
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public int NoteID
        {
            get { return _NoteID; }
            set { _NoteID = value; }
        }
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public string searchvalue
        {
            get { return _searchvalue; }
            set { _searchvalue = value; }
        }
        DataTable dt = new DataTable();
        DataTable search = new DataTable();
        public DataTable NoteCount()
        {
           
            dt = null;
            try
            {
                string query;
                query = "select NoteID from Notes where UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
                return dt;
        }
        public DataTable getNote()
        {
           dt = null;
            try
            {
                string query;
                query = "select DateCreated,Title,Contents,Sticked,Completed,CategoryID,NoteID from Notes where UserID =" + UserID + " order by Completed asc ";
                dt= conn.retrieve(query);  
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());             
            }
            return dt;
        }
        public DataTable Category()
        {
            try
            {
                string query;
                query = "select CategoryType from Category where CategoryID=" + CategoryID;
                dt = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           return dt;
        }
public DataTable NoofCompletedNotes()
        {
            DataTable comple = new DataTable();
            try
            {
                string query;
                query = "select COUNT(Completed) from Notes Where Completed=1 and UserID=" + UserID;
                comple = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
             return comple;
        }

        public DataTable NoofIncompleteNotes()
        {
            DataTable incom = new DataTable();

            try
            {
                string query;
                query = "select COUNT(Completed) from Notes Where Completed=0 and UserID=" + UserID;
                incom = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return incom;
        }
        public DataTable countNote()
        {
            try
            {
                string query;
                query = "select NoteID from Notes Where Title like '%" + _searchvalue + "%' and UserID=" + _UserID;
                search = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return search;
        }
        public DataTable searchNote()
        {
            try
            {
                string query;
                query = "select DateCreated,Title,Contents,Sticked,Completed,CategoryID,NoteID from Notes Where Title like '%" + _searchvalue +
                    "%' and UserID=" + _UserID;
                search = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return search;
        }
        public String delete()
        {
            try
            {
                string query;
                query = "delete from Notes where NoteID=" + NoteID;
                conn.manipulate(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Deleted Successfully";
        }
        public void update()
        {
            try
            {
                string query;
                query = "update Notes set Contents='" + Contents + "',Completed='" + Completed + "',Sticked='" + Sticked + "' where NoteID=" + NoteID; 
                   
                conn.manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public String Getname()
        {
            
            try
            {
                string query;
                query = "Select FirstName,LastName from Users Where UserID=" + UserID;
                dt = conn.retrieve(query);
                FName= dt.Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return FName;

        }

      
    }
}
