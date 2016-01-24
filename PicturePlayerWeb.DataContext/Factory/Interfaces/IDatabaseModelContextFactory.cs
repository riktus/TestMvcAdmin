using PicturePlayerWeb.DataContext.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePlayerWeb.DataContext.Factory.Interfaces
{
    public interface IDatabaseModelContextFactory
    {
        MsSqlModelContext GetDefaultContext();
    }
}
