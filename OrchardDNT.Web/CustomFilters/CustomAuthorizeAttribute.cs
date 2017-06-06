using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OrchardDNT.Web.CustomFilters
{

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string RestrictToToken { get; set; }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (string.IsNullOrWhiteSpace(RestrictToToken))
            {
                base.OnAuthorization(actionContext);
            }

            if (AuthorizeRequest(actionContext))
                return;

            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }

        private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization != null)
                return (actionContext.Request.Headers.Authorization.Parameter.Equals(RestrictToToken));
            return false;
        }
    }
}