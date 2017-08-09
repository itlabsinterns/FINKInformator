using System.Web;
using System.Web.Mvc;

namespace ItLabs.FinkInformator.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
