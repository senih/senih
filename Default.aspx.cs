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

public partial class _Default : PageBaseClass
{
    private WebPage _page;
    private Menu menu = new Menu();
    SiteMapDataSource source = new SiteMapDataSource();

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            if (User.IsInRole("administrators"))
                AddModulePanel.Visible = true;
            else AddModulePanel.Visible = false;
            LeftArea.Controls.Add(menu);
        }

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        menu.DataSource = source;
        menu.DataBind();        
        string temp = Context.Items["VirtualPage"].ToString();
        string pageid = WebPageData.GetWebPageId(temp);
        _page = WebPageData.LoadPageData(pageid);

        if (_page.Title.Trim() != string.Empty)
            Title = _page.Title;
        else
            Title = website.WebSiteTitle;

        LeftArea.Controls.Clear();
        CentreArea.Controls.Clear();
        RightArea.Controls.Clear();
                
        // Load all modules

        ArrayList modulelist = ModuleData.GetAllModules(pageid);
        foreach (int moduleid in modulelist)
        {
            Module module = ModuleData.LoadModuleData(moduleid);            
            string filename = ModuleData.GetModuleType(module.ModuleDefinitionId);
            ModuleControlBaseClass control = new ModuleControlBaseClass(module.ModuleId);
            control.LoadControl(filename);

            ContentPlaceHolder panel = (ContentPlaceHolder)Page.FindControl(module.PanelName);
            panel.Controls.Add(control);
        }

        HtmlMeta keywords = new HtmlMeta();
        keywords.Attributes.Add("name", "keywords");
        keywords.Attributes.Add("content", website.Keywords);
        Header.Controls.Add(keywords);

        HtmlMeta description = new HtmlMeta();
        description.Attributes.Add("name", "description");
        description.Attributes.Add("content", website.Description);
        Header.Controls.Add(description);


    }

    protected void AddModuleButton_Click(object sender, EventArgs e)
    {
        Module module = new Module();
        module.ModuleTitle = ModuleDropDownList.SelectedItem.Text;
        module.EditRoles = "users";
        module.PageId = _page.PageId;
        module.ModuleDefinitionId = int.Parse(ModuleDropDownList.SelectedItem.Value);        
        module.PanelName = "CentreArea";
        module.ModuleOrder = CentreArea.Controls.Count + 1;
        Module newmodule = ModuleData.NewModule(module);
                
    }
}
