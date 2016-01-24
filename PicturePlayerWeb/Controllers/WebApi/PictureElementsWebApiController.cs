using System.Linq;
using System.Web.Http;
using PicturePlayerWeb.Entity;
using PicturePlayerWeb.DataContext.Factory.Interfaces;

namespace PicturePlayerWeb.Controllers.WebApi
{
    public class PictureElementsWebApiController : ApiController
    {
        private readonly IDatabaseModelContextFactory contextFactory;
        public PictureElementsWebApiController(IDatabaseModelContextFactory factory)
        {
            contextFactory = factory;
        }

        // GET: api/PictureElementsWebApi
        public IQueryable<PictureElement> GetPictureElements()
        {
            var context = contextFactory.GetDefaultContext();

            return context.PictureElements;
        }
    }
}