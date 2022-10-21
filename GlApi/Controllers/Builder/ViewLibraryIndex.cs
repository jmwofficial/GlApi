using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewLibraryIndex : ControllerBase
    {
        private readonly ILogger<ViewLibraryIndex> _logger;
        private readonly ConceptDb _cptDb;
        public ViewLibraryIndex(ILogger<ViewLibraryIndex> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "ViewLibraryIndex")]
        public async Task<ConceptDbResponse> Get(string builderId)
        {
            ConceptDbResponse response = await _cptDb.ViewLibraryIndexAsync(builderId);

            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
