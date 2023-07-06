using META_TodoList.Data.cs.Entities;
using META_TodoList.Models.ToDoList_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace META_TodoList.Data.cs.Configurations
{
    internal class ToDoTitleConfiguration : IEntityTypeConfiguration<DBToDoTitle>
    {
        public void Configure(EntityTypeBuilder<DBToDoTitle> builder)
        {
            builder.ToTable("ToDoTitle");
            builder.HasKey(x => x._id);
            builder.Property(x=>x._id).HasDefaultValueSql("NEWID()");
			builder.Property(x => x._title);
            builder.Property(x => x._checkedtitle);
            builder.HasOne(x => x.users).WithMany(x => x.titles).HasForeignKey(x => x.User_Id);
		}
	}
}
