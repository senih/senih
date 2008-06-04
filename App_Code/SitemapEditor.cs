using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Text;


namespace MyWebSite
{

    public class SitemapEditor
    {
        private XmlDocument _sitemap;
        private XmlNamespaceManager _nsManager;
        
        public SitemapEditor()
        {

                if (File.Exists(HttpContext.Current.Server.MapPath("~/Web.sitemap")))
                {
                    _sitemap = new XmlDocument();
                    _sitemap.Load(HttpContext.Current.Server.MapPath("~/Web.sitemap"));
                }
                else
                {
                    _sitemap = CreateSitemap();
                }


            _nsManager = new XmlNamespaceManager(_sitemap.NameTable);
            _nsManager.AddNamespace("sm", _sitemap.DocumentElement.NamespaceURI);
        }

        public void InsertPage(WebPage page)
        {
            XmlNode node = _sitemap.CreateNode(XmlNodeType.Element, "siteMapNode", _sitemap.DocumentElement.NamespaceURI);
            XmlAttribute title = _sitemap.CreateAttribute("title");
            title.Value = page.NavigationName;            
            node.Attributes.Append(title);

            XmlAttribute url = _sitemap.CreateAttribute("url");
            if (page.VirtualPath != string.Empty)
                url.Value = page.VirtualPath.ToLower();
            else
                url.Value = string.Format("~/default{0}.aspx", page.PageId);
            node.Attributes.Append(url);

            XmlAttribute pageId = _sitemap.CreateAttribute("pageId");
            pageId.Value = page.PageId.ToString();
            node.Attributes.Append(pageId);

            XmlAttribute visible = _sitemap.CreateAttribute("visible");
            visible.Value = page.Visible.ToString();
            node.Attributes.Append(visible);

            
            //if (previousPageId != string.Empty )
            //{
            //    XmlNode previousNode = _sitemap.DocumentElement.SelectSingleNode(string.Format("//sm:siteMapNode[@pageId='{0}']", previousPageId), _nsManager);
            //    if (previousNode != null)
            //    {
            //        previousNode.ParentNode.InsertAfter(node, previousNode);
            //    }
            //}
            //else
            //{
            //    _sitemap.DocumentElement.FirstChild.AppendChild(node);
            //}
            _sitemap.DocumentElement.FirstChild.AppendChild(node);
           
        }

        public void UpdatePage(WebPage page)
        {
            XmlNode node = _sitemap.SelectSingleNode(string.Format("//sm:siteMapNode[@pageId='{0}']", page.PageId), _nsManager);
            if (node != null)
            {
                if (node.Attributes["title"] == null)
                    node.Attributes.Append(_sitemap.CreateAttribute("title"));
                    node.Attributes["title"].Value = page.NavigationName;

                if (node.Attributes["url"] == null)
                    node.Attributes.Append(_sitemap.CreateAttribute("url"));
                if (page.VirtualPath != string.Empty)
                    node.Attributes["url"].Value = page.VirtualPath.ToLower();
                else
                    node.Attributes["url"].Value = string.Format("~/default{0}.aspx", page.PageId);
                
                if (node.Attributes["visible"] == null)
                    node.Attributes.Append(_sitemap.CreateAttribute("visible"));
                node.Attributes["visible"].Value = page.Visible.ToString();
            }
        }


        public void DeletePage(string pageId)
        {
            XmlNode node = _sitemap.SelectSingleNode(string.Format("//sm:siteMapNode[@pageId='{0}']", pageId), _nsManager);
            node.ParentNode.RemoveChild(node);
        }


        public void MoveDown(string pageId)
        {
            XmlNode node = _sitemap.SelectSingleNode(string.Format("//sm:siteMapNode[@pageId='{0}']", pageId), _nsManager);
            if ((node != null) && (node.NextSibling != null))
            {
                node.ParentNode.InsertAfter(node, node.NextSibling);

            }
        }

        public void MoveUp(string pageId)
        {
            XmlNode node = _sitemap.SelectSingleNode(string.Format("//sm:siteMapNode[@pageId='{0}']", pageId), _nsManager);
            if ((node != null) && (node.PreviousSibling != null) && (node.PreviousSibling.Attributes["pageId"] != null))
            {
                node.ParentNode.InsertBefore(node, node.PreviousSibling);
            }
        }

        public void MoveLevelDown(string pageId)
        {
            XmlNode node = _sitemap.SelectSingleNode(string.Format("//sm:siteMapNode[@pageId='{0}']", pageId), _nsManager);
            if ((node != null) && (node.ParentNode != null) &&
                (node.ParentNode.Name == "siteMapNode") &&
                (node.PreviousSibling != null) &&
                (node.PreviousSibling.Attributes["pageId"] != null))
            {
                node.PreviousSibling.AppendChild(node);
            }
        }

        public void MoveLevelUp(string pageId)
        {
            XmlNode node = _sitemap.SelectSingleNode(string.Format("//sm:siteMapNode[@pageId='{0}']", pageId), _nsManager);
            if ((node != null) && (node.ParentNode != null) &&
                (node.ParentNode.ParentNode != null) &&
                (node.ParentNode.ParentNode.Name == "siteMapNode"))
            {
                node.ParentNode.ParentNode.InsertAfter(node, node.ParentNode);
            }
        }

        private XmlDocument CreateSitemap()
        {
            XmlDocument sitemap = new XmlDocument();
            StringBuilder node = new StringBuilder();

            node.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");           
            node.Append("<siteMap xmlns=\"http://schemas.microsoft.com/AspNet/SiteMap-File-1.0\">");
            node.Append("<siteMapNode>");
            //node.Append("   <siteMapNode>");
            //node.Append("       <siteMapNode url=\"~/Administration/Default.aspx\" title=\"Administration\"  />");
            //node.Append("       <siteMapNode url=\"~/Administration/Users.aspx\" title=\"User Managment\" />");
            //node.Append("       <siteMapNode url=\"~/Administration/WebSite.aspx\" title=\"CMS Setup\" />");
            //node.Append("       <siteMapNode url=\"~/Administration/Section.aspx\" title=\"Sections\" />");
            //node.Append("   </siteMapNode>");           
            node.Append("   <siteMapNode url=\"~/default.aspx\" title=\"Home\" pageId=\"1\" visible=\"True\" />");           
            node.Append("</siteMapNode>");
            node.Append("</siteMap>");

            sitemap.LoadXml(node.ToString());
            return sitemap;
        }

        public void Save()
        {
            _sitemap.Save(HttpContext.Current.Server.MapPath("~/Web.sitemap"));
        }
        
    }
}
