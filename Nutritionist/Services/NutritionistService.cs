using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using NutritionistEntity = Nutritionist.Data.Entities.Nutritionist;

namespace Nutritionist.Services
{
    public class NutritionistService : BaseServices
    {
        private NutritionistRepository nutritionistRepository = new NutritionistRepository();
        private UserService userService = new UserService();
        private CommentService commentService = new CommentService();
        private ArticleService articleService = new ArticleService();

        public bool NutritionistRegister(NutritionistInsertModel nutritionistInsertModel)
        {
            var nutritionist = mapper.Map<NutritionistInsertModel, NutritionistEntity>(nutritionistInsertModel);
            nutritionistRepository.Add(nutritionist);
            return true;
        }
        public NutritionistDetailModel GetNutritionistDetailModel(int  nutritionistId)
        {
            var nutritionist=nutritionistRepository.GetById(nutritionistId);
            var nutritionistDetailModel = mapper.Map<Data.Entities.Nutritionist,NutritionistDetailModel>(nutritionist);
            var userDetailModel = userService.GetUserDetailModel(nutritionistDetailModel.UserId); 
            if (userDetailModel != null)
            {
                nutritionistDetailModel.User = userDetailModel;
            }
            return nutritionistDetailModel;
        }
        public NutritionistListModel GetNutritionistListModel(int nutritionistId)
        {
            var nutritionist = nutritionistRepository.GetById(nutritionistId);
            NutritionistListModel nutritionistListModel = null;
            if (nutritionist != null)
            {
                nutritionistListModel = mapper.Map<Data.Entities.Nutritionist, NutritionistListModel>(nutritionist);
                var userListModel = userService.GetUserListModel(nutritionistListModel.UserId);
                if (userListModel != null)
                {
                    nutritionistListModel.User = userListModel;
                }
            }

            return nutritionistListModel;
        }
        public IEnumerable<NutritionistListModel> GetNutritionistListModels()
        {
            var nutritionists = nutritionistRepository.GetAll();
            var nutritionistListModels = mapper.Map<IEnumerable<NutritionistEntity>, IEnumerable<NutritionistListModel>>(nutritionists);
            foreach (var nutritionistListModel in nutritionistListModels)
            {
                var userListModel = userService.GetUserListModel(nutritionistListModel.UserId);
                if (userListModel != null)
                {
                    nutritionistListModel.User = userListModel;
                }
            }
            return nutritionistListModels;
        }
        public int GetNutritionistCount()
        {
            return nutritionistRepository.GetCount();
        }
        public NutritionistEntity GetNutritionistFromUserId(int userId)
        {
            return nutritionistRepository.GetNutritionistFromUserId(userId);
        }
        public bool RemoveNutritionist(int nutritionistId)
        {
            NutritionistEntity nutritionist = nutritionistRepository.GetById(nutritionistId);
            if (nutritionist != null)
            {
                var comments=commentService.GetNutritionistAllCommentLists(nutritionist.Id);
                if (comments != null)
                {
                    nutritionist.Comments = ArrayMap<Nutritionist.Core.Models.Comment.List,Data.Entities.Comment>(comments);
                }
                var articles = articleService.GetNutritionistArticles(nutritionist.Id);
                if (articles != null)
                {
                    nutritionist.Articles = ArrayMap<Nutritionist.Core.Models.Article.List, Data.Entities.Article>(articles);
                }
                nutritionistRepository.RemoveWithForeignKeys(nutritionist);
                return true;
            }
            else return false;

        }
    }
}
