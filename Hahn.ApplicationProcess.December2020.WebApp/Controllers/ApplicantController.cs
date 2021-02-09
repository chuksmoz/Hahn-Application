using Hahn.ApplicationProcess.December2020.Application.Handlers.Commands;
using Hahn.ApplicationProcess.December2020.Application.Handlers.Queries;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Applicant>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllApplicantQuery()));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetApplicantByIdQuery { ID = id }));
        }

        [HttpPost]
        //[SwaggerRequestExample(typeof(DeliveryOptionsSearchModel), typeof(DeliveryOptionsSearchModelExample))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] AddAplicantCommand command)
        {
            var applicant = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { ID = applicant.ID }, applicant);
            //return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateApplicantCommand command)
        {            
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {            
            return Ok(await Mediator.Send(new DeleteApplicantCommand { ID = id }));
        }
    }
}
