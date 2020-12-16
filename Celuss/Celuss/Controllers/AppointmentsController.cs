using Celuss.Domain.DTOs;
using Celuss.Domain.Responses;
using Celuss.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Celuss.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] AppointmentRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _appointmentService.Create(model));

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet()]
        public async Task<ActionResult> FindTaskList()
        {


            try
            {

                return Ok(await _appointmentService.FindAll());
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet("AllPProject")]
        public async Task<ActionResult> FindAllPIPS([FromBody] RequestId requestId)
        {
            try
            {

                return Ok(await _appointmentService.FindAllPIPS(requestId));
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet("FindById")]
        public async Task<ActionResult> FindById([FromBody] RequestId request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _appointmentService.FindById(request.Id));

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] RequestId request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _appointmentService.Delete(request.Id));

            }
            catch (Exception ex)
            {

                return BadRequest(new Response
                {
                    IsSuccess = true,
                    Message = ex.Message

                });
            }

        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] AppointmentRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id > 0)
                {
                    return Ok(await _appointmentService.Update(id, request));
                }
                else
                {
                    return BadRequest();
                }




            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



    }
}
