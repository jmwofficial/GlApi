using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;
namespace GlApi.Controllers.DbAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReqDbInitialize : ControllerBase
    {
        private readonly ILogger<ReqDbInitialize> _logger;
        private readonly ConceptDb _cptDb;
        public ReqDbInitialize(ILogger<ReqDbInitialize> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "ReqDbInitialize")]
        public async Task<ConceptDbResponse> Get(string secKey)
        {
            ConceptDbResponse response = await _cptDb.RequestDbInitializeAsync(secKey);
            string log0 = ApiMessaging.LogMessage;
            string log1 = ApiMessaging.ResponseToString(response);
            _logger.LogWarning("{log0}",log0);
            _logger.LogWarning("{log1}", log1);
            return response;
        }
    }
}
