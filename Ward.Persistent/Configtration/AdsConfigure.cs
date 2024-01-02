using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Domain;

namespace Ward.Persistent.Configtration
{
    public class AdsConfigure : IEntityTypeConfiguration<Ads>

    {
        public void Configure(EntityTypeBuilder<Ads> builder)
        {
            builder.HasKey(x => x.AdsID);
            builder.Property(x => x.Comment).HasColumnType("nvarchar(300)").HasMaxLength(300);
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property(x => x.UrlImagesJson).HasColumnType("Json");
            builder.Property(x => x.IsActive).HasColumnType<bool>("tinyint").HasDefaultValue(0);
            builder.Ignore(x => x.UrlImages);
        }
    }
}
