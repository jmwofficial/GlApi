using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetPropertyValue : ControllerBase
    {
        private readonly ILogger<SetPropertyValue> _logger;
        private readonly ConceptDb _cptDb;
        public SetPropertyValue(ILogger<SetPropertyValue> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "SetPropertyValue")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string objName, string propName, string? stringVals, string? objNameVals, string? numVals)
        {
            libName = libName.Replace("_", String.Empty);
            propName = propName.Replace("_", String.Empty);
            objName = objName.Replace("_", String.Empty);   
            ConceptDbResponse response = await _cptDb.SetPropertyValueAsync(builderId, libName, objName, propName, stringVals ?? string.Empty, objNameVals ?? string.Empty, numVals ?? string.Empty);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
