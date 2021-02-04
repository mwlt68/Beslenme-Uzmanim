using AutoMapper;
using Nutritionist.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using UserInsertModel= Nutritionist.Core.Models.User.Insert;

namespace Nutritionist.Services
{
    public class UserService:BaseServices
    {
        UserRepository userRepository = new UserRepository();
        public void UserRegister(UserInsertModel userInsertModel)
        {
            var user =mapper.Map<UserInsertModel, Data.Entities.User>(userInsertModel);
            userRepository.Add(user);
        }

    }
}
