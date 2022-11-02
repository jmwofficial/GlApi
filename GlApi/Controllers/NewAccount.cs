using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewAccount : ControllerBase
    {
        private readonly ILogger<NewAccount> _logger;
        private readonly ConceptDb _cptDb;
        public NewAccount(ILogger<NewAccount> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "NewAccount")]
        public async Task<ConceptDbResponse> Get(string tryKey, string acctType, string acctName, string firstName, string lastName, string username, string password)
        {
            ConceptDbResponse response = await _cptDb.NewAccountAsync(tryKey, acctType, acctName, firstName, lastName, username, password);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
