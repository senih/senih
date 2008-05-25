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
using System.Text.RegularExpressions;

namespace MyWebSite
{


    public class WebPageData : WebPage
    {

        public static string NewWebPage()
        {            
            WebPage newpage = new WebPage();
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string procedure = "NewWebPage";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar, 50).Value = "";
            cmd.Parameters.Add("@NavigationName", SqlDbType.NVarChar, 50).Value = "New Page";
            cmd.Parameters.Add("@VirtualPath", SqlDbType.VarChar, 50).Value = "";
            cmd.Parameters.Add("@AccessRole", SqlDbType.VarChar, 20).Value = "Anonymous";
            cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = true;

            string pageid = cmd.ExecuteScalar().ToString();
            connection.Close();            
            return pageid;           

        }

        public static void DeletePage(string pageId)
        {
            int rowsaffected = 0;
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string delete = string.Format("DELETE FROM WebPage WHERE PageId='{0}'", pageId);
            SqlCommand cmd = new SqlCommand(delete, connection);
            cmd.CommandType = CommandType.Text;
            rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdatePage(WebPage page)
        {
            int rowsaffected = 0;
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string procedure = "UpdatePage";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = page.PageId;
            cmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar, 50).Value = page.Title;
            cmd.Parameters.Add("@NavigationName", SqlDbType.NVarChar, 50).Value = page.NavigationName;
            cmd.Parameters.Add("@VirtualPath", SqlDbType.VarChar, 50).Value = page.VirtualPath;
            cmd.Parameters.Add("@AccessRole", SqlDbType.VarChar, 20).Value = page.AccessRole;
            cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = page.Visible;

            rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static WebPage LoadPageData(string pageId)
        {
            WebPage page = new WebPage();
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string select = string.Format("SELECT * FROM WebPage WHERE PageId='{0}'", pageId);
            SqlCommand cmd = new SqlCommand(select, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();

            page.PageId = reader.GetInt32(0);
            page.Title = reader.GetString(1);
            page.NavigationName = reader.GetString(2);
            page.VirtualPath = reader.GetString(3);
            page.AccessRole = reader.GetString(4);
            page.Visible = reader.GetBoolean(5);

            connection.Close();
            return page;
        }

        public static string GetWebPageId(string temp)
        {
            int position = temp.LastIndexOf("/");
            string url = "~" + temp.Substring(position);
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string procedure = "GetWebPageId";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VirtualPath", SqlDbType.VarChar, 50).Value = url;
            string pageId = cmd.ExecuteScalar().ToString();
            connection.Close();
            return pageId;
        }

        public static void UpdateVirtualPath(string pageId)
        {
            int rowsaffected = 0;
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string update = string.Format("UPDATE WebPage SET VirtualPath='~/default{0}.aspx' WHERE PageId='{0}'", pageId);
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.CommandType = CommandType.Text;
            rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();

        }

        public static bool IsValidUrl(string url)
        {
            if ((url.StartsWith("~/")) && (url.EndsWith(".aspx")))
            {
                int pos1 = url.IndexOf("/");
                pos1 += 1;
                int pos2 = url.LastIndexOf(".");
                int len = pos2 - pos1;
                string temp = url.Substring(pos1, len);
                bool alphanum = IsAlphaNumeric(temp);
                return alphanum;
            }
            else return false;
        }

        public static bool IsAlphaNumeric(string strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9 ]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        } 
    }
}
