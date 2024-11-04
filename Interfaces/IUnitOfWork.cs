using InstitutionManagmentSystem.Models;

namespace RepositoryWithUOW.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<Student> Students{ get; }
        public IBaseRepository<Teacher> Teachers{ get; }
        public IBaseRepository<Halaqa> Halaqat{ get; }


        public int Complete();
        public void Dispose();

    }
}
