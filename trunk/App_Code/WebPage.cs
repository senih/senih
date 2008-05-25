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

    public class WebPage
    {
        private int _pageId;
        private string _title;
        private string _navigationName;
        private string _virtualPath;
        private string _accessRole;
        private bool _visible;

        public int PageId
        {
            get { return _pageId; }
            set { _pageId = value; }
        }

        public string NavigationName
        {
            get { return _navigationName; }
            set { _navigationName = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string VirtualPath
        {
            get { return _virtualPath; }
            set { _virtualPath = value; }
        }

        public string AccessRole
        {
            get { return _accessRole; }
            set { _accessRole = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
          
        public WebPage()
        {

        }


    }
}