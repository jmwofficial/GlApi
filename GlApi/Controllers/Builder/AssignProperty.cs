using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignProperty : ControllerBase
    {
        private readonly ILogger<AssignProperty> _logger;
        private readonly ConceptDb _cptDb;
        public AssignProperty(ILogger<AssignProperty> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "AssignProperty")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string propName, string objName)
        {
            libName = libName.Replace("_", String.Empty);
            propName = propName.Replace("_", String.Empty);
            objName = objName.Replace("_", String.Empty);
            ConceptDbResponse response = await _cptDb.AssignPropertyAsync(builderId, libName, propName, objName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
