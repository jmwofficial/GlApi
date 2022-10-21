using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveObjectFromLibrary : ControllerBase
    {
        private readonly ILogger<RemoveObjectFromLibrary> _logger;
        private readonly ConceptDb _cptDb;
        public RemoveObjectFromLibrary(ILogger<RemoveObjectFromLibrary> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "RemoveObjectFromLibrary")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string objName)
        {
            ConceptDbResponse response = await _cptDb.RemoveObjectFromLibraryAsync(builderId, libName, objName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
