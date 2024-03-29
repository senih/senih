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

        public static Module NewModule(Module module)
        {
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            int id = 0;            
            string procedure = "NewModule";
            SqlCommand cmd = new SqlCommand(procedure, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ModuleTitle", SqlDbType.NVarChar, 50).Value = module.ModuleTitle;
            cmd.Parameters.Add("@EditRoles", SqlDbType.VarChar, 20).Value = module.EditRoles;
            cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = module.PageId;
            cmd.Parameters.Add("@ModuleDefinitionId", SqlDbType.Int).Value = module.ModuleDefinitionId;
            cmd.Parameters.Add("@PanelName", SqlDbType.VarChar, 10).Value = module.PanelName;
            cmd.Parameters.Add("@ModuleOrder", SqlDbType.Int).Value = module.ModuleOrder;

            id = int.Parse(cmd.ExecuteScalar().ToString());
            module.ModuleId = id;
            connection.Close();
            return module;
            
        }

        public static Module LoadModuleData(int moduleid)
        {
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
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
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
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

        public static void DeleteModule(int moduleid)
        {            
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string delete = string.Format("DELETE FROM modules WHERE ModuleId='{0}'", moduleid.ToString());
            SqlCommand cmd = new SqlCommand(delete, connection);
            cmd.CommandType = CommandType.Text;
            int rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
        }


        public static ArrayList GetAllModules(string pageid)
        {
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
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

        public static ArrayList GetModulesInPanel(int pageid, string panel)
        {
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            ArrayList modulelist = new ArrayList();
            string select = string.Format("SELECT * FROM modules WHERE PageId='{0}' AND PanelName='{1}' ORDER BY ModuleOrder", pageid.ToString(), panel);
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
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
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

        public static string GetModuleName(int moduleid)
        {
            SqlConnection connection = ConnectionManager.GetDatabaseConnection();
            string select = string.Format("SELECT ModuleDefinition.ModuleDefinitionName FROM modules INNER JOIN ModuleDefinition ON modules.ModuleDefinitionId = ModuleDefinition.ModuleDefinitionId WHERE modules.ModuleId='{0}'", moduleid.ToString());
            SqlCommand cmd = new SqlCommand(select, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();

            string modulename = reader["ModuleDefinitionName"].ToString();
            connection.Close();
            return modulename;
        }

        public static void MoveModuleUp(int moduleid)
        {
            Module module = ModuleData.LoadModuleData(moduleid);
            ArrayList modulelist = ModuleData.GetModulesInPanel(module.PageId, module.PanelName);
            int index = modulelist.IndexOf(moduleid);
            if (index > 0)
            {
                int prevmoduleid = int.Parse(modulelist[index - 1].ToString());
                Module prevmodul = ModuleData.LoadModuleData(prevmoduleid);
                int temp1 = module.ModuleOrder;
                int temp2 = prevmodul.ModuleOrder;
                module.ModuleOrder = temp2;
                prevmodul.ModuleOrder = temp1;
                ModuleData.UpdateModule(module);
                ModuleData.UpdateModule(prevmodul);
            }

        }

        public static void MoveModuleDown(int moduleid)
        {
            Module module = ModuleData.LoadModuleData(moduleid);
            ArrayList modulelist = ModuleData.GetModulesInPanel(module.PageId, module.PanelName);
            int index = modulelist.IndexOf(moduleid);
            if (index < modulelist.Count - 1)
            {
                int succmoduleid = int.Parse(modulelist[index + 1].ToString());
                Module succmodule = ModuleData.LoadModuleData(succmoduleid);
                int temp1 = module.ModuleOrder;
                int temp2 = succmodule.ModuleOrder;
                module.ModuleOrder = temp2;
                succmodule.ModuleOrder = temp1;
                ModuleData.UpdateModule(module);
                ModuleData.UpdateModule(succmodule);
            }

        }

    }
}
