using PicturePlayerWeb.DataContext.Factory.Interfaces;
using PicturePlayerWeb.Entity;
using PicturePlayerWeb.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PicturePlayerWeb.Models.Implementations.Repository
{
    public class PictureElementsRepository : IRepository<PictureElement>
    {
        private readonly IDatabaseModelContextFactory contextFactory;
        public PictureElementsRepository(IDatabaseModelContextFactory factory)
        {
            contextFactory = factory;
        }

        public void Save(PictureElement item)
        {
            using(var context = contextFactory.GetDefaultContext())
            {
                if (item.Id == 0)
                    context.PictureElements.Add(item);
                else
                {
                    var element = context.PictureElements.Find(item.Id);

                    if(element != null)
                    {
                        element.Name = Regex.Replace(item.Name, " ", "");
                        element.StartTime = Regex.Replace(item.StartTime, " ", "");
                        element.ImageData = item.ImageData;
                        element.ImageMimeType = item.ImageMimeType;
                    }
                }

                context.SaveChanges();
            }
        }

        public List<PictureElement> GetAllItems()
        {
            using(var context = contextFactory.GetDefaultContext())
            {
                return context.PictureElements.ToList();
            }
        }

        public PictureElement Delete(int itemId)
        {
            using (var context = contextFactory.GetDefaultContext())
            {
                PictureElement item = context.PictureElements.Find(itemId);

                if(item != null)
                {
                    context.PictureElements.Remove(item);
                    context.SaveChanges();
                }

                return item;
            }
        }
    }
}