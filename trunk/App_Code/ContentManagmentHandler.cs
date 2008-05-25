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
    public class ContentManagmentHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        
        private string GetVirtualPage(HttpContext context)
        {
            return context.Request.Path.Replace(context.Request.ApplicationPath, "");
        }

        public void ProcessRequest(HttpContext context)
        {            
            context.Items.Add("VirtualPage", GetVirtualPage(context));
            IHttpHandler FrontController = PageParser.GetCompiledPageInstance("~/default.aspx", null, context);
            context.RewritePath("default.aspx");
            FrontController.ProcessRequest(context);
        }

    }
}
