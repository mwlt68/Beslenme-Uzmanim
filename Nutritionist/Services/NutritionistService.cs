using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserListModel = Nutritionist.Core.Models.User.List;
using NutritionistEntity = Nutritionist.Data.Entities.Nutritionist;

namespace Nutritionist.Services
{
    public class NutritionistService : BaseServices
    {
        private NutritionistRepository nutritionistRepository = new NutritionistRepository();
        private UserService userService = new UserService();

        public bool NutritionistRegister(NutritionistInsertModel nutritionistInsertModel)
        {
            var nutritionist = mapper.Map<NutritionistInsertModel, Data.Entities.Nutritionist>(nutritionistInsertModel);
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
            var nutritionistListModel = mapper.Map<Data.Entities.Nutritionist, NutritionistListModel>(nutritionist);
            var userListModel = userService.GetUserListModel(nutritionistListModel.UserId);
            if (userListModel != null)
            {
                nutritionistListModel.User = userListModel;
            }
            return nutritionistListModel;
        }
        public IEnumerable<NutritionistListModel> GetNutritionistListModels()
        {
            var nutritionists = nutritionistRepository.GetAll();
            var nutritionistListModels = mapper.Map<IEnumerable<NutritionistEntity>, IEnumerable<NutritionistListModel>  >(nutritionists);
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
    }
}
