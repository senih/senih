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
            //TODO Language i Theme ne se definirani
            TextBox SmtpServerTB = (TextBox)LoginView1.FindControl("SmtpServerTextBox");
            TextBox SmtpUserTB = (TextBox)LoginView1.FindControl("SmtpUserTextBox");
            TextBox SmtpPasswordTB = (TextBox)LoginView1.FindControl("SmtpPasswordTextBox");
            TextBox SmtpDomainTB = (TextBox)LoginView1.FindControl("SmtpDomainTextBox");
            TextBox MailSenderTB = (TextBox)LoginView1.FindControl("MailSenderAddressTextBox");
            TextBox FooterTB = (TextBox)LoginView1.FindControl("FooterTextBox");
            TextBox WebSiteTitleTB = (TextBox)LoginView1.FindControl("WebSiteTitleTextBox");
            TextBox KeywordsTB = (TextBox)LoginView1.FindControl("KeywordsTextBox");
            TextBox DescriptionTB = (TextBox)LoginView1.FindControl("DescriptionTextBox");
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
        }


    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        //TODO Language i Theme ne se definirani
        TextBox SmtpServerTB = (TextBox)LoginView1.FindControl("SmtpServerTextBox");
        TextBox SmtpUserTB = (TextBox)LoginView1.FindControl("SmtpUserTextBox");
        TextBox SmtpPasswordTB = (TextBox)LoginView1.FindControl("SmtpPasswordTextBox");
        TextBox SmtpDomainTB = (TextBox)LoginView1.FindControl("SmtpDomainTextBox");
        TextBox MailSenderTB = (TextBox)LoginView1.FindControl("MailSenderAddressTextBox");
        TextBox FooterTB = (TextBox)LoginView1.FindControl("FooterTextBox");
        TextBox WebSiteTitleTB = (TextBox)LoginView1.FindControl("WebSiteTitleTextBox");
        TextBox KeywordsTB = (TextBox)LoginView1.FindControl("KeywordsTextBox");
        TextBox DescriptionTB = (TextBox)LoginView1.FindControl("DescriptionTextBox");


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

        SiteDataManage.SaveData(website);

    }
    protected void ResetButton_Click(object sender, EventArgs e)
    {
        SiteDataManage.DeleteData();
        File.Delete(HttpContext.Current.Server.MapPath("~/Web.sitemap"));
        MembershipUserCollection collection = new MembershipUserCollection();
        collection = Membership.GetAllUsers();
        foreach (MembershipUser user in collection)
        {
            if (user.ToString() != "admin")
            {
                Membership.DeleteUser(user.ToString());
            }
        }
        FormsAuthentication.SignOut();
        MembershipUser admin = Membership.GetUser("admin");
        admin.ResetPassword();
        string password = admin.GetPassword();
        admin.ChangePassword(password, "admin");
        admin.IsApproved = true;
        Membership.UpdateUser(admin);
        Response.Redirect("~/default.aspx");
    }
}