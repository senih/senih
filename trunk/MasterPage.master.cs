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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected WebSite _website = SiteDataManage.LoadData();

    protected void Page_Load(object sender, EventArgs e)
    {
        WebSiteTitleLabel.Text = _website.WebSiteTitle;
        FooterLabel.Text = _website.FooterText;
    }
}