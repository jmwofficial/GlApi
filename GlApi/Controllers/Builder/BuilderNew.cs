﻿using ConceptDbLib;
using CptClientShared;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlApi.Controllers.Builder
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewBuilder : ControllerBase
    {
        private readonly ILogger<NewBuilder> _logger;
        private readonly ConceptDb _cptDb;
        private readonly string _secId = Guid.NewGuid().ToString();
        public NewBuilder(ILogger<NewBuilder> logger, ConceptDb cptDb)
        {
            _logger = logger;
            _logger.Log(LogLevel.Warning, string.Format("Builder SecId:\t", _secId));
            _cptDb = cptDb;
        }

        [HttpGet(Name = "NewBuilder")]
        public async Task<ConceptDbResponse> Get(string username, string password)
        {
            username = WebUtility.UrlDecode(username);
            password = WebUtility.UrlDecode(password);
            ConceptDbResponse response = await _cptDb.NewBuilderAsync(username, password);
            _logger.LogWarning(ApiMessaging.LogMessage);
            _logger.LogWarning(ApiMessaging.ResponseToString(response));
            return response;
        }
    }
}
