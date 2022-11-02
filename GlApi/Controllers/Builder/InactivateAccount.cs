using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class InactivateAccount : ControllerBase
    {
        private readonly ILogger<InactivateAccount> _logger;
        private readonly ConceptDb _cptDb;
        public InactivateAccount(ILogger<InactivateAccount> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "InactivateAccount")]
        public async Task<ConceptDbResponse> Get(string tryKey, int id)
        {
            ConceptDbResponse response = await _cptDb.InactivateAccountAsync(tryKey, id);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
