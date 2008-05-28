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
using System.IO;

public partial class _Default : PageBaseClass
{
    protected ArrayList modulelist;
    protected string url;
    private WebPage _page;
    private Menu menu = new Menu();
    SiteMapDataSource source = new SiteMapDataSource();

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            if (((User.Identity.IsAuthenticated) && (User.IsInRole(_page.EditRole))) || User.IsInRole("administrators"))
                AddModulePanel.Visible = true;
            else AddModulePanel.Visible = false;            
        }
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {        
      LoadPageContent();
    }
        
    protected void LoadPageContent()
    {
        if (!(File.Exists(HttpContext.Current.Server.MapPath("~/Web.sitemap"))))
        {
            SitemapEditor editor = new SitemapEditor();
            editor.Save();
        }
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
        CenterArea.Controls.Clear();
        RightArea.Controls.Clear();

        LeftArea.Controls.Add(menu);
                
        // Load all modules

        modulelist = ModuleData.GetAllModules(pageid);
        foreach (int moduleid in modulelist)
        {
            Module module = ModuleData.LoadModuleData(moduleid);            
            string filename = ModuleData.GetModuleType(module.ModuleDefinitionId);
            ModuleControlBaseClass control = new ModuleControlBaseClass(module.ModuleId);            
            control = (ModuleControlBaseClass)LoadControl(filename);
            control.ModuleId = module.ModuleId;
            
            if ((User.IsInRole(module.EditRoles)) || User.IsInRole("administrators"))
                control.AdminView = true;
            else control.AdminView = false;

            if (!IsPostBack)
                control.ViewMode = ViewMode.ReadOnly;
                                                
            if (module.PanelName == "CenterArea")
                CenterArea.Controls.Add(control);
            if (module.PanelName == "LeftArea")
                LeftArea.Controls.Add(control);
            if (module.PanelName == "RightArea")
                RightArea.Controls.Add(control);
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
        url = Request.UrlReferrer.ToString();
        module.PageId = _page.PageId;
        module.ModuleDefinitionId = int.Parse(ModuleDropDownList.SelectedItem.Value);        
        module.PanelName = "CenterArea";
        module.ModuleOrder = SetModuleOrder(modulelist);
        Module newmodule = ModuleData.NewModule(module);

        if (module.ModuleTitle == "HTML")
        {
            HTMLModule newhtmlmodule = new HTMLModule();
            newhtmlmodule.CreatedByUser = User.Identity.Name;
            newhtmlmodule.CreatedDate = DateTime.Now;
            newhtmlmodule.ModuleId = module.ModuleId;
            newhtmlmodule = HTMLModuleData.NewHTMLModule(newhtmlmodule);
        }
        Response.Redirect(Request.RawUrl);
    }

    protected int SetModuleOrder(ArrayList list)
    {
        int order = 0;
        foreach (int moduleid in list)
        {
            Module module = ModuleData.LoadModuleData(moduleid);
            order = module.ModuleOrder;
        }
        return order + 1;
    }

    public static void MoveModuleUp(int moduleid)
    {

    }
}
