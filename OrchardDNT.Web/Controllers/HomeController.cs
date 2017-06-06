using OrchardDNT.Core.Services;
using OrchardDNT.Web.CustomFilters;
using OrchardDNT.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrchardDNT.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserPostsService _userPostService;
        private readonly ICacheService _cacheService;

        public HomeController(
            IUserService userService, 
            IUserPostsService userPostService, 
            ICacheService cacheService)
        {
            _userService = userService;
            _userPostService = userPostService;
            _cacheService = cacheService;
        }

        [UserIdFilterAttribute]
        public ActionResult Index(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                //error handling to be done
            }
            return null;
        }

        //[UserIdFilterAttribute]        
        //public ActionResult LoadPosts(int id)
        //{
        //    try
        //    {
        //        var posts = _userPostService.GetPosts(id);                
        //        return PartialView("_UserPosts", posts.OrderByDescending(p => p.Id).Take(5));
        //    }
        //    catch(Exception ex)
        //    {
        //        //error handling to be done
        //    }
        //    return null;            
        //}

        [UserIdFilterAttribute]
        public ActionResult LoadPosts(int id, int skip = 0, int take = 5)
        {
            try
            {
                System.Threading.Thread.Sleep(3000);

                var posts = _cacheService.GetOrSet($"userposts-{id}", () => FetchPosts(id));

                var limitedPosts = posts.OrderByDescending(p => p.Id).Skip(skip).Take(take);

                return PartialView("_UserPosts", new UserPostListViewModel { Posts = limitedPosts, Page = new Models.Page { Size = take, Skip = skip } });
            }
            catch (Exception ex)
            {
                //error handling to be done
            }
            return null;
        }

        private IEnumerable<Core.Models.UserPost> FetchPosts(int id)
        {
            var posts = _userPostService.GetPosts(id);
            return posts;
        }
    }
}