using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutritionist.Core.Models.ResponseModels;
using Nutritionist.Services;
using CommentListModel = Nutritionist.Core.Models.Comment.List;
using CommentInsertModel = Nutritionist.Core.Models.Comment.Insert;

namespace Nutritionist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentService commentService;
        public CommentController()
        {
           commentService = new CommentService();
        }

        [HttpPost("AddComment")]
        public ActionResult<BaseResponseModel> AddComment([FromBody] CommentInsertModel commentInsertModel)
        {
            try
            {
                commentService.AddComment(commentInsertModel);
                return Ok(new SuccessResponseModel<bool>(true));
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
        [HttpGet("GetComments")]
        public ActionResult<BaseResponseModel> GetComments(int nutritionistId)
        {
            try
            {
                List<CommentListModel> lists= commentService.GetNutritionistAllCommentLists(nutritionistId);
                return Ok(new SuccessResponseModel<List<CommentListModel>>(lists));
            }
            catch (Exception ex)
            {

                return new BaseResponseModel(ex.Message);
            }
        }
    }
}
