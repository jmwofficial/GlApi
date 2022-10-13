using ConceptDbLib;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class DumpLibrary : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        public DumpLibrary(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DumpLibrary")]
        public async Task<ConceptDbResponse> Get(string builderId, string libraryName)
        {
            return await _cptDb.DumpLibraryAsync(builderId, libraryName);
        }
    }
}
