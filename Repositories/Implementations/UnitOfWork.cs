using System.Threading.Tasks;
using Building_Construction_Management_System.Data;
using Building_Construction_Management_System.Repositories.Interfaces;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BuildingConstructionDbContext _context;

        public UnitOfWork(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
