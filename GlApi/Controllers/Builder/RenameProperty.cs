using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenameProperty : ControllerBase
    {
        private readonly ILogger<RenameProperty> _logger;
        private readonly ConceptDb _cptDb;
        public RenameProperty(ILogger<RenameProperty> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "RenameProperty")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string oldName, string newName)
        {
            ConceptDbResponse response = await _cptDb.RenamePropertyAsync(builderId, libName, oldName, newName );
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
