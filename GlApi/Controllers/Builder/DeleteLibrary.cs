using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteLibrary : ControllerBase
    {
        private readonly ILogger<DeleteLibrary> _logger;
        private readonly ConceptDb _cptDb;
        public DeleteLibrary(ILogger<DeleteLibrary> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DeleteLibrary")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName)
        {
            ConceptDbResponse response = await _cptDb.DeleteLibraryAsync(builderId, libName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
