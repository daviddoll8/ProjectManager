using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IProjectService> _projectService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _projectService = new Lazy<IProjectService>(() =>
            new ProjectService(repositoryManager));
    }

    public IProjectService ProjectService => _projectService.Value;
}