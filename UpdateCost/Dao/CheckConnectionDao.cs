using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateCost.Vo;
using System.Data;
using ConnectionString;
using System.Windows.Forms;
using System.Drawing;


namespace UpdateCost.Dao
{
    public class CheckConnectionDao
    {
        //dsads
        //public DataTable ExcuteDao()
        //{

        //    DataTable dt = new DataTable();
        //    string sql = @"select max(warehouse_main_id) as a from t_warehouse_main";
        //    ConnectionDataTableSql consql = new ConnectionDataTableSql();
        //    dt = consql.callsql(sql);           
        //    return dt;
        //}
        public string ExcuteDao()
        {
            string data;
            string sql = @"select max(warehouse_main_id) as a from t_warehouse_main";
            ConnectionStringSql consql = new ConnectionStringSql();
            data = consql.callsql(sql);
            return data;
        }
    }
}
