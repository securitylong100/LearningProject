using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;

namespace ConnectionString
{
    public class ConnectionDataTableSql
    {
        public DataTable callsql(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                NpgsqlConnection cn;
                cn = ConnectionServer.CreateConnection();
                NpgsqlDataAdapter da;
                da = new NpgsqlDataAdapter(sql, cn);
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL executeschalar moethod failed." + System.Environment.NewLine + ex.Message
                                , "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ConnectionServer.CreateConnection().Close();
                return dt;
            }
        }
    }
}
