using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenameObject : ControllerBase
    {
        private readonly ILogger<RenameObject> _logger;
        private readonly ConceptDb _cptDb;
        public RenameObject(ILogger<RenameObject> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "RenameObject")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string oldName, string newName)
        {

            ConceptDbResponse response = await _cptDb.RenameObjectAsync(builderId, libName, oldName, newName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
