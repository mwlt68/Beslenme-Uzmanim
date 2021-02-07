using AutoMapper;
using System.Collections.Generic;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;
using UserListModel = Nutritionist.Core.Models.User.List;
using ArticleListModel = Nutritionist.Core.Models.Article.List;
using Article = Nutritionist.Data.Entities.Article;
using ArticleInsertModel = Nutritionist.Core.Models.Article.Insert;
using ArticleDetailModel = Nutritionist.Core.Models.Article.Detail;
using CommentInsertModel = Nutritionist.Core.Models.Comment.Insert;
using CommentListModel = Nutritionist.Core.Models.Comment.List;
using NutritionistInsertModel = Nutritionist.Core.Models.Nutritionist.Insert;
using NutritionistListModel = Nutritionist.Core.Models.Nutritionist.List;
using NutritionistDetailModel = Nutritionist.Core.Models.Nutritionist.Detail;
using NutritionistEntity = Nutritionist.Data.Entities.Nutritionist;


namespace Nutritionist.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserInsertModel, Data.Entities.User>();
            CreateMap< Data.Entities.User, UserListModel>();
            CreateMap< Data.Entities.User, UserDetailModel>();
            CreateMap<NutritionistInsertModel, Data.Entities.Nutritionist>();
            CreateMap<IEnumerable<Article>, IEnumerable<ArticleListModel>>();
            CreateMap<Article, ArticleListModel>();
            CreateMap<Article, ArticleDetailModel>();
            CreateMap<ArticleInsertModel, Article>();
            CreateMap<CommentInsertModel, Data.Entities.Comment>();
            CreateMap<IEnumerable<Data.Entities.Comment>, IEnumerable<CommentListModel>>();
            CreateMap<Data.Entities.Nutritionist, NutritionistListModel>();
            CreateMap<Nutritionist.Data.Entities.Nutritionist, NutritionistListModel>();
            CreateMap<Data.Entities.Nutritionist, NutritionistDetailModel>();
            CreateMap<Data.Entities.User, UserDetailModel>();
            CreateMap<Data.Entities.User, UserListModel>();
            CreateMap<Data.Entities.Nutritionist, NutritionistListModel>();
            CreateMap <IEnumerable<NutritionistEntity>, IEnumerable < NutritionistListModel >  > ();

        }
    }
}
