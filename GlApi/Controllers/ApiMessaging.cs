using CptClientShared;
using Newtonsoft.Json;

namespace GlApi.Controllers
{
    public static class ApiMessaging
    {
        public static string LogMessage = "Request Received. Logging Result.";
        public static string ResponseToString(ConceptDbResponse response) => JsonConvert.SerializeObject(response) ?? string.Empty;
    }
}
