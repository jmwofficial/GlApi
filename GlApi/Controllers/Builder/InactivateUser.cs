using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class InactivateUser : ControllerBase
    {
        private readonly ILogger<InactivateUser> _logger;
        private readonly ConceptDb _cptDb;
        public InactivateUser(ILogger<InactivateUser> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "InactivateUser")]
        public async Task<ConceptDbResponse> Get(string builderId, string email)
        {
            ConceptDbResponse response = await _cptDb.InactivateUserAsync(builderId, email);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
