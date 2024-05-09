using ProjectManager.Dtos.Tag;
using ProjectManager.Models;

namespace ProjectManager.Mappers;

public static class TagMapper
{
    public static TagDto ToTagDto(this Tag tagModel)
    {
        return new TagDto()
        {
            Id = tagModel.Id,
            Name = tagModel.Name
        };
    }
}