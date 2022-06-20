using HealthWare.ActiveASSIST.Web.Authorization;
using Healthware.Core.Attributes;
using Healthware.Core.Web.Web.Logging;
using Microsoft.AspNetCore.Mvc;

namespace HealthWare.ActiveASSIST.Web.Controllers
{
    [ApiController, ApiExceptionsHandlerFilter, HandleAuthorize, Log]
    public class BaseApiController : ControllerBase
    {

    }
}