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
using System.Collections;

namespace MyWebSite.Modules
{
    public class ModuleData : Module
    {
        static SqlConnection connection = ConnectionManager.GetDatabaseConnection();

        public static Module NewModule(Module module)
        {
            int rowsaffected = 0;            
            string procedure = "NewModule";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ModuleTitle", SqlDbType.NVarChar, 50).Value = module.ModuleTitle;
            cmd.Parameters.Add("@EditRoles", SqlDbType.VarChar, 20).Value = module.EditRoles;
            cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = module.PageId;
            cmd.Parameters.Add("@ModuleDefinitionId", SqlDbType.Int).Value = module.ModuleDefinitionId;
            cmd.Parameters.Add("@PanelName", SqlDbType.VarChar, 10).Value = module.PanelName;
            cmd.Parameters.Add("@ModuleOrder", SqlDbType.Int).Value = module.ModuleOrder;

            rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
            return module;
            
        }

        public static Module LoadModuleData(int moduleid)
        {
            Module module = new Module();
            string select = string.Format("SELECT * FROM modules WHERE ModuleId='{0}'", moduleid.ToString());
            SqlCommand cmd = new SqlCommand(select, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();

            module.ModuleId = reader.GetInt32(0);
            module.ModuleTitle = reader.GetString(1);
            module.EditRoles = reader.GetString(2);
            module.PageId = reader.GetInt32(3);
            module.ModuleDefinitionId = reader.GetInt32(4);
            module.PanelName = reader.GetString(5);
            module.ModuleOrder = reader.GetInt32(6);

            connection.Close();
            return module;

        }

        public static void UpdateModule(Module module)
        {
            int rowsaffected = 0;
            string procedure = "UpdateModule";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ModuleId", SqlDbType.Int).Value = module.ModuleId;
            cmd.Parameters.Add("@ModuleTitle", SqlDbType.NVarChar, 50).Value = module.ModuleTitle;
            cmd.Parameters.Add("@EditRoles", SqlDbType.VarChar, 20).Value = module.EditRoles;
            cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = module.PageId;
            cmd.Parameters.Add("@ModuleDefinitionId", SqlDbType.Int).Value = module.ModuleDefinitionId;
            cmd.Parameters.Add("@PanelName", SqlDbType.VarChar, 10).Value = module.PanelName;
            cmd.Parameters.Add("@ModuleOrder", SqlDbType.Int).Value = module.ModuleOrder;

            rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static ArrayList GetAllModules(string pageid)
        {
            ArrayList modulelist = new ArrayList();            
            string select = string.Format("SELECT * FROM modules WHERE PageId='{0}' ORDER BY ModuleOrder", pageid);
            SqlCommand cmd = new SqlCommand(select, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dset = new DataSet();

            adapter.Fill(dset, "modules");     
            foreach (DataRow row in dset.Tables["modules"].Rows)
            {
                modulelist.Add(row["ModuleId"]);
            }

            connection.Close();
            return modulelist;
        }

        public static string GetModuleType(int moduledefid)
        {
            string select = string.Format("SELECT * FROM ModuleDefinition WHERE ModuleDefinitionId='{0}'", moduledefid.ToString());
            SqlCommand cmd = new SqlCommand(select, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader readder;
            readder = cmd.ExecuteReader();
            readder.Read();

            string filename = readder.GetString(2);
            connection.Close();
            return filename;
        }
                
    }
}
