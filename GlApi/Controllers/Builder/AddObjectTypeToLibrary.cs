using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddObjectTypeToLibrary : ControllerBase
    {
        private readonly ILogger<AddObjectTypeToLibrary> _logger;
        private readonly ConceptDb _cptDb;
        public AddObjectTypeToLibrary(ILogger<AddObjectTypeToLibrary> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "AddObjectTypeToLibrary")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string parentType, string newType)
        {
            ConceptDbResponse response = await _cptDb.AddObjectTypeToLibraryAsync(builderId, libName, parentType, newType);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
