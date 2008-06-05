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
using System.IO;
using MyWebSite;

public partial class Administration_WebSite : PageBaseClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!IsPostBack) && (User.Identity.IsAuthenticated) && (User.IsInRole("administrators")))
        {
            //TODO Language ne e definirano
            TextBox SmtpServerTB = (TextBox)LoginView1.FindControl("SmtpServerTextBox");
            TextBox SmtpUserTB = (TextBox)LoginView1.FindControl("SmtpUserTextBox");
            TextBox SmtpPasswordTB = (TextBox)LoginView1.FindControl("SmtpPasswordTextBox");
            TextBox SmtpDomainTB = (TextBox)LoginView1.FindControl("SmtpDomainTextBox");
            TextBox MailSenderTB = (TextBox)LoginView1.FindControl("MailSenderAddressTextBox");
            TextBox FooterTB = (TextBox)LoginView1.FindControl("FooterTextBox");
            TextBox WebSiteTitleTB = (TextBox)LoginView1.FindControl("WebSiteTitleTextBox");
            TextBox KeywordsTB = (TextBox)LoginView1.FindControl("KeywordsTextBox");
            TextBox DescriptionTB = (TextBox)LoginView1.FindControl("DescriptionTextBox");
            DropDownList ThemeDDL = (DropDownList)LoginView1.FindControl("ThemeDropDownList");
            website = new WebSite();
            website = SiteDataManage.LoadData();

            SmtpServerTB.Text = website.SmtpServer;
            SmtpUserTB.Text = website.SmtpUser;
            SmtpPasswordTB.Text = website.SmtpPassword;
            SmtpDomainTB.Text = website.SmtpDomain;
            MailSenderTB.Text = website.MailSenderAddress;
            FooterTB.Text = website.FooterText;
            WebSiteTitleTB.Text = website.WebSiteTitle;
            KeywordsTB.Text = website.Keywords;
            DescriptionTB.Text = website.Description;
            ThemeDDL.Text = website.Theme;
        }


    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        //TODO Language ne e definirano
        TextBox SmtpServerTB = (TextBox)LoginView1.FindControl("SmtpServerTextBox");
        TextBox SmtpUserTB = (TextBox)LoginView1.FindControl("SmtpUserTextBox");
        TextBox SmtpPasswordTB = (TextBox)LoginView1.FindControl("SmtpPasswordTextBox");
        TextBox SmtpDomainTB = (TextBox)LoginView1.FindControl("SmtpDomainTextBox");
        TextBox MailSenderTB = (TextBox)LoginView1.FindControl("MailSenderAddressTextBox");
        TextBox FooterTB = (TextBox)LoginView1.FindControl("FooterTextBox");
        TextBox WebSiteTitleTB = (TextBox)LoginView1.FindControl("WebSiteTitleTextBox");
        TextBox KeywordsTB = (TextBox)LoginView1.FindControl("KeywordsTextBox");
        TextBox DescriptionTB = (TextBox)LoginView1.FindControl("DescriptionTextBox");
        DropDownList ThemeDDL = (DropDownList)LoginView1.FindControl("ThemeDropDownList");


        website = new WebSite();
        website.Theme = "";
        website.Lang = "";
        website.SmtpServer = SmtpServerTB.Text;
        website.SmtpUser = SmtpUserTB.Text;
        website.SmtpPassword = SmtpPasswordTB.Text;
        website.SmtpDomain = SmtpDomainTB.Text;
        website.MailSenderAddress = MailSenderTB.Text;
        website.FooterText = FooterTB.Text;
        website.WebSiteTitle = WebSiteTitleTB.Text;
        website.Keywords = KeywordsTB.Text;
        website.Description = DescriptionTB.Text;
        website.Theme = ThemeDDL.SelectedValue;

        SiteDataManage.SaveData(website);
        Response.Redirect(Request.RawUrl);

    }
    protected void ResetButton_Click(object sender, EventArgs e)
    {
        SiteDataManage.DeleteData();
        File.Delete(HttpContext.Current.Server.MapPath("~/Web.sitemap"));
        MembershipUserCollection collection = new MembershipUserCollection();
        collection = Membership.GetAllUsers();
        foreach (MembershipUser user in collection)
        {
            Membership.DeleteUser(user.ToString());
        }
        FormsAuthentication.SignOut();
        Membership.CreateUser("admin", "admin", "admin@mywebsite.com");
        MembershipUser admin = Membership.GetUser("admin");
        admin.IsApproved = true;
        if (!Roles.IsUserInRole("admin", "administrators"))
        {
            Roles.AddUserToRole("admin", "administrators");
        }
        Membership.UpdateUser(admin);
        Response.Redirect("~/default.aspx");
    }
}
