using ConceptDbLib;
using GlApi.Controllers.Builder;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.DbAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbAdminEnsureCreated : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        public DbAdminEnsureCreated(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "EnsureCreated")]
        public ConceptDbResponse EnsureCreated(string secId)
        {
            return _cptDb.EnsureCreated(secId);
        }
    }
}
