using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utkrishta_StickyNotes
{
    class DbConnection
    {
       
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-M05PMCD;Initial Catalog=Utkrishta_StickyNotes;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataTable dtable = new DataTable();
    
        

        public void manipulate(string query)
        {
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
           
        }
        public DataTable retrieve(string query)
        {
            DataSet dSet = new DataSet();
            try
            {
                dAdapter = new SqlDataAdapter(query, connect);
                dAdapter.Fill(dSet);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dSet.Tables[0];
        }
    }
}
