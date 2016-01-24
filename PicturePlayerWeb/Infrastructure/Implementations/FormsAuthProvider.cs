using PicturePlayerWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PicturePlayerWeb.Infrastructure.Implementations
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string userName, string password)
        {
            var result = FormsAuthentication.Authenticate(userName, password);
            if (result)
                FormsAuthentication.SetAuthCookie(userName, false);

            return result;
        }
    }
}