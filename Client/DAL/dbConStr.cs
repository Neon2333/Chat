using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Client.DAL
{
    public class dbConStr
    {
        private string strCon;
        public dbConStr()
        {
            //this.strCon = ConfigurationManager.ConnectionStrings["connMysql"].ConnectionString;
        }

        public string GetDbConStr()
        {
            return this.strCon;
        }
    }
}
