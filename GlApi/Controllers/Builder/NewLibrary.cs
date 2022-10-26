using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewLibrary : ControllerBase
    {
        private readonly ILogger<NewLibrary> _logger;
        private readonly ConceptDb _cptDb;
        public NewLibrary(ILogger<NewLibrary> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "NewLibrary")]
        public async Task<ConceptDbResponse> Get(string builderId, string libraryName)
        {
            libraryName = libraryName.Replace("_", String.Empty);
            ConceptDbResponse response = await _cptDb.CreateLibraryAsync(builderId, libraryName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
