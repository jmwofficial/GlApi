using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveObject : ControllerBase
    {
        private readonly ILogger<MoveObject> _logger;
        private readonly ConceptDb _cptDb;
        public MoveObject(ILogger<MoveObject> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "MoveObject")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string? parentName, string childName)
        {

            libName = libName.Replace("_", String.Empty);
            childName = childName.Replace("_", String.Empty);
            if(parentName != null)
            {
                parentName = parentName.Replace("_", String.Empty);
            }
            ConceptDbResponse response = await _cptDb.MoveObjectAsync(builderId, libName, parentName, childName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
