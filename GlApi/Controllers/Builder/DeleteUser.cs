using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteUser : ControllerBase
    {
        private readonly ILogger<DeleteUser> _logger;
        private readonly ConceptDb _cptDb;
        public DeleteUser(ILogger<DeleteUser> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DeleteUser")]
        public async Task<ConceptDbResponse> Get(string builderId, string email)
        {
            ConceptDbResponse response = await _cptDb.DeleteUserAsync(builderId, email);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
