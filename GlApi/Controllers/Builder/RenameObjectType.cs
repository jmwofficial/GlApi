using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenameObjectType : ControllerBase
    {
        private readonly ILogger<RenameObjectType> _logger;
        private readonly ConceptDb _cptDb;
        public RenameObjectType(ILogger<RenameObjectType> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "RenameObjectType")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string oldName, string newName)
        {
            libName = libName.Replace("_", String.Empty);
            oldName = oldName.Replace("_", String.Empty);
            newName = newName.Replace("_", String.Empty);
            ConceptDbResponse response = await _cptDb.RenameObjectTypeAsync(builderId, libName, oldName, newName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
