using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MyWebSite
{

    public class WebSite
    {
        private int _WebSiteId;
        private string _WebSiteTitle;
        private string _Lang;
        private string _MailSenderAddress;
        private string _Theme;
        private string _SmtpServer;
        private string _SmtpUser;
        private string _SmtpPassword;
        private string _SmtpDomain;        
        private string _Keywords;
        private string _Description;
        private string _FooterText;

        public WebSite() : base() { }

        public int WebSiteId
        {
            get { return _WebSiteId; }
            set { _WebSiteId = value; }
        }
          
        public string WebSiteTitle
        {
            get { return _WebSiteTitle; }
            set { _WebSiteTitle = value; }
        }

        public string Lang
        {
            get { return _Lang; }
            set { _Lang = value; }
        }

        public string MailSenderAddress
        {
            get { return _MailSenderAddress; }
            set { _MailSenderAddress = value; }
        }

        public string Theme
        {
            get { return _Theme; }
            set { _Theme = value; }
        }

        public string SmtpServer
        {
            get { return _SmtpServer; }
            set { _SmtpServer = value; }
        }

        public string SmtpUser
        {
            get { return _SmtpUser; }
            set { _SmtpUser = value; }
        }

        public string SmtpPassword
        {
            get { return _SmtpPassword; }
            set { _SmtpPassword = value; }
        }

        public string SmtpDomain
        {
            get { return _SmtpDomain; }
            set { _SmtpDomain = value; }
        }

        public string FooterText
        {
            get { return _FooterText; }
            set { _FooterText = value; }
        }

        public string Keywords
        {
            get { return _Keywords; }
            set { _Keywords = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
  
    }
}