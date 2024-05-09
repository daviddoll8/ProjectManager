﻿using ProjectManager.Dtos.Task;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Mappers;

public static class TaskMapper
{
    public static TaskDto ToTaskDto(this Task taskModel)
    {
        return new TaskDto()
        {
            Id = taskModel.Id,
            ProjectId = taskModel.ProjectId,
            Name = taskModel.Name,
            Description = taskModel.Description,
            CreatedOn = taskModel.CreatedOn,
            IsCompleted = taskModel.IsCompleted,
            Priority = taskModel.Priority
        };
    }
}