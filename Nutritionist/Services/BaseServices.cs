using AutoMapper;
using Nutritionist.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;

namespace Nutritionist.Services
{
    public class BaseServices
    {
        public IMapper mapper;
        private MapperConfiguration mapperConfig;
        public BaseServices()
        {
            mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mapper = mapperConfig.CreateMapper();
        }
    }
}
