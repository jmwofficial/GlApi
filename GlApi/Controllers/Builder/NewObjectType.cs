using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewObjectType : ControllerBase
    {
        private readonly ILogger<NewObjectType> _logger;
        private readonly ConceptDb _cptDb;
        public NewObjectType(ILogger<NewObjectType> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "NewObjectType")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string parentType, string newType)
        {
            ConceptDbResponse response = await _cptDb.NewObjectTypeAsync(builderId, libName, parentType, newType);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
