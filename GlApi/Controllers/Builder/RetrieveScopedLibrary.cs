using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrieveScopedLibrary : ControllerBase
    {
        private readonly ILogger<RetrieveScopedLibrary> _logger;
        private readonly ConceptDb _cptDb;
        public RetrieveScopedLibrary(ILogger<RetrieveScopedLibrary> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "RetrieveScopedLibrary")]
        public async Task<ConceptDbResponse> Get(string builderId, string libraryName)
        {
            ConceptDbResponse response = await _cptDb.RetrieveScopedLibraryAsync(builderId, libraryName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
