using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeverParentChildObjRelationship : ControllerBase
    {
        private readonly ILogger<SeverParentChildObjRelationship> _logger;
        private readonly ConceptDb _cptDb;
        public SeverParentChildObjRelationship(ILogger<SeverParentChildObjRelationship> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "SeverParentChildObjRelationship")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string childName)
        {
            ConceptDbResponse response = await _cptDb.SeverParentChildObjRelationshipAsync(builderId, libName, childName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
