using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interface
{
    public interface IDocumentService
    {
        System.Threading.Tasks.Task AddDocumentAsync(Document document);
        Task<IEnumerable<Document>> GetDocumentsByProjectIdAsync(int projectId);
    }
}
