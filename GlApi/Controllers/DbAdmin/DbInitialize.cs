﻿using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GlApi.Controllers.DbAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbInitialize : ControllerBase
    {
        private readonly ILogger<DbInitialize> _logger;
        private readonly ConceptDb _cptDb;
        public DbInitialize(ILogger<DbInitialize> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _cptDb = cptDb;
        }
        [HttpGet(Name = "DbInitialize")]
        public async Task<ConceptDbResponse> Get(string confirmId)
        {
            ConceptDbResponse response = await _cptDb.DbInitializeAsync(confirmId);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
