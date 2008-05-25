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
    public class ModuleControlBaseClass : UserControl
    {
        protected int _moduleid;

        public int ModuleId
        {
            get { return _moduleid; }
            set { _moduleid = value; }
        }

        public ViewMode ViewMode
        {
            get
            {
                object o = ViewState["ViewMode"];
                if (o != null)
                    return (ViewMode)o;
                else
                    return ViewMode.ReadOnly;
            }
            set
            {
                ViewState["ViewMode"] = value;
            }
        }

        public ModuleControlBaseClass()
        {
        }

        public ModuleControlBaseClass(int moduleid)
        {
            ModuleId = moduleid;
        }

    }
}
