using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Castle.Core;
using Castle.Windsor;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services.Authentication.Validation;
using HealthWare.ActiveASSIST.WebAPI.Controllers;
using Healthware.Core.Common.Session;
using Healthware.Core.Containers;
using Healthware.Core.DTO;
using Healthware.Core.Utility;
using Healthware.Core.Utility.Routes;
using AuthenticationService = HealthWare.ActiveASSIST.Services.AuthenticationService; 

namespace HealthWare.ActiveASSIST.WebAPI.AppStart
{
    public class Ioc
    {
        public static IWindsorContainer WireupApi(DependencyRegistry registry)
        {
            WireUpUiLayer(registry);
            WireUpServiceLayer(registry);
            WireUpEfCoreLayer(registry);
            return registry.GetContainer();
        }

        private static void WireUpUiLayer(DependencyRegistry registry)
        {
            WireupControllers(registry);
            registry.PerWebRequest<IUrlBuilder, UrlBuilder>();
        }

        private static void WireupControllers(DependencyRegistry registry)
        {
            var controllers = typeof(Ioc).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(ApiController)));
            controllers.Each(x => registry.Transient(x.Name, x));
            WireupByInterfaceConvention(typeof(LoginController).Assembly, registry);
        }

        private static void WireUpServiceLayer(DependencyRegistry registry)
        {
            WireupByInterfaceConvention(typeof(SessionService<PatientDbContext>).Assembly, registry);
            WireupByInterfaceConvention(typeof(AuthenticationService).Assembly, registry);
        }

        private static void WireUpEfCoreLayer(DependencyRegistry registry)
        {
            WireupByInterfaceConvention(typeof(UserRepository).Assembly, registry);
        }

        private static void WireupByInterfaceConvention(Assembly assembly, DependencyRegistry registry)
        {
            var allInterfaces = assembly.GetTypes().Where(x => x.IsInterface && x.Name.StartsWith("I"));
            var allTypes = assembly.GetTypes().Where(x => x.IsClass).ToList();
            foreach (var allInterface in allInterfaces)
            {
                var x = allTypes.Where(x => x.Name.Equals(allInterface.Name.Substring(1)));
                if (x.Count() > 1)
                {
                    Console.WriteLine(x);
                }
            }

            var interfaceAndClassList = from theInterface in allInterfaces
                                        let classToLookFor = theInterface.Name.Substring(1)
                                        let theClass = allTypes.SingleOrDefault(x => x.Name.Equals(classToLookFor))
                                        let isPerWebRequest = theInterface.IsDefined(typeof(ScopedAttribute), true)
                                        where theClass != null
                                        select new { theInterface, theClass, isPerWebRequest };

            interfaceAndClassList.Each(x =>
            {
                if (x.isPerWebRequest || x.theClass.Name.Equals("JwtHelper"))
                    registry.PerWebRequest(x.theInterface, x.theClass);
                else
                    registry.Transient(x.theInterface, x.theClass);
            }
            );

            registry.RegisterAllTypesBasedOn(typeof(IValidator<>));
        }
    }
}