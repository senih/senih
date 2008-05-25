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
    public class Module
    {
        private int _moduleId;
        private string _moduleTitle;
        private string _editRoles;
        private int _pageId;
        private int _moduleDefinitionId;
        private string _panelName;
        private int _moduleOrder;

        public int ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }

        public string ModuleTitle
        {
            get { return _moduleTitle; }
            set { _moduleTitle = value; }
        }

        public string EditRoles
        {
            get { return _editRoles; }
            set { _editRoles = value; }
        }

        public int PageId
        {
            get { return _pageId; }
            set { _pageId = value; }
        }

        public int ModuleDefinitionId
        {
            get { return _moduleDefinitionId; }
            set { _moduleDefinitionId = value; }
        }

        public string PanelName
        {
            get { return _panelName; }
            set { _panelName = value; }
        }

        public int ModuleOrder
        {
            get { return _moduleOrder; }
            set { _moduleOrder = value; }
        }

        public Module() { }

    }
}
