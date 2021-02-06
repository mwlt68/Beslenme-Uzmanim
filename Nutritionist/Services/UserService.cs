﻿using AutoMapper;
using Nutritionist.Core.Helper;
using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using UserInsertModel= Nutritionist.Core.Models.User.Insert;
using UserLoginModel = Nutritionist.Core.Models.User.Login;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;


namespace Nutritionist.Services
{
    public class UserService:BaseServices
    {
        UserRepository userRepository = new UserRepository();

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

    }
}
