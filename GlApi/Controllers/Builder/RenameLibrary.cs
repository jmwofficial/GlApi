using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenameLibrary : ControllerBase
    {
        private readonly ILogger<RenameLibrary> _logger;
        private readonly ConceptDb _cptDb;
        public RenameLibrary(ILogger<RenameLibrary> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "RenameLibrary")]
        public async Task<ConceptDbResponse> Get(string builderId, string oldName, string newName)
        {

            ConceptDbResponse response = await _cptDb.RenameLibraryAsync(builderId, oldName, newName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
