using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ThuVien
{
    public class SQL
    {
        public SqlConnection con;

        public SQL(string ConStr)
        {
            con = new SqlConnection(ConStr);
        }
        public void CreateConnection(string pConnectionString)
        {
            con = new SqlConnection(pConnectionString);            
        }

        public bool TestConnect()
        {
            try
            {
                con.Open();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ExcuteQuery(String pQuery)
        {
            DataTable DT = new DataTable();
            con.Open();
            using (SqlCommand cmd = new SqlCommand(pQuery, con))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(DT);
                }
            }
            con.Close();
            return DT;
        }

        public bool Insert(String pQuery)
        {
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(pQuery, con);
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(String pQuery)
        {
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = new SqlCommand(pQuery, con);
                adapter.UpdateCommand.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
