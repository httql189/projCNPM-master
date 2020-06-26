using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace projCNPM.Areas.Admin.Models
{
    public class SQLHelper
    {
        SqlConnection cn;
        public SQLHelper(string connectionstring)
        {
            cn = new SqlConnection(connectionstring);
        }
        public bool InConnection
        {
            get
            {
                try
                {
                    if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();
                    return true;
                }
                catch (Exception e)
                {

                }

                return false;
            }
        }
    }
}