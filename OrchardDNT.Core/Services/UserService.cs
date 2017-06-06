using OrchardDNT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardDNT.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMyRestClient _restClient;
        private const string BaseUrl = @"https://jsonplaceholder.typicode.com";
        public UserService(IMyRestClient restClient)
        {
            _restClient = restClient;
        }

        public User GetById(int id)
        {
            return _restClient.Get<User>($"{BaseUrl}/users/{id}");
        }
    }

    public interface IUserService
    {
        User GetById(int id);
    }

}
