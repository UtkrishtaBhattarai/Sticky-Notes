using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkrishta_StickyNotes
{
   public class PiechartBLL
    {
        DbConnection conn = new DbConnection();
        private string _Today;
        private string _Week;
        private string _Months;
        private string _Year;
        private int _UserID;
        DataTable dt=new DataTable();
        public string Today
        {
            get { return _Today; }
            set { _Today = value; }
        }
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string Week
        {
            get { return _Week; }
            set { _Week = value; }
        }
        public string Months
        {
            get { return _Months; }
            set { _Months = value; }
        }
        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public DataTable CompletedToday()
        {
            try
            {
                string query;
                query = "select COUNT(NoteID) from Notes where DateCreated='" + Today + "' and Completed=1 and UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public DataTable InCompleteToday()
        {
            try
            {
                string query;
                query = "select COUNT(NoteID) from Notes where DateCreated='" + Today + "' and Completed=0 and UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public DataTable CompleteWeek()
        {
            try
            {
                string query;
                query = "select COUNT(NoteID) from Notes where DateCreated<='" + Today + "' and DateCreated>='" + Week + "' and Completed=1 and UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public DataTable InCompleteWeek()
        {
            try
            {
                string query;
                query = "select COUNT(NoteID) from Notes where DateCreated<='" + Today + "' and DateCreated>='" + Week + "' and Completed=0 and UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public DataTable CompleteMonth()
        {
            try
            {
                string query;
                query = "select COUNT(NoteID) from Notes where DateCreated<='" + Today + "' and DateCreated>='" + Months + "' and Completed=1 and UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public DataTable InCompleteMonth()
        {
            try
            {
                string query;
                query = "select COUNT(NoteID) from Notes where DateCreated<='" + Today + "' and DateCreated>='" + Months + "' and Completed=0 and UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public DataTable CompleteYear()
        {
            try
            {
                string query;
                query = "select COUNT(NoteID) from Notes where DateCreated<='" + Today + "' and DateCreated>='" + Year + "' and Completed=1 and UserID=" + UserID;
                dt = conn.retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public DataTable InCompleteYear()
        {
            try
            {
                string query;
                query = "select COUNT(NoteID) from Notes where DateCreated<='" + Today + "' and DateCreated>='" + Year + "' and Completed=0 and UserID=" + UserID;
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
