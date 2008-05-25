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

public partial class Administration_Sections : PageBaseClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
 
    }

    protected void AddNewModuleTypeButton_Click(object sender, EventArgs e)
    {
        TextBox ModuleNameTB = (TextBox)LoginView1.FindControl("ModuleNameTextBox");
        TextBox FileNameTB = (TextBox)LoginView1.FindControl("FileNameTextBox");
        CheckBox VisibleCB = (CheckBox)LoginView1.FindControl("VisibleCheckBox");

        string name = ModuleNameTB.Text;
        string file = FileNameTB.Text;
        bool visible = VisibleCB.Checked;

        ModuleDefinition.NewModuleType(name, file, visible);
    }
}
