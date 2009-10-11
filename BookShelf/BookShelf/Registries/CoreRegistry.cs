using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using StructureMap.Configuration.DSL;

namespace BookShelf.Registries
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.AddAllTypesOf(typeof(IController));
                         x.WithDefaultConventions();
                     });
                
            // TODO: whire it togeter
        }
    }
}
