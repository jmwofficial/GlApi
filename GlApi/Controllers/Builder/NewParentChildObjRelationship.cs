using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewParentChildObjRelationship : ControllerBase
    {
        private readonly ILogger<NewParentChildObjRelationship> _logger;
        private readonly ConceptDb _cptDb;
        public NewParentChildObjRelationship(ILogger<NewParentChildObjRelationship> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "NewParentChildObjRelationship")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string parentName, string childName)
        {

            ConceptDbResponse response = await _cptDb.NewParentChildObjRelationshipAsync(builderId, libName, parentName, childName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
