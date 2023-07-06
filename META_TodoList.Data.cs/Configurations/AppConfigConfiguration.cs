using META_TodoList.Data.cs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace META_TodoList.Data.cs.Configurations
{
    internal class AppConfigConfiguration : IEntityTypeConfiguration<DBAppConfig>
    {
        public void Configure(EntityTypeBuilder<DBAppConfig> builder)
        {
            builder.ToTable("AppConfig");
            builder.HasKey(x => x.key);
            builder.Property(x => x.value).IsRequired(true);
        }
    }
}
