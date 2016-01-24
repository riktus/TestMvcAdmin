using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePlayerWeb.Infrastructure.Interfaces
{
    public interface IAuthProvider
    {
        bool Authenticate(string userName, string password);
    }
}
