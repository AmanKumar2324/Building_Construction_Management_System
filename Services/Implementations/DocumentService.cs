using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interface;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
        {
            _documentRepository = documentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Document>> GetDocumentsByProjectIdAsync(int projectId)
        {
            return await _documentRepository.GetDocumentsByProjectIdAsync(projectId);
        }

        public async System.Threading.Tasks.Task AddDocumentAsync(Document document)
        {
            if (string.IsNullOrWhiteSpace(document.DocumentType))
            {
                throw new ArgumentException("Document type is required.");
            }

            await _documentRepository.AddDocumentAsync(document);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
