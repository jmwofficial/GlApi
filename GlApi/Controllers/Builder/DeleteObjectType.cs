using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteObjectType : ControllerBase
    {
        private readonly ILogger<DeleteObjectType> _logger;
        private readonly ConceptDb _cptDb;
        public DeleteObjectType(ILogger<DeleteObjectType> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DeleteObjectType")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string objTypeName)
        {
            ConceptDbResponse response = await _cptDb.DeleteObjectTypeAsync(builderId, libName, objTypeName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
