using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using CommentListModel = Nutritionist.Core.Models.Comment.List;
using CommentInsertModel = Nutritionist.Core.Models.Comment.Insert;
using Nutritionist.Data.Entities;

namespace Nutritionist.Services
{
    public class CommentService : BaseServices
    {
        private CommentRepository commentRepository = new CommentRepository();
        private UserService userService = new UserService();

        public void AddComment(CommentInsertModel commentInsertModel)
        {
            Comment comment = mapper.Map<CommentInsertModel, Data.Entities.Comment>(commentInsertModel);
            commentRepository.Add(comment);
        }
        public List<CommentListModel> GetNutritionistAllCommentLists(int nutritionistId)
        {
            List<Comment> comments = commentRepository.GetNutritionistAllComments(nutritionistId);
            List<CommentListModel> commentListModels = ArrayMap<Comment, CommentListModel>(comments);
            foreach (var commentListModel in commentListModels)
            {
                var userListModel = userService.GetUserListModel(commentListModel.UserId);
                if (userListModel != null)
                {
                    commentListModel.User = userListModel;
                }
            }
            return commentListModels;
        }
    }
}
