using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Core.ActionFilters;
using Nutritionist.Services;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
namespace Nutritionist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionistController : ControllerBase
    {
        NutritionistService nutritionistService = new NutritionistService();


        [ValidateModelState]
        [HttpPost("NutRegister")]
        public bool PostRegister([FromForm] NutritionistInsertModel nutritionistInsertModel)
        {
            try
            {
                var result = nutritionistService.NutritionistRegister(nutritionistInsertModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
