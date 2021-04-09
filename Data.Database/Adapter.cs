using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection _sqlConn;

        protected SqlConnection SqlConn
        {
            get
            {
                return _sqlConn;
            }
            set
            {
                _sqlConn = value;
            }
        }

        const string constDefaultConnString = "connString";

        protected void OpenConnection()
        {
            SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings[constDefaultConnString].ConnectionString);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            if (SqlConn != null)
            {
                SqlConn.Close();
                SqlConn = null;
            }
        }
    }
}
