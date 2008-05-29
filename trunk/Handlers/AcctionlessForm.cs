using System.Web.UI.HtmlControls;

namespace Handlers
{
    public class ActionlessForm : HtmlForm
    {
        protected override void RenderAttributes(System.Web.UI.HtmlTextWriter writer)
        {
            writer.WriteAttribute("name", this.Name);
            writer.WriteAttribute("method", this.Method);
            Attributes.Render(writer);
        }
    }
}