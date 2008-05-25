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
        
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        updateViews();
    }

    private void updateViews()
    {
        HTMLModule _htmlmodule = HTMLModuleData.LoadHTMLModuleData(this.ModuleId);
        if (ViewMode == ViewMode.Edit)
        {
            ControlMultiView.SetActiveView(EditView);
            TextEditor.Text = _htmlmodule.HtmlText;
        }
        else
        {
            ControlMultiView.SetActiveView(ReadView);
            HtmlContent.Text = _htmlmodule.HtmlText;
        }
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        htmlmodule.ModuleId = this.ModuleId;
        htmlmodule.HtmlText = TextEditor.Text;
        htmlmodule.CreatedDate = DateTime.Now;      

    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        ViewMode = ViewMode.ReadOnly;
    }
}
