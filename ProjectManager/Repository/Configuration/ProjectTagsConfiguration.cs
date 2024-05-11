using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ProjectTagsConfiguration : IEntityTypeConfiguration<ProjectTag>
{
    public void Configure(EntityTypeBuilder<ProjectTag> builder)
    {
        builder.HasData(
            new ProjectTag
            {
                ProjectId = new Guid("ab29aef9-77c5-4654-8e19-12cde67ded9a"), 
                TagId = new Guid("b9ff92a8-0e30-4f0e-9085-4a7a1fe9baec")
            },
            new ProjectTag
            {
                ProjectId = new Guid("017121a4-0357-4dde-9057-5030c19dd128"), 
                TagId = new Guid("f324cd8a-5f96-475c-a469-7f6f92109c90")
            },
            new ProjectTag
            {
                ProjectId = new Guid("017121a4-0357-4dde-9057-5030c19dd128"), 
                TagId = new Guid("98ad099a-6cf4-4d92-9055-0ddf6b4a82db")
            },
            new ProjectTag
            {
                ProjectId = new Guid("ab29aef9-77c5-4654-8e19-12cde67ded9a"), 
                TagId = new Guid("98ad099a-6cf4-4d92-9055-0ddf6b4a82db")
            },
            new ProjectTag
            {
                ProjectId = new Guid("ab29aef9-77c5-4654-8e19-12cde67ded9a"), 
                TagId = new Guid("eb02fd46-e4dd-4745-ae3d-acf3774c3d60")
            }
        );
    }
}