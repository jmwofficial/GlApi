using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveObjectType : ControllerBase
    {
        private readonly ILogger<MoveObjectType> _logger;
        private readonly ConceptDb _cptDb;
        public MoveObjectType(ILogger<MoveObjectType> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "MoveObjectType")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string objTypeName, string newParentName)
        {
            libName = libName.Replace("_", String.Empty);
            objTypeName = objTypeName.Replace("_", String.Empty);
            newParentName = newParentName.Replace("_", String.Empty);
            ConceptDbResponse response = await _cptDb.MoveObjectTypeAsync(builderId, libName, objTypeName, newParentName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
