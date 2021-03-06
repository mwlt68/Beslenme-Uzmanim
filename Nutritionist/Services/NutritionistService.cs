using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
using NutritionistUpdateModel = Nutritionist.Core.Models.Nutritionist.Update;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using NutritionistEntity = Nutritionist.Data.Entities.Nutritionist;
using UserEntity = Nutritionist.Data.Entities.User;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserListModel = Nutritionist.Core.Models.User.List;
using Nutritionist.Core.Helper;

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
        public int CheckNutritionistFromUserId(int userId)
        {
            var nutritionist = nutritionistRepository.GetNutritionistFromUserId(userId);
            if (nutritionist != null)
            {
                return nutritionist.Id;
            }
            return -1;
        }
        public NutritionistDetailModel GetNutritionistDetailModel(int  nutritionistId)
        {
            var nutritionist=nutritionistRepository.GetById(nutritionistId);
            var nutritionistDetailModel = mapper.Map<NutritionistEntity, NutritionistDetailModel>(nutritionist);
            return nutritionistDetailModel;
        }
        public bool EditNutritionist(NutritionistUpdateModel nutritionistUpdateModel)
        {
            var nutritionist = nutritionistRepository.GetById(nutritionistUpdateModel.Id);
            if (nutritionistUpdateModel != null && nutritionist != null)
            {
                nutritionist.Address = nutritionistUpdateModel.Address;
                nutritionist.Departman = nutritionistUpdateModel.Departman;
                nutritionist.FacebookLink = nutritionistUpdateModel.FacebookLink;
                nutritionist.InstagramLink = nutritionistUpdateModel.InstagramLink;
                nutritionist.YoutubeLink = nutritionistUpdateModel.YoutubeLink;
                nutritionist.LinkedinLink = nutritionistUpdateModel.LinkedinLink;
                nutritionist.PhoneNumber = nutritionistUpdateModel.PhoneNumber;
                nutritionist.ShortIntroduce = nutritionistUpdateModel.ShortIntroduce;
                nutritionist.Introduce = nutritionistUpdateModel.Introduce;
                nutritionist.WorkingHours = nutritionistUpdateModel.WorkingHours;
                nutritionist.ProfileImage = StaticFunctions.GetBytesFromFile(nutritionistUpdateModel.ProfileImage);
                nutritionistRepository.Update(nutritionist);
                return true;
            }
            else return false;
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
