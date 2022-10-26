using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteProperty : ControllerBase
    {
        private readonly ILogger<DeleteProperty> _logger;
        private readonly ConceptDb _cptDb;
        public DeleteProperty(ILogger<DeleteProperty> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DeleteProperty")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string propName)
        {
            libName = libName.Replace("_", String.Empty);
            propName = propName.Replace("_", String.Empty);
            ConceptDbResponse response = await _cptDb.DeletePropertyAsync(builderId, libName, propName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
