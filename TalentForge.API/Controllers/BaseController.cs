using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TalentForge.API.Controllers
{
    public class BaseController : Controller
    {
        [NonAction]
        public string GetCurrentUserId()
        {
            return User.FindFirstValue("uid");

        }
    }
}
