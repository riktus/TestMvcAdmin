using PicturePlayerWeb.DataContext.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicturePlayerWeb.DataContext.Contexts;

namespace PicturePlayerWeb.DataContext.Factory.Implementations
{
    public class MsSqlModelContextFactory : IDatabaseModelContextFactory
    {
        public MsSqlModelContext GetDefaultContext()
        {
            return new MsSqlModelContext();
        }
    }
}
