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
    internal class UserSignUpConfiguration : IEntityTypeConfiguration<DBUserSignUp>
    {
        public void Configure(EntityTypeBuilder<DBUserSignUp> builder)
        {
            builder.ToTable("UserSignUp");
            builder.HasKey(x => x._id);
            builder.Property(x => x._email).IsRequired(true);
			builder.Property(x => x._pass).IsRequired(true);
            builder.Property(x => x._repass);
		}
	}
}
