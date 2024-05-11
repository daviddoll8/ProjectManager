﻿using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IProjectRepository> _projectRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _projectRepository = new Lazy<IProjectRepository>(() =>
            new ProjectRepository(repositoryContext));
    }

    public IProjectRepository Project => _projectRepository.Value;
    public void Save() => _repositoryContext.SaveChanges();
}