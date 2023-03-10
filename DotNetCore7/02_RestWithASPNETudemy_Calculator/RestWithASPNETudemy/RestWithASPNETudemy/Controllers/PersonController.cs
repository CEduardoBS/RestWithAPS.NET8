using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using RestWithASPNETudemy.Model;
using RestWithASPNETudemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetCore5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        CredentialCache credCache = new CredentialCache();
        
        [HttpGet]
        public IActionResult Get ()
        {
            string user = "admin";
            string secret = "GuiMcz2022";
            var domain = "http://10.0.4.240/";
            var person = _personBusiness.FindAll();

            credCache.Add(new Uri(domain), "Digest", new NetworkCredential(user, secret));
            var httpClient = new HttpClient(new HttpClientHandler { Credentials = credCache });
            //var answer = httpClient.GetAsync(new Uri($"{domain}cgi-bin/accessControl.cgi?action=openDoor&channel=1&UserID=1&Type=Remote"));

            return Ok(person);
            //return Redirect("http://10.0.4.240/cgi-bin/accessControl.cgi?action=openDoor&channel=1&UserID=1&Type=Remote");
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delet(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }


    }
}
