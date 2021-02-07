using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Services;

namespace Nutritionist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        ArticleService articleService;
        public ArticleController()
        {
            articleService = new ArticleService();
        }
    }
}
