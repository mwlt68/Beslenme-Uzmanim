using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nutritionist.Data.Entities;
using Nutritionist.Data.Entities.DbContexts;

namespace Nutritionist.Data.Repository
{
    public class CommentRepository : Repository<Comment, NutritionistDBContext>
    {
        public Comment GetById(int id)
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from comment in context.Comments.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == id)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on comment.NutritionstId equals nutritionist.Id
                    from nutUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    join comUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    on comment.UserId equals comUser.Id
                    select comment;
                return query.FirstOrDefault();
            }
        }

        public List<Comment> GetNutritionistAllComments(int nutritionistId)
        {
            using (var context =new NutritionistDBContext())
            {
                var query =
                    from comment in context.Comments.Where(x => !x.DidDelete && x.IsActive.Value && x.NutritionstId == nutritionistId)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value )
                    on comment.NutritionstId equals nutritionist.Id
                    from nutUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    join comUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value )
                    on comment.UserId equals comUser.Id
                    select comment;
                return query.ToList();
            }
        }
        public int GetCommentsCount()
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from comment in context.Comments.Where(x => !x.DidDelete && x.IsActive.Value)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on comment.NutritionstId equals nutritionist.Id
                    from nutUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    join comUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    on comment.UserId equals comUser.Id
                    select comment;
                return query.Count();
            }
        }
        /*
         * 
         *                 var query =
                    from comment in context.Comments.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == id)
                    join comUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    on comment.UserId equals comUser.Id
                    select comment; 
                var commentRes = query.FirstOrDefault();
                var query2 =
                    from nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == commentRes.NutritionstId)
                    from nutUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    select nutritionist;

                var nutRitionistRes = query.FirstOrDefault();
                if (commentRes != null && nutRitionistRes != null )
                {
                    return commentRes;
                }
                else return null;
         * 
         * 
         * 
        public List<Comment> GetAll()
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from comment in context.Comments.Where(x => !x.DidDelete && x.IsActive.Value)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on comment.NutritionstId equals nutritionist.Id
                    from nutUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == nutritionist.UserId)
                    join comUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value)
                    on comment.UserId equals comUser.Id
                    select comment;
                return query.ToList();
            }
        }
        public List<Comment> GetUserAllComments(int userId)
        {
            using (var context = new NutritionistDBContext())
            {
                var query =
                    from comment in context.Comments.Where(x => !x.DidDelete && x.IsActive.Value && x.UserId == nutritionist.UserId)
                    join nutritionist in context.Nutritionists.Where(x => !x.DidDelete && x.IsActive.Value)
                    on comment.NutritionstId equals nutritionist.Id
                    from nutUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value )
                    join comUser in context.Users.Where(x => !x.DidDelete && x.IsActive.Value && x.Id == userId)
                    on comment.UserId equals comUser.Id
                    select comment;
                return query.ToList();
            }
        }
        */
    }
}
