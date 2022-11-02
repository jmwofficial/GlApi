using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrieveUserScope : ControllerBase
    {
        private readonly ILogger<RetrieveUserScope> _logger;
        private readonly ConceptDb _cptDb;
        private static bool _verbose = false;
        public RetrieveUserScope(ILogger<RetrieveUserScope> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "RetrieveUserScope")]
        public async Task<ConceptDbResponse> Get(string builderId, string email)
        {
            email = WebUtility.UrlDecode(email);
            ConceptDbResponse response = await _cptDb.RetrieveUserScopeAsync(builderId, email);
            _logger.LogWarning(ApiMessaging.LogMessage);
            if (_verbose)
            {
                _logger.LogWarning(ApiMessaging.ResponseToString(response));
            }
            return response;
        }
    }
}
