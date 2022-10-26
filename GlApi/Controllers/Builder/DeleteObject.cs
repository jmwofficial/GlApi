using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteObject : ControllerBase
    {
        private readonly ILogger<DeleteObject> _logger;
        private readonly ConceptDb _cptDb;
        public DeleteObject(ILogger<DeleteObject> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DeleteObject")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string objName)
        {
            libName = libName.Replace("_", String.Empty);
            objName = objName.Replace("_", String.Empty);
            ConceptDbResponse response = await _cptDb.DeleteObjectAsync(builderId, libName, objName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
