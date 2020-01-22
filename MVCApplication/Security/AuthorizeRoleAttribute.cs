using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCApplication.Models.BD;
using MVCApplication.Models.ViewModel;
using MVCApplication.Models.EntityManager;
using System.Web.Mvc;

namespace MVCApplication.Security
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;
        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.userAssignedRoles = roles;
        }
        //the entry point for the authentication check. 
        //heck the roles assigned for certain users and 
        //returns the result specifying whether or not the user is allowed to access a page
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            using (LibraryEntities db = new LibraryEntities())
            {
                UserManager UM = new UserManager();
                foreach (var roles in userAssignedRoles)
                {
                    authorize = UM.IsUserInRole(httpContext.User.Identity.Name, roles);
                    if (authorize)
                        return authorize;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/UnAuthorized");
        }
    }
}