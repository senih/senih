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
using MyWebSite.Modules;

public partial class Modules_ModuleAdmin : ModuleControlBaseClass
{
    public event EventHandler Edit;
    public event EventHandler DeleteModule;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void EditButton_Click(object sender, EventArgs e)
    {
        if (EditButton.Text == "Edit Module")
        {
            ViewMode = MyWebSite.ViewMode.Edit;
            EditButton.Text = "View Mode";
        }
        else
        {
            ViewMode = MyWebSite.ViewMode.ReadOnly;
            EditButton.Text = "Edit Module";
        }
        if (Edit != null)
            Edit(this, new EventArgs());
    }


    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        if (DeleteModule != null)
            DeleteModule(this, new EventArgs());
    }
}
