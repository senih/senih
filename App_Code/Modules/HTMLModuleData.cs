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
    public class HTMLModuleData : Module
    {
        static SqlConnection connection = ConnectionManager.GetDatabaseConnection();

        public static HTMLModule NewHTMLModule(HTMLModule module)
        {            
            int rowsaffected = 0;
            string procedure = "NewHTMLModule";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@HtmlText", SqlDbType.NText).Value = "";
            cmd.Parameters.Add("@SearchText", SqlDbType.NText).Value = "";
            cmd.Parameters.Add("@CreatedByUser", SqlDbType.NVarChar, 50).Value = module.CreatedByUser;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = module.CreatedDate;
            cmd.Parameters.Add("@ModuleId", SqlDbType.Int).Value = module.ModuleId;

            rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
            return module;
        }

        public static void UpdateHTMLModule(HTMLModule module)
        {
            int rowsaffected = 0;
            string procedure = "UpdateHTMLModule";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ModuleId", SqlDbType.Int).Value = module.ModuleId;
            cmd.Parameters.Add("@HtmlText", SqlDbType.NText).Value = module.HtmlText;
            cmd.Parameters.Add("@SearchText", SqlDbType.NText).Value = module.SearchText;            
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = module.CreatedDate;

            rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static HTMLModule LoadHTMLModuleData(int moduleid)
        {
            HTMLModule module = new HTMLModule();
            string select = string.Format("SELECT * FROM HTMLTextModule WHERE ModuleId='{0}'", moduleid);
            SqlCommand cmd = new SqlCommand(select, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();

            module.HTMLModuleId = reader.GetInt32(0);
            module.ModuleId = reader.GetInt32(1);
            module.HtmlText = reader.GetString(2);
            module.SearchText = reader.GetString(3);
            module.CreatedByUser = reader.GetString(4);
            module.CreatedDate = reader.GetDateTime(5);

            connection.Close();
            return module;
        }
    }
}
