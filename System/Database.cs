using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace System
{

    class DataBase
    {
        SqlDataReader sqlDR;
        DataTable dt;
        SqlDataAdapter sqlDA;
        SqlCommand sqlCmd;
        SqlConnection sqlCon;
        string conStr;

        public DataBase()
        {
            conStr = @"Data Source=LAPTOP-50UMMBSJ\SQLEXPRESS;Initial Catalog=StudentDatabase;Integrated Security=True";
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
        }

        public int cudCMD(string sql)
        {
            sqlCmd = new SqlCommand(sql, sqlCon);
            return sqlCmd.ExecuteNonQuery();
        }

        public DataTable selectCmd(string sql)
        {
            dt = new DataTable();
            sqlDA = new SqlDataAdapter(sql, conStr);
            sqlDA.Fill(dt);
            sqlDA.Dispose();
            return dt;
        }

        public string ExecScalar(string sql)
        {
            sqlCmd = new SqlCommand(sql, sqlCon);
            object result = sqlCmd.ExecuteScalar();
            if (result == null)
                return "";
            return result.ToString();
        }

        public string ExecScalar1(string sql1)
        {
            sqlCmd = new SqlCommand(sql1, sqlCon);
            object result = sqlCmd.ExecuteScalar();
            if (result == null)
                return "";
            return result.ToString();
        }

        public string ExecScalar2(string sql2)
        {
            sqlCmd = new SqlCommand(sql2, sqlCon);
            object result = sqlCmd.ExecuteScalar();
            if (result == null)
                return "";
            return result.ToString();
        }

        public SqlDataReader DReader(string sql)
        {
            sqlCmd = new SqlCommand(sql, sqlCon);
            sqlDR = sqlCmd.ExecuteReader();
            return sqlDR;
        }
    }
}