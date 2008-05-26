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

public partial class Modules_HTMLModule : ModuleControlBaseClass
{
    HTMLModule htmlmodule = new HTMLModule();

    protected void Page_Load(object sender, EventArgs e)
    {
        string path = HttpContext.Current.Request.ApplicationPath;
        TextEditor.scriptPath = path + "/Editor/scripts";
        SaveButton.Attributes.Add("onClick", "getSearchHtml();");        
        updateViews();
     
    }

    private void updateViews()
    {
        HTMLModule htmlmodule = HTMLModuleData.LoadHTMLModuleData(this._moduleid);
        if (ViewMode == ViewMode.Edit)
        {
            ControlMultiView.SetActiveView(EditView);
            TextEditor.Text = htmlmodule.HtmlText;
        }
        else
        {
            ControlMultiView.SetActiveView(ReadView);            
            HtmlContent.Text = htmlmodule.HtmlText;
            DateLiteral.Text = "Created on: " + htmlmodule.CreatedDate.ToShortDateString() + " by " + htmlmodule.CreatedByUser;
        }
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        htmlmodule.ModuleId = this.ModuleId;
        htmlmodule.HtmlText = TextEditor.Text;
        htmlmodule.SearchText = searchtext.Value;
        htmlmodule.CreatedDate = DateTime.Now;
        HTMLModuleData.UpdateHTMLModule(htmlmodule);
        Response.Redirect(Request.RawUrl);

    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        ViewMode = ViewMode.ReadOnly;
    }
}
