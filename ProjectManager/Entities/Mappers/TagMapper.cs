using Shared.DataTransferObjects.Tag;
using Entities.Models;

namespace Entities.Mappers;

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