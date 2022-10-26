using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewProperty : ControllerBase
    {
        private readonly ILogger<NewProperty> _logger;
        private readonly ConceptDb _cptDb;
        public NewProperty(ILogger<NewProperty> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "NewProperty")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string propName)
        {
            libName = libName.Replace("_", String.Empty);
            propName = propName.Replace("_", String.Empty);
            ConceptDbResponse response = await _cptDb.NewPropertyAsync(builderId, libName, propName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
