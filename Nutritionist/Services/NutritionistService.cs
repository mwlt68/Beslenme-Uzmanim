using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using NutritionistEntity = Nutritionist.Data.Entities.Nutritionist;
using UserEntity = Nutritionist.Data.Entities.User;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserListModel = Nutritionist.Core.Models.User.List;


namespace Nutritionist.Services
{
    public class NutritionistService : BaseServices
    {
        private NutritionistRepository nutritionistRepository = new NutritionistRepository();
        private UserRepository userRepository = new UserRepository();

        public bool NutritionistRegister(NutritionistInsertModel nutritionistInsertModel)
        {
            var nutritionist = mapper.Map<NutritionistInsertModel, NutritionistEntity>(nutritionistInsertModel);
            nutritionistRepository.Add(nutritionist);
            return true;
        }
       
        public NutritionistDetailModel GetNutritionistDetailModel(int  nutritionistId)
        {
            var nutritionist=nutritionistRepository.GetById(nutritionistId);
            var nutritionistDetailModel = mapper.Map<NutritionistEntity, NutritionistDetailModel>(nutritionist);
            return nutritionistDetailModel;
        }
        public List<NutritionistListModel> GetNutritionistListModels()
        {
            var nutritionists = nutritionistRepository.GetAll();
            var nutritionistListModels = ArrayMap<NutritionistEntity, NutritionistListModel>(nutritionists);
            return nutritionistListModels;
        }
        public int GetNutritionistCount()
        {
            return nutritionistRepository.GetNutritionistsCount();
        }
        public bool RemoveNutritionist(int nutritionistId)
        {
            var nutritionist = nutritionistRepository.GetById(nutritionistId);
            if (nutritionist != null)
            {
                nutritionistRepository.Remove(nutritionist);
                return true;
            }
            return false;
        }
        public NutritionistListModel GetNutritionistListModel(int nutritionistId)
        {
            var nutritionist = nutritionistRepository.GetById(nutritionistId);
            NutritionistListModel nutritionistListModel =mapper.Map<Data.Entities.Nutritionist, NutritionistListModel>(nutritionist);
            return nutritionistListModel;
        }
        public NutritionistListModel GetNutritionistListModelFromUserId(int userId)
        {
            var nutritionist = nutritionistRepository.GetNutritionistFromUserId(userId);
            NutritionistListModel nutritionistListModel = mapper.Map<Data.Entities.Nutritionist, NutritionistListModel>(nutritionist);
            return nutritionistListModel;
        }
        /*


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

       }*/
    }
}
