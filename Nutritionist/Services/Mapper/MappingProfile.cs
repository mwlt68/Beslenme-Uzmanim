using AutoMapper;
using System.Collections.Generic;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserListModel = Nutritionist.Core.Models.User.List;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
using ArticleInsertModel = Nutritionist.Core.Models.Article.Insert;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using CommentInsertModel = Nutritionist.Core.Models.Comment.Insert;
using CommentListModel = Nutritionist.Core.Models.Comment.List;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistEntity = Nutritionist.Data.Entities.Nutritionist;
using ArticleEntity = Nutritionist.Data.Entities.Article;
using UserEntity = Nutritionist.Data.Entities.User;
using CommentEntity = Nutritionist.Data.Entities.Comment;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;

namespace Nutritionist.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserListModel>().ReverseMap();
            CreateMap<UserEntity, UserDetailModel>().ReverseMap();
            CreateMap<UserEntity, UserInsertModel>().ReverseMap();
            CreateMap<ArticleEntity, ArticleDetailModel>();
            CreateMap<ArticleEntity, ArticleInsertModel>()
                .ForMember(s => s.Image, opt => opt.MapFrom(d => GetFileFromBytes(d.Image)))
                .ReverseMap()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => GetBytesFromFile(src.Image)));
            CreateMap<ArticleEntity, ArticleListModel>().ReverseMap();
            CreateMap<CommentEntity, CommentInsertModel>().ReverseMap();
            CreateMap<CommentEntity, CommentListModel>().ReverseMap();
            CreateMap<NutritionistEntity, NutritionistInsertModel>()
                .ForMember(s => s.ProfileImage, opt => opt.MapFrom(d=> GetFileFromBytes(d.ProfileImage)))
                .ReverseMap()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => GetBytesFromFile(src.ProfileImage)));
            CreateMap<NutritionistEntity, NutritionistDetailModel>().ReverseMap();
            CreateMap<NutritionistEntity, NutritionistListModel>().ReverseMap();

        }

        public  byte[] GetBytesFromFile(IFormFile formFile)
        {
            if (formFile == null )
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
            IFormFile file = new FormFile(stream, 0, byteArray.Length, "name", "profileImage");
            return file;
        }
    }
}
