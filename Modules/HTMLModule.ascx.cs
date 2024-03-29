using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyWebSite;
using MyWebSite.Modules;
using System.Text.RegularExpressions;

public partial class Modules_HTMLModule : ModuleControlBaseClass
{
    protected HTMLModule htmlmodule = new HTMLModule();
        
    protected void Page_Load(object sender, EventArgs e)
    {        
        string path = HttpContext.Current.Request.ApplicationPath;
        TextEditor.scriptPath = path + "/Editor/scripts";
        if (AdminView)
            ModuleAdmin.Visible = true;
        else ModuleAdmin.Visible = false;
        if (!IsPostBack)
            updateViews();
        ModuleAdmin.ModuleId = this.ModuleId;
     
    }

    protected void ModuleAdmin_Edit(object sender, EventArgs e)
    {
        ViewMode = ModuleAdmin.ViewMode;        
        updateViews();        
    }

    protected void ModuleAdmin_DeleteModule(object sender, EventArgs e)
    {
        HTMLModuleData.DeleteHTMLModule(this.ModuleId);
        ModuleData.DeleteModule(this.ModuleId);
        Response.Redirect(Request.RawUrl);
    }

    protected void ModuleAdmin_MoveToPanel(object sender, EventArgs e)
    {
        //Move module to panel

        string panel = ModuleAdmin.Panel;
        Module module = ModuleData.LoadModuleData(ModuleId);
        module.PanelName = panel;
        ModuleData.UpdateModule(module);
        Response.Redirect(Request.RawUrl);
    }

    private void updateViews()
    {        
        HTMLModule htmlmodule = HTMLModuleData.LoadHTMLModuleData(this._moduleid);
        Module module = ModuleData.LoadModuleData(this.ModuleId);
        if (ViewMode == ViewMode.Edit)
        {
            ControlMultiView.SetActiveView(EditView);
            TextEditor.Text = htmlmodule.HtmlText;
            TitleTextBox.Text = module.ModuleTitle;
        }
        else
        {
            ControlMultiView.SetActiveView(ReadView);
            TitleLiteral.Text = "<h3>" + module.ModuleTitle + "</h3>";
            HtmlContent.Text = htmlmodule.HtmlText;
            DateLiteral.Text = "<br /> Created on: <b>" + htmlmodule.CreatedDate.ToShortDateString() + "</b> by " + "<b>" + htmlmodule.CreatedByUser + "</b><br />";
        }
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        Module module = ModuleData.LoadModuleData(this.ModuleId);
        htmlmodule.ModuleId = this.ModuleId;
        htmlmodule.HtmlText = TextEditor.Text;
        htmlmodule.SearchText = RemoveHTML(htmlmodule.HtmlText);
        htmlmodule.CreatedDate = DateTime.Now;
        HTMLModuleData.UpdateHTMLModule(htmlmodule);
        module.ModuleTitle = TitleTextBox.Text;
        ModuleData.UpdateModule(module);
        Response.Redirect(Request.RawUrl);

    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected static string RemoveHTML(string in_HTML)
    {
        return Regex.Replace(in_HTML, "<(.|\n)*?>", "");
    }
}
