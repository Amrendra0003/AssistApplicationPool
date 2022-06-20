using Healthware.Core.DTO;

namespace Healthware.Core.Utility.Routes
{
    public interface IUrlBuilder
    {
        Link ToCurrentUrlWithQueryString(object queryString, string rel);
        Link ToGetSingleItemFor(string urlLocationToAppendToApi, long id,string rel);
        Link ToRouteAppendUrl(string routePrefix, string Route, object routeValues, string rel, string method);
        Link ToRoute(string routeName, object routeValues, string rel, string method);
    }
}