using StatesExam.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatesExam
{
    public class SqlCommands
    {
        public string Catalog { get; set; }
        private string ConnectionString = @"Data Source=CORE;Initial Catalog={0};User ID=sa;Password=secret";
        //private string ConnectionString = @"Data Source=core\sqlexpress;Initial Catalog={0};Integrated Security=True";
        public SqlCommands()
        {
            Catalog = DBCatalog.DB_Exam_Engine.ToString();
        }
        public SqlCommands(string cata)
        {
            Catalog = cata;
        }
        public void GetCMDConnection(string conn,string query, Action<SqlCommand> callback)
        {
            Catalog = conn;
            using (var con = new SqlConnection(String.Format(ConnectionString, Catalog)))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    callback(cmd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void GetCMDConnection(string query,Action<SqlCommand>callback)
        {
            using (var con = new SqlConnection(String.Format(ConnectionString, Catalog)))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(query,con);
                    callback(cmd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void TableCMD(string query, Action<DataTable> callback)
        {
            using (var con = new SqlConnection(String.Format(ConnectionString, Catalog)))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(query,con);
                    var dt = new DataTable();
                    var oldb = new SqlDataAdapter(cmd);
                    oldb.Fill(dt);
                    callback(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
              
            }
        }

        public void TableCMDStoredProcedures(string query, Action<DataTable> callback)
        {
            using (var con = new SqlConnection(String.Format(ConnectionString, Catalog)))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dt = new DataTable();
                    var oldb = new SqlDataAdapter(cmd);
                    oldb.Fill(dt);
                    callback(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }
        public void TableCMDStoredP(string query, Action<SqlCommand> callback)
        {
            using (var con = new SqlConnection(String.Format(ConnectionString, Catalog)))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                   
                    callback(cmd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }
        public void ReaderCMD(string query, Action<SqlDataReader> callback)
        {
            using (var con = new SqlConnection(String.Format(ConnectionString, Catalog)))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(query,con);
                    var dt = cmd.ExecuteReader();
                    callback(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
               
            }
        }
       
    }
}
