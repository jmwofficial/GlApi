using ConceptDbLib;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuilderNew : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        private readonly string _secId = Guid.NewGuid().ToString();
        public BuilderNew(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _logger.Log(LogLevel.Warning, string.Format("Builder SecId:\t", _secId));
            _cptDb = cptDb;
        }

        [HttpGet(Name = "NewBuilder")]
        public ConceptDbResponse Get(string libName)
        {
            return _cptDb.NewBuilder(libName);
        }
    }
}
