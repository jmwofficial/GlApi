using ConceptDbLib;
using GlApi.Controllers.Builder;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.DbAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbInitialize : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        public DbInitialize(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DbInitialize")]
        public async Task<ConceptDbResponse> Get(string confirmId)
        {
            return await _cptDb.DbInitializeAsync(confirmId);
        }
    }
}
