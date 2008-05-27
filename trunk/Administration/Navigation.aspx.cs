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
using MyWebSite;


public partial class Administration_Navigation : PageBaseClass
{
    private SitemapEditor editor = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((User.Identity.IsAuthenticated) && (User.IsInRole("administrators")))
        {
            TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
            HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
            SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
            if (!Page.IsPostBack)
            {
                editor = new SitemapEditor();
                editor.Save();
                pagesTV.DataSource = source;
                pagesTV.DataBind();                
            }
            Table.Visible = false;
        }

    }
    protected void NewPageBtn_Click(object sender, EventArgs e)
    {
        HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
        TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
        SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
        string pageid = WebPageData.NewWebPage();
        WebPage page = WebPageData.LoadPageData(pageid);
        editor = new SitemapEditor();
        editor.InsertPage(page);
        editor.Save();
        WebPageData.UpdateVirtualPath(pageid);
        pagesTV.DataSource = source;
        pagesTV.DataBind();
        Table.Visible = false;
        
        
    }
    protected void DeletePageBtn_Click(object sender, EventArgs e)
    {
        HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
        TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
        SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
        if (pagesTV.SelectedValue != string.Empty)
        {
            string temp = pagesTV.SelectedValue;
            string pageid = WebPageData.GetWebPageId(temp);
            if (pageid != "1")
            {
                WebPageData.DeletePage(pageid);
                editor = new SitemapEditor();
                editor.DeletePage(pageid);
                editor.Save();
                pagesTV.DataSource = source;
                pagesTV.DataBind();
                Table.Visible = false;
            }
        }                
        
    }

    protected void PagesTreeView_SelectedNodeChanged(object sender, EventArgs e)
    {
        HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
        Table.Visible = true;
        TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
        SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
        TextBox TitleTB = (TextBox)LoginView1.FindControl("TitleTextBox");
        TextBox NavigationTB = (TextBox)LoginView1.FindControl("NavigationTextBox");
        TextBox VirtualPathTB = (TextBox)LoginView1.FindControl("VirtualPathTextBox");
        DropDownList AccessRolesDDL = (DropDownList)LoginView1.FindControl("AccessRolesDropDownList");
        DropDownList EditRolesDDL = (DropDownList)LoginView1.FindControl("EditRolesDropDownList");
        CheckBox VisibleCB = (CheckBox)LoginView1.FindControl("VisibleCheckBox");

        string temp = pagesTV.SelectedValue;
        string pageid = WebPageData.GetWebPageId(temp);
        WebPage page = WebPageData.LoadPageData(pageid);

        TitleTB.Text = page.Title;
        NavigationTB.Text = page.NavigationName;
        VirtualPathTB.Text = page.VirtualPath;
        VisibleCB.Checked = page.Visible;
        AccessRolesDDL.DataSource = Roles.GetAllRoles();
        AccessRolesDDL.DataBind();
        AccessRolesDDL.Items.Insert(0, new ListItem("Anonymous", "Anonymous"));
        AccessRolesDDL.SelectedValue = page.AccessRole;
        EditRolesDDL.DataSource = Roles.GetAllRoles();
        EditRolesDDL.DataBind();
        EditRolesDDL.SelectedValue = page.EditRole;

    }
    protected void UpdatePageBtn_Click(object sender, EventArgs e)
    {
        HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
        Table.Visible = true;
        TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
        SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
        TextBox TitleTB = (TextBox)LoginView1.FindControl("TitleTextBox");
        TextBox NavigationTB = (TextBox)LoginView1.FindControl("NavigationTextBox");
        TextBox VirtualPathTB = (TextBox)LoginView1.FindControl("VirtualPathTextBox");
        DropDownList AccessRolesDDL = (DropDownList)LoginView1.FindControl("AccessRolesDropDownList");
        DropDownList EditRolesDDL = (DropDownList)LoginView1.FindControl("EditRolesDropDownList");
        CheckBox VisibleCB = (CheckBox)LoginView1.FindControl("VisibleCheckBox");

        string temp = pagesTV.SelectedValue;
        string pageid = WebPageData.GetWebPageId(temp);
        WebPage page = WebPageData.LoadPageData(pageid);
        
        page.Title = TitleTB.Text;
        
        page.NavigationName = NavigationTB.Text;
        if ((VirtualPathTB.Text != string.Empty) && (WebPageData.IsValidUrl(VirtualPathTB.Text)))
        {            
            page.VirtualPath = VirtualPathTB.Text.ToLower();            
        }
        else
        {
            page.VirtualPath = string.Format("~/default{0}.aspx", pageid);
        }
        page.AccessRole = AccessRolesDDL.SelectedValue;
        page.EditRole = EditRolesDDL.SelectedValue;
        page.Visible = VisibleCB.Checked;

        WebPageData.UpdatePage(page);
        editor = new SitemapEditor();
        editor.UpdatePage(page);
        editor.Save();
        pagesTV.DataSource = source;
        pagesTV.DataBind();        
        Table.Visible = false;
    }


    protected void MoveUpBtn_Click(object sender, ImageClickEventArgs e)
    {
        HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
        TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
        SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
        string temp = pagesTV.SelectedValue;
        string pageid = WebPageData.GetWebPageId(temp);
        editor = new SitemapEditor();
        editor.MoveUp(pageid);
        editor.Save();
        pagesTV.DataSource = source;
        pagesTV.DataBind();
        
    }
    protected void MoveDownBtn_Click(object sender, ImageClickEventArgs e)
    {
        HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
        TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
        SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
        string temp = pagesTV.SelectedValue;
        string pageid = WebPageData.GetWebPageId(temp);
        editor = new SitemapEditor();
        editor.MoveDown(pageid);
        editor.Save();
        pagesTV.DataSource = source;
        pagesTV.DataBind();
        Table.Visible = false;
    }

    protected void MoveLevelUpBtn_Click(object sender, ImageClickEventArgs e)
    {
        HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
        TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
        SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
        string temp = pagesTV.SelectedValue;
        string pageid = WebPageData.GetWebPageId(temp);
        editor = new SitemapEditor();
        editor.MoveLevelUp(pageid);
        editor.Save();
        pagesTV.DataSource = source;
        pagesTV.DataBind();
        Table.Visible = false;
    }


    protected void MoveLevelDownBtn_Click(object sender, ImageClickEventArgs e)
    {
        HtmlTable Table = (HtmlTable)LoginView1.FindControl("PageDetails");
        TreeView pagesTV = (TreeView)LoginView1.FindControl("PagesTreeView");
        SiteMapDataSource source = (SiteMapDataSource)LoginView1.FindControl("SiteMapDataSource1");
        string temp = pagesTV.SelectedValue;
        string pageid = WebPageData.GetWebPageId(temp);
        editor = new SitemapEditor();
        editor.MoveLevelDown(pageid);
        editor.Save();
        pagesTV.DataSource = source;
        pagesTV.DataBind();
        Table.Visible = false;
    }
}
