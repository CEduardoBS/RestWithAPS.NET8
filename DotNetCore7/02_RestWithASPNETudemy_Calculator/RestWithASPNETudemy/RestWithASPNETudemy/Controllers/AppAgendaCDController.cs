using Microsoft.AspNetCore.Mvc;
using RestWithASPNETudemy.Business;
using RestWithASPNETudemy.Model;
using System.Reflection.Metadata.Ecma335;

namespace RestWithASPNETudemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AppAgendaCDController : ControllerBase
    {
        private readonly ILogger<AppAgendaCDController> _logger;

        private IAppAgendaCDBusiness _agendaBusiness;

        public AppAgendaCDController(ILogger<AppAgendaCDController> logger, IAppAgendaCDBusiness agendaBusiness)
        {
            _logger = logger;
            _agendaBusiness = agendaBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var agendaCD = _agendaBusiness.FindAll();
            return Ok(agendaCD);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var agendaCD = _agendaBusiness.FindById(id);
            if (agendaCD == null) return BadRequest();
            return Ok(agendaCD);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AppAgendaCD agendaCD)
        {
            if (agendaCD == null) return BadRequest();
            return Ok(_agendaBusiness.Create(agendaCD));
        }

        [HttpPut]
        public IActionResult Put([FromBody] AppAgendaCD agendaCD)
        {
            if (agendaCD == null) return BadRequest();
            return Ok(_agendaBusiness.Update(agendaCD));
        }

        [HttpDelete("{id}")]
        public IActionResult Delet(long id)
        {
            _agendaBusiness.Delete(id);
            return NoContent();
        }
    }
}
