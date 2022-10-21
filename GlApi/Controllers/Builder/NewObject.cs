﻿using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewObject : ControllerBase
    {
        private readonly ILogger<NewObject> _logger;
        private readonly ConceptDb _cptDb;
        public NewObject(ILogger<NewObject> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "NewObject")]
        public async Task<ConceptDbResponse> Get(string builderId, string libName, string objName)
        {

            ConceptDbResponse response = await _cptDb.NewObjectAsync(builderId, libName, objName);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
