using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureProject.Controllers
{
    [Authorize]
    public class BaseController:Controller
    {
     
    }
}
