using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkrishta_StickyNotes
{
      public class CreateFormBll
      {
        private int _UserID;
        private int _NoteID;
        private string _DateCreated;
        private bool _Stickied;
        private bool _Completed;
        private int _CategoryID;
        private string _Contents;
        private string _Title;

        DbConnection conn = new DbConnection();

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
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
        public string DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }
        public bool Sticked
        {
            get { return _Stickied; }
            set { _Stickied = value; }
        }
        public bool Completed
        {
            get { return _Completed; }
            set { _Completed = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        public DataTable displaycmb()
        {
            DataTable dt = new DataTable();
            try
            {
                string query;
                query = "select CategoryID,CategoryType from Category where UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public void insert()
        {
            try
            {
                string query;
                query = "insert into Notes(DateCreated,Title,Contents,Sticked,Completed,UserID,CategoryID) values('"
                 + DateCreated + "','" + Title + "','" + Contents + "','" + Sticked + "','" + Completed + "','" + UserID + "','" + CategoryID + "')";
                conn.manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            

        }
    }
}
