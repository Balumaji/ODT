using OrchardDNT.Core.Models;
using OrchardDNT.Core.Services;
using OrchardDNT.Web.CustomFilters;
using OrchardDNT.Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrchardDNT.Web.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IUserPostsService _userPostService;
        private readonly ICacheService _cacheService;

        public PostsController(IUserPostsService userPostService, ICacheService cacheService)
        {
            _userPostService = userPostService;
            _cacheService = cacheService;
        }

        [HttpPost]
        [CustomAuthorize(RestrictToToken = "T3JjaGFyZEFwaUtleQ==")]
        public HttpResponseMessage Add(UserPost userPost)
        {
            try
            {
                var result = _userPostService.SubmitPost(userPost);                
                _cacheService.AddToCollection($"userposts-1", userPost);

                return result ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
