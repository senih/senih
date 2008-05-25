using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MyWebSite.Modules
{
    public class HTMLModule : Module
    {
        protected int _htmlModuleId;
        protected string _htmlText;
        protected string _searchText;
        protected string _createdByUser;
        protected DateTime _createdDate;
        protected int _moduleId;

        public int HTMLModuleId
        {
            get { return _htmlModuleId; }
            set { _htmlModuleId = value; }
        }

        public int ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }

        public string HtmlText
        {
            get { return _htmlText; }
            set { _htmlText = value; }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }

        public string CreatedByUser
        {
            get { return _createdByUser; }
            set { _createdByUser = value; }
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public HTMLModule()
        {
        }
    }
}