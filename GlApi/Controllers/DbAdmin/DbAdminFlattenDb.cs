using ConceptDbLib;
using GlApi.Controllers.Builder;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.DbAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbAdminFlattenDb : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        public DbAdminFlattenDb(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "FlattenDB")]
        public ConceptDbResponse FlattenDb(string secId)
        {
            return _cptDb.FlattenDb(secId);
        }
    }
}
