using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Killerapp2.DAL.Base
{
    public abstract class BaseRepository
    {
        private string _sql_server = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sande\source\repos\Killerapp2\Killerapp2\App_Data\Killerapp2DB.mdf;Integrated Security=True;Connect Timeout=30";

        public SqlConnection OpenConnection()
        {
            return new SqlConnection(_sql_server);
        }
    }
}
