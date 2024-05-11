namespace Contracts;

public interface IRepositoryManager
{
    IProjectRepository Project { get; }
    void Save();
}