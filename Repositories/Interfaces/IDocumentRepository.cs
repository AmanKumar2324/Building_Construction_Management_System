using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        System.Threading.Tasks.Task AddDocumentAsync(Document document);
        Task<IEnumerable<Document>> GetDocumentsByProjectIdAsync(int projectId);
    }
}
