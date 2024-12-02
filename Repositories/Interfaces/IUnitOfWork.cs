using System.Threading.Tasks;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
