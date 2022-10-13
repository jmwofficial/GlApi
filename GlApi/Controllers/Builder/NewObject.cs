using ConceptDbLib;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewObject : ControllerBase
    {
        private readonly ILogger<BuilderNew> _logger;
        private readonly IConceptDb _cptDb;
        public NewObject(ILogger<BuilderNew> logger, IConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }

        [HttpGet(Name = "NewObject")]
        public async Task<ConceptDbResponse> Get(string builderId, string libraryName, string objName)
        {
            return await _cptDb.NewObjectAsync(builderId, libraryName, objName);
        }
    }
}
