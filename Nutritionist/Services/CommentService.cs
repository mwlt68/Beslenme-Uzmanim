using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using CommentListModel = Nutritionist.Core.Models.Comment.List;
using UserListModel = Nutritionist.Core.Models.User.List;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using CommentInsertModel = Nutritionist.Core.Models.Comment.Insert;
using Nutritionist.Data.Entities;
using System.Linq;

namespace Nutritionist.Services
{
    public class CommentService : BaseServices
    {
        private CommentRepository commentRepository = new CommentRepository();
        private UserRepository userRepository = new UserRepository();
        private NutritionistRepository nutritionistRepository = new NutritionistRepository();

        public void AddComment(CommentInsertModel commentInsertModel)
        {
            Comment comment = mapper.Map<CommentInsertModel, Data.Entities.Comment>(commentInsertModel);
            commentRepository.Add(comment);
        }
        public bool RemoveComment(int commentId)
        {
            var comment =  commentRepository.GetById(commentId);
            if (comment != null)
            {
                commentRepository.Remove(comment);
                return true;
            }
            else return false;
        }
        public List<CommentListModel> GetNutritionistAllCommentLists(int nutritionistId)
        {
           
            List<Comment> comments = commentRepository.GetNutritionistAllComments(nutritionistId);
            List<CommentListModel> commentListModels = ArrayMap<Comment, CommentListModel>(comments);
            var result= commentListModels.OrderByDescending(si => si.UpdateDate).ToList(); ;
            return result;
        }
    }
}
