using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrieveAcctScope : ControllerBase
    {
        private readonly ILogger<RetrieveAcctScope> _logger;
        private readonly ConceptDb _cptDb;
        private static bool _verbose = false;
        public RetrieveAcctScope(ILogger<RetrieveAcctScope> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "RetrieveAcctScope")]
        public async Task<ConceptDbResponse> Get(string builderId)
        {
            ConceptDbResponse response = await _cptDb.RetrieveAcctScopeAsync(builderId);
            _logger.LogWarning(ApiMessaging.LogMessage);
            if (_verbose)
            {
                _logger.LogWarning(ApiMessaging.ResponseToString(response));
            }
            return response;
        }
    }
}
