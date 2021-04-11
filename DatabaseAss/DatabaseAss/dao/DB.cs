using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseAss.dao
{
    public class DB
    {
        public SqlConnection con;
        public void MakeConnection(string strConnection)
        {
            con = new SqlConnection(strConnection);
        }
    }
}
