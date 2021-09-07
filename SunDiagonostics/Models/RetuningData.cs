using System;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace SunDiagonostics.Models
{
    public static class RetuningData
    {
     
        public static T AddOrSave<T>(String spName, DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-B666D0S; Integrated Security=true; Initial Catalog=SUNDIGNOSTIC");
            var result = (T)Convert.ChangeType(con.Execute(spName, param, commandType: CommandType.StoredProcedure),typeof(T));
            return result;
        }
        public static T ReturnSingleValue<T>(String spName, DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-B666D0S; Integrated Security=true; Initial Catalog=SUNDIGNOSTIC");
            var result = (T)Convert.ChangeType(con.ExecuteScalar(spName, param, commandType: CommandType.StoredProcedure), typeof(T));
            return result;
        }
        public static IEnumerable<T> ReturnigList<T>(String spName, DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-B666D0S; Integrated Security=true; Initial Catalog=SUNDIGNOSTIC");
            // var result = (T)Convert.ChangeType(con.Execute(spName, param, commandType: CommandType.StoredProcedure), typeof(T));
            return con.Query<T>(spName, param, commandType: CommandType.StoredProcedure);
        }

    }
}