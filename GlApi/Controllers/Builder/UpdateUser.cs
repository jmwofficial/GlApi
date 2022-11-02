using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateUser : ControllerBase
    {
        private readonly ILogger<UpdateUser> _logger;
        private readonly ConceptDb _cptDb;
        public UpdateUser(ILogger<UpdateUser> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "UpdateUser")]
        public async Task<ConceptDbResponse> Get(string builderId, string currentEmail, string? firstName, string? lastName, string? newEmail, string? password)
        {
            ConceptDbResponse response = await _cptDb.UpdateUserAsync(builderId, currentEmail, firstName, lastName, newEmail, password);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
