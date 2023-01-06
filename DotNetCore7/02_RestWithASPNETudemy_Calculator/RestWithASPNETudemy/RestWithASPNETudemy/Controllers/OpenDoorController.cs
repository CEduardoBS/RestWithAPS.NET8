using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RestWithASPNETudemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class OpenDoorController : ControllerBase
    {

        private readonly ILogger<OpenDoorController> _logger;

        public OpenDoorController(ILogger<OpenDoorController> logger)
        {
            _logger = logger;
        }

        static readonly HttpClient client = new HttpClient();
        
        CredentialCache credCache = new CredentialCache();


        [HttpGet]
        public IActionResult Door()
        {
            string user = "admin";
            string secret = "GuiMcz2022";
            var domain = "http://10.0.4.240/";

            credCache.Add(new Uri(domain), "Digest", new NetworkCredential(user, secret));
            var httpClient = new HttpClient(new HttpClientHandler { Credentials = credCache });
            var answer = httpClient.GetAsync(new Uri($"{domain}cgi-bin/accessControl.cgi?action=openDoor&channel=1&UserID=1&Type=Remote"));    

            return Ok();

        }

    }
}