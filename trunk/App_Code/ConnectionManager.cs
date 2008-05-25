using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyWebSite
{

    public class ConnectionManager
    {
        public static SqlConnection GetDatabaseConnection()
        {
            string connection = WebConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connection);
            myConnection.Open();
            return myConnection;
        }


    }
}