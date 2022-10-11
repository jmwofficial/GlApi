using ConceptDbLib;
using GlApi.Controllers.Builder;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.DbAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbAdminEnsureDeleted : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        public DbAdminEnsureDeleted(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "EnsureDeleted")]
        public ConceptDbResponse EnsureDeleted(string secId)
        {
            return _cptDb.EnsureDeleted(secId);
        }
    }
}
