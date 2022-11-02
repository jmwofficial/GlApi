using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteAccount : ControllerBase
    {
        private readonly ILogger<DeleteAccount> _logger;
        private readonly ConceptDb _cptDb;
        public DeleteAccount(ILogger<DeleteAccount> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DeleteAccount")]
        public async Task<ConceptDbResponse> Get(string tryKey, int id)
        {
            ConceptDbResponse response = await _cptDb.DeleteAccountAsync(tryKey, id);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
