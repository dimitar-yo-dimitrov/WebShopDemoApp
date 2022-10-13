using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static WebShop.Core.Data.GlobalConstants.ValidationConstants.ClaimsConstants;

namespace WebShop.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public string UserFirstName
        {
            get
            {
                string firstName = string.Empty;

                if (User.Identity?.IsAuthenticated ?? false)
                {
                    firstName = User.Claims
                        .FirstOrDefault(c => c.Type == FirstName)
                        ?.Value ?? firstName;
                }

                return firstName;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                ViewBag.UserFirstName = UserFirstName;
            }

            base.OnActionExecuted(context);
        }
    }
}
