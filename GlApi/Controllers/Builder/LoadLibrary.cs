using ConceptDbLib;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadLibrary : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        public LoadLibrary(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "LoadLibrary")]
        public async Task<ConceptDbResponse> Get(string secId, string libraryName)
        {
            return await _cptDb.LoadLibraryAsync(secId, libraryName);
        }
    }
}
