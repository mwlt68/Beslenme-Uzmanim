using AutoMapper;
using Nutritionist.Core.Helper;
using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using UserInsertModel= Nutritionist.Core.Models.User.Insert;
using UserListModel= Nutritionist.Core.Models.User.List;
using UserLoginModel = Nutritionist.Core.Models.User.Login;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserUpdateModel = Nutritionist.Core.Models.User.Update;


namespace Nutritionist.Services
{
    public class UserService:BaseServices
    {
        private UserRepository userRepository = new UserRepository();
        private NutritionistRepository nutritionistRepository = new NutritionistRepository();
        private CommentRepository commentRepository = new CommentRepository();
        private ArticleRepository articleRepository = new ArticleRepository();

        public bool UserRegister(UserInsertModel userInsertModel)
        {
            if (userInsertModel.Password.Equals(userInsertModel.ConfirmPassword))
            {
                var user = mapper.Map<UserInsertModel, Data.Entities.User>(userInsertModel);
                user.Password = MD5Hash.getMd5Hash(user.Password);
                userRepository.Add(user);
                return true;
            }
            else
            {
                return false;
            }

        }
        public UserDetailModel UserLogin(UserLoginModel userLoginModel)
        {
            String hashedPasword= MD5Hash.getMd5Hash(userLoginModel.Password);
            var user = userRepository.UserLogin(userLoginModel.Username,hashedPasword);
            var userDetail= mapper.Map<Data.Entities.User, UserDetailModel>(user);
            return userDetail;
        }
        public UserListModel GetUserListModel(int userId)
        {
            var user = userRepository.GetById(userId);
            var userListModel = mapper.Map<Data.Entities.User, UserListModel>(user);
            return userListModel;
        }
        public UserDetailModel GetUserDetailModel(int userId)
        {
            var user = userRepository.GetById(userId);
            var userDetail = mapper.Map<Data.Entities.User, UserDetailModel>(user);
            return userDetail;
        }
        public int GetUserCount()
        {
            return userRepository.GetUsersCount();
        }
        public bool EditUser(UserUpdateModel userUpdateModel)
        {
            var user =userRepository.GetById(userUpdateModel.Id);
            if (userUpdateModel != null && user != null)
            {
                user.FirstName= userUpdateModel.FirstName;
                user.SecondName= userUpdateModel.SecondName;
                user.Username= userUpdateModel.Username;
                userRepository.Update(user);
                return true;
            }
            else return false;
        }
        public bool RemoveUser(int userId)
        {
            var userEntity=userRepository.GetById(userId);
            if (userEntity != null)
            {
                userRepository.Remove(userEntity);
                return true;
            }
            else return false;
        }
        
    }
}
