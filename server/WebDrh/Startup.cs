using System.Diagnostics;
using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using WebDrh;

[assembly: OwinStartup(typeof(Startup))]

namespace WebDrh
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
#if DEBUG
            json.SerializerSettings.Formatting = Formatting.Indented;
#else
            json.SerializerSettings.Formatting = Formatting.None;
#endif
            // on renvoit le json en camelCase
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // on fait gaffe aux problèmes de références circulaires
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
        }
    }
}