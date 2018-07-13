using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateCost.Dao;
using System.Data;

namespace UpdateCost.Cbm
{
  public  class CheckConnectionCbm
    {
        //public  DataTable ExcuteCbm()
        //{
        //    DataTable dt = new DataTable();
        //    CheckConnectionDao checkconnectionDao = new CheckConnectionDao();
        //    dt = checkconnectionDao.ExcuteDao();
        //    return dt;
        //}
        public string ExcuteCbm()
        {
            string data;
            CheckConnectionDao checkconnectionDao = new CheckConnectionDao();
            data = checkconnectionDao.ExcuteDao();
            return data;
        }

    }
}
