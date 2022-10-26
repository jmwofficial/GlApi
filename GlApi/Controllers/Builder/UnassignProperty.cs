using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnassignProperty : ControllerBase
    {
        private readonly ILogger<UnassignProperty> _logger;
        private readonly ConceptDb _cptDb;
        public UnassignProperty(ILogger<UnassignProperty> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "UnassignProperty")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string propName, string objName)
        {
            ConceptDbResponse response = await _cptDb.UnassignPropertyAsync(builderId, libName, propName, objName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
