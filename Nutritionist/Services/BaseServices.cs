using AutoMapper;
using Nutritionist.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;

namespace Nutritionist.Services
{
    public  class BaseServices
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
        public  List<TDestination> ArrayMap<TSource,TDestination>( List<TSource> sources)
        {
            List<TDestination> destinations = new List<TDestination>();
            foreach (var item in sources)
            {
                var destination = mapper.Map<TSource, TDestination>(item);
                if (destination != null)
                {
                    destinations.Add(destination);
                }
            }
            return destinations;
        }
    }
}
