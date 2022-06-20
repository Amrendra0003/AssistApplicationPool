using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Healthware.Core.DTO;
using Healthware.Core.Utility.Routes;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Healthware.Core.Utility
{
    public class UrlBuilder : IUrlBuilder
    {
        private readonly IUrlBuilderHelper _urlBuilderHelper;
        public UrlHelper UrlHelper { get; set; }


        public UrlBuilder(IUrlBuilderHelper urlBuilderHelper)
        {
            _urlBuilderHelper = urlBuilderHelper;
        }

        public Link ToCurrentUrlWithQueryString(object queryStringObject, string rel)
        {
            var requestUri = UrlHelper.ActionContext.HttpContext.Request;
            string url = requestUri.Scheme + "://" + requestUri.Host + requestUri.Path;
            var queryStringNameValues = HttpUtility.ParseQueryString(requestUri.QueryString.ToString());
            return ToCurrentUrlWithQueryString(url, queryStringNameValues, queryStringObject, rel);
        }

        public Link ToGetSingleItemFor(string urlLocationToAppendToApi, long id,string rel)
        {
            var requestUri = UrlHelper.ActionContext.HttpContext.Request;
            var url = string.Format("{0}://{1}/{2}/{3}",requestUri.Scheme,requestUri.Host,urlLocationToAppendToApi,id);
            return new Link{href = url,method = "GET",rel = rel};
        }

        public Link ToRouteAppendUrl(string routePrefix, string Route, object routeValues, string rel, string method)
        {
            var urlRoot = _urlBuilderHelper.GetUrlRoot(UrlHelper);

            IDictionary<string,string> routeValueCollection = GetKeyValueCollectionFor(routeValues);

            foreach (var routeKeyValue in routeValueCollection)
            {
                Route = Regex.Replace(Route,@"{"+routeKeyValue.Key+@"(:)?\w*}" ,routeKeyValue.Value );
            }

            string url = string.Format("{0}/{1}/{2}", urlRoot,routePrefix,Route);

            return new Link
            {
                href = url,
                rel = rel,
                method = method
            };
        }

        public Link ToRoute(string routeName, object routeValues,string rel,string method)
        {
            var url = UrlHelper.Link(routeName, routeValues);
            return new Link
            {
                href = url,
                rel = rel,
                method = method
            };
        }

        private IDictionary<string, string> GetKeyValueCollectionFor(object routeValueObject)
        {
            var propertyInfos = routeValueObject.GetType().GetProperties();

            var result = new Dictionary<string, string>();

            propertyInfos.Each(prop =>
            {
                var value = prop.GetValue(routeValueObject).ToString();
                result.Add(prop.Name,value);
            });

            return result;
        }

        public Link ToCurrentUrlWithQueryString(string url, NameValueCollection queryStringNameValues, object queryStringObject, string rel)
        {
            var queryString = GetQueryStringFrom(queryStringObject, queryStringNameValues);

            if (!String.IsNullOrWhiteSpace(queryString))
                url = string.Format("{0}?{1}", url, queryString);

            return new Link { href = url, method = "GET", rel = rel };
        }

        private string GetQueryStringFrom(object queryStringObject,NameValueCollection queryStringNameValues)
        {
            var propertyInfos = queryStringObject.GetType().GetProperties();

            propertyInfos.Each(prop =>
            {
                var value = prop.GetValue(queryStringObject).ToString();

                if (queryStringNameValues.AllKeys.Any(y => y.Equals(prop.Name)))
                    queryStringNameValues[prop.Name] = value;
                else
                    queryStringNameValues.Add(prop.Name, value);
            });

            var quertyString = String.Join("&", queryStringNameValues.AllKeys.Select(x => string.Format("{0}={1}", x, queryStringNameValues[x])));

            return quertyString;
        }
    }
}