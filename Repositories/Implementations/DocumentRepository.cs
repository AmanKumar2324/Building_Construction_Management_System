using Microsoft.EntityFrameworkCore;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Data;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public DocumentRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddDocumentAsync(Document document)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddDocument @ProjectId={document.ProjectId}, @DocumentType={document.DocumentType}, @UploadedBy={document.UploadedBy}, @UploadDate={document.UploadDate}, @VersionNumber={document.VersionNumber}");
        }

        public async Task<IEnumerable<Document>> GetDocumentsByProjectIdAsync(int projectId)
        {
            return await _context.Documents
                .FromSqlInterpolated($"EXEC GetDocumentsByProject @ProjectId={projectId}")
                .ToListAsync();
        }
    }
}
