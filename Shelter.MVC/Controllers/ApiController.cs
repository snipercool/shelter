using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Shelter.MVC.Controllers
{
[Route("api")]
public class ApiController : Controller
{
    [HttpGet]
    [Route("private")]
    [Authorize]
    public IActionResult Private()
    {
        return Json(new
        {
            Message = "Hello from a private endpoint! You need to be authenticated to see this."
        });
    }

    [HttpGet]
    [Route("private-scoped")]
    [Authorize("read:animals")]
    public IActionResult Scoped()
    {
        return Json(new
        {
            Message = "Hello from a private endpoint! You need to be authenticated and have a scope of read:messages to see this."
        });
    }
}
}