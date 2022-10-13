using ConceptDbLib;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewLibrary : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        public NewLibrary(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "NewLibrary")]
        public async Task<ConceptDbResponse> Get(string builderId, string libraryName)
        {
            return await _cptDb.NewLibraryAsync(builderId, libraryName);
        }
    }
}
