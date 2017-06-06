using OrchardDNT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrchardDNT.Web.Models
{
    public class UserPostViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class UserPostListViewModel
    {
        public IEnumerable<UserPost> Posts { get; set; }
        public Page Page {get;set;}
    }

    public class Page
    {
        public int Size { get; set; }
        public int Skip { get; set; }
    }
}