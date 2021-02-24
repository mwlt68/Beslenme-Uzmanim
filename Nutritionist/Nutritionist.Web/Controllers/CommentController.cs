using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nutritionist.Web.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
