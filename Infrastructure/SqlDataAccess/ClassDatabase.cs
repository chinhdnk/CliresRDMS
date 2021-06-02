using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.Admin;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SqlDataAccess
{
    class ClassDatabase
    {
        //private readonly SqlConnectionConfiguration _ConnectionString;
        

        //Chinh 
        //public async Task<IEnumerable<TblUser>> ExcuteSelect(string query)
        //{
        //    IEnumerable<TblUser> userInfors;
        //    using (var conn= new SqlConnection(_ConnectionString.Value))
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();
        //        try{
        //            userInfors = await conn.QueryAsync<TblUser>(query);
        //        }
        //        catch(Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            if (conn.State == ConnectionState.Open)
        //                conn.Close();
        //        }
        //    }
        //    return userInfors;
        //}
    }
}
