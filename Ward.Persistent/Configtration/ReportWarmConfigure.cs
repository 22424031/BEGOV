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
    public class ReportWarmConfigure : IEntityTypeConfiguration<ReportWarm>
    {
        public void Configure(EntityTypeBuilder<ReportWarm> builder)
        {
            builder.HasKey(x => x.ReportWarmID);
            builder.Ignore(x => x.UrlString);
            builder.Property(x => x.WarmType).IsRequired().HasColumnType("nvarchar(128)");
            builder.Property(x => x.FullName).IsRequired().HasColumnType("nvarchar(128)");
            builder.Property(x => x.Comment).IsRequired().HasColumnType("nvarchar(300)");
            builder.Property(x => x.UrlStringJson).HasColumnType("Json");
            builder.Property(x => x.AdsID).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(128)");
            builder.Property(x => x.PhoneNumber).IsRequired().HasColumnType("varchar(15)");
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Feedback).HasMaxLength(300);
        }
    }
}
