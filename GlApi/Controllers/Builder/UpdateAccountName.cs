using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateAccountName : ControllerBase
    {
        private readonly ILogger<UpdateAccountName> _logger;
        private readonly ConceptDb _cptDb;
        public UpdateAccountName(ILogger<UpdateAccountName> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "UpdateAccountName")]
        public async Task<ConceptDbResponse> Get(string builderId, string newName)
        {
            ConceptDbResponse response = await _cptDb.UpdateAccountNameAsync(builderId, newName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
