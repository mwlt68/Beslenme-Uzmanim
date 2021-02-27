using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NutritionistDetail = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistUpdate = Nutritionist.Core.Models.Nutritionist.Update;
using UserDetail = Nutritionist.Core.Models.User.Detail;
using UserUpdate = Nutritionist.Core.Models.User.Update;
using ArticleDetail = Nutritionist.Core.Models.Article.Detail;
using ArticleUpdate = Nutritionist.Core.Models.Article.Update;

namespace Nutritionist.Web.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<NutritionistDetail, NutritionistUpdate>()
                .ForMember(s => s.ProfileImage, opt => opt.MapFrom(d => GetFileFromBytes(d.ProfileImage)))
                .ReverseMap()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => GetBytesFromFile(src.ProfileImage)));
            CreateMap<UserDetail, UserUpdate>()
                .ReverseMap();
            CreateMap<ArticleDetail, ArticleUpdate>()
                .ForMember(s => s.Image, opt => opt.MapFrom(d => GetFileFromBytes(d.Image)))
                .ReverseMap()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => GetBytesFromFile(src.Image)));

        }
        public byte[] GetBytesFromFile(IFormFile formFile)
        {
            if (formFile == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
        // Todo: this method not checked
        public IFormFile GetFileFromBytes(byte[] byteArray)
        {
            
            if (byteArray == null)
            {
                return null;
            }
            var stream = new MemoryStream(byteArray);
            IFormFile file = new FormFile(stream, 0, byteArray.Length, "ProfileImage", "0.jpg");
            return file;
        }
    }
}
