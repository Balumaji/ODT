using OrchardDNT.Core.Models;
using OrchardDNT.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrchardDNT.Core.Services
{
    public class UserPostsService : IUserPostsService
    {
        private readonly IMyRestClient _restClient;
        private const string BaseUrl = @"https://jsonplaceholder.typicode.com";

        public UserPostsService(IMyRestClient restClient)
        {
            _restClient = restClient;
        }

        public bool SubmitPost(UserPost post)
        {
            return _restClient.Post($"{BaseUrl}/posts", post);            
        }

        public IEnumerable<UserPost> GetPosts(int userId)
        {
            return _restClient.GetAll<UserPost>($"{BaseUrl}/users/{userId}/posts");
        }
    }

    public interface IUserPostsService
    {
        bool SubmitPost(UserPost post);
        IEnumerable<UserPost> GetPosts(int userId);        
    }
}