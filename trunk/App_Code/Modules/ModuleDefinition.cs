using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MyWebSite.Modules
{
    public class ModuleDefinition
    {
        public static void NewModuleType(string name, string file, bool vidible)
        {
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string procedure = "NewModuleType";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ModuleDefinitionName", SqlDbType.VarChar, 25).Value = name;
            cmd.Parameters.Add("@ModuleFile", SqlDbType.VarChar, 50).Value = file;
            cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = vidible;

            int rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}
