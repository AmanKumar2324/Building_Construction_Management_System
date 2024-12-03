using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Services.Interfaces;
using Building_Construction_Management_System.Services.Interface;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("by-project/{projectId:int}")]
        public async Task<IActionResult> GetDocumentsByProjectId(int projectId)
        {
            var documents = await _documentService.GetDocumentsByProjectIdAsync(projectId);
            return Ok(documents);
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument(Document document)
        {
            await _documentService.AddDocumentAsync(document);
            return Created("", document);
        }
    }
}
