using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasData(
            new Tag
            {
                Id = new Guid("b9ff92a8-0e30-4f0e-9085-4a7a1fe9baec"),
                Name = "Work"
            },
            new Tag
            {
                Id = new Guid("f324cd8a-5f96-475c-a469-7f6f92109c90"),
                Name = "Errands"
            },
            new Tag
            {
                Id = new Guid("98ad099a-6cf4-4d92-9055-0ddf6b4a82db"),
                Name = "Urgent"
            },
            new Tag
            {
                Id = new Guid("62601897-89ae-4787-a436-e9c757a50f87"),
                Name = "Hobby/Leisure"
            },
            new Tag
            {
                Id = new Guid("eb02fd46-e4dd-4745-ae3d-acf3774c3d60"),
                Name = "Programming"
            }
        );
    }
}