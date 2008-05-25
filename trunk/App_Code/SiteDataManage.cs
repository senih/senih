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
using System.Web.Configuration;

namespace MyWebSite
{

    public class SiteDataManage : WebSite
    {

        public static WebSite LoadData()
        {
            WebSite site = new WebSite();
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string select = "SELECT * FROM WebSite WHERE WebSiteId='1'";
            SqlCommand cmd = new SqlCommand(select, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();

            
            site.Theme = reader.GetString(1);
            site.Lang = reader.GetString(2);
            site.SmtpServer = reader.GetString(3);
            site.SmtpUser = reader.GetString(4);
            site.SmtpPassword = reader.GetString(5);
            site.SmtpDomain = reader.GetString(6);
            site.MailSenderAddress = reader.GetString(7);
            site.FooterText = reader.GetString(8);
            site.WebSiteTitle = reader.GetString(9);
            site.Keywords = reader.GetString(10);
            site.Description = reader.GetString(11);

            connection.Close();
            return site;
        }

        public static void SaveData(WebSite site)
        {            
            int rowsAffected = 0;
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string procedure = "UpdateSiteData";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Theme", SqlDbType.NVarChar, 20).Value = site.Theme;
            cmd.Parameters.Add("@Lang", SqlDbType.NVarChar, 20).Value = site.Lang;
            cmd.Parameters.Add("@SmtpServer", SqlDbType.VarChar, 50).Value = site.SmtpServer;
            cmd.Parameters.Add("@SmtpUser", SqlDbType.NVarChar, 50).Value = site.SmtpUser;
            cmd.Parameters.Add("@SmtpPassword", SqlDbType.NVarChar, 50).Value = site.SmtpPassword;
            cmd.Parameters.Add("@SmtpDomain", SqlDbType.VarChar, 50).Value = site.SmtpDomain;
            cmd.Parameters.Add("@MailSenderAddress", SqlDbType.VarChar, 50).Value = site.MailSenderAddress;
            cmd.Parameters.Add("@FooterText", SqlDbType.NVarChar, 100).Value = site.FooterText;
            cmd.Parameters.Add("@WebSiteTitle", SqlDbType.NVarChar, 50).Value = site.WebSiteTitle;
            cmd.Parameters.Add("@Keywords", SqlDbType.NVarChar, 1000).Value = site.Keywords;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value = site.Description;

            rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();

        }

        public static void DeleteData()
        {
            int rowsAffected = 0;
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string procedure = "DeleteSiteData";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();
            
        }
    }
}