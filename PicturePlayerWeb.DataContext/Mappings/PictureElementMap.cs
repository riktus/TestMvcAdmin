using PicturePlayerWeb.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePlayerWeb.DataContext.Mappings
{
    class PictureElementMap : EntityTypeConfiguration<PictureElement>
    {
        public PictureElementMap()
        {
            //Table and Columns Mappings
            ToTable("PictureElements");

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name);
            Property(c => c.Link);
            Property(c => c.StartTime);
            Property(c => c.ImageData);
            Property(c => c.ImageMimeType);
        }
    }
}
