using InstitutionManagmentSystem.Data;
using InstitutionManagmentSystem.Models;
using RepositoryWithUOW.Core.Interfaces;

namespace RepositoryWithUWO.EF.Repositories;

public class UnitOfWork(AppDbContext _appDbContext) : IUnitOfWork
{
    public IBaseRepository<Student> Students { get; private set; } = new BaseRepository<Student>(_appDbContext);

    public IBaseRepository<Teacher> Teachers { get; private set; } = new BaseRepository<Teacher>(_appDbContext);

    public IBaseRepository<Halaqa> Halaqat { get; private set; } = new BaseRepository<Halaqa>(_appDbContext);

    public int Complete() => _appDbContext.SaveChanges();

    public void Dispose() => _appDbContext.Dispose();
}
