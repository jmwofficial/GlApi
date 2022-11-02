using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewUser : ControllerBase
    {
        private readonly ILogger<NewUser> _logger;
        private readonly ConceptDb _cptDb;
        public NewUser(ILogger<NewUser> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "NewUser")]
        public async Task<ConceptDbResponse> Get(string builderId, string? firstName, string? lastName, string? email, string? password)
        {
            ConceptDbResponse response = await _cptDb.NewUserAsync(builderId, firstName, lastName, email, password);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
