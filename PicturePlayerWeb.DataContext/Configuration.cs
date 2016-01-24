using PicturePlayerWeb.DataContext.Contexts;
using PicturePlayerWeb.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePlayerWeb.DataContext
{
    public class Configuration : DropCreateDatabaseIfModelChanges<MsSqlModelContext>
    {
        protected override void Seed(MsSqlModelContext context)
        {
            context.PictureElements.Add(new PictureElement()
            {
                Id = 0,
                Name = "Toyota",
                StartTime = "18-30-00"
            });
            context.PictureElements.Add(new PictureElement()
            {
                Id = 1,
                Name = "Bmw",
                StartTime = "19-30-00"
            });
            context.PictureElements.Add(new PictureElement()
            {
                Id = 2,
                Name = "Lexus",
                StartTime = "20-30-00"
            });
            context.PictureElements.Add(new PictureElement()
            {
                Id = 3,
                Name = "Mercedes",
                StartTime = "21-30-00"
            });

            context.SaveChanges();
        }
    }
}
