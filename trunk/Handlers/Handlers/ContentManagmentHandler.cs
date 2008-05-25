using System.Web;
using System.Web.UI;

namespace Handlers
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
