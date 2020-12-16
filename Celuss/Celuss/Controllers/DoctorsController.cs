using Celuss.Domain.DTOs;
using Celuss.Domain.Responses;
using Celuss.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Celuss.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

            private readonly IDoctorService _doctorService;

            public DoctorsController(IDoctorService doctorService)
            {
            _doctorService = doctorService;
            }

            [HttpPost("Create")]
            public async Task<ActionResult> Create([FromBody] DoctorRequest model)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    return Ok(await _doctorService.Create(model));

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

                    return Ok(await _doctorService.FindAll());
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

                    return Ok(await _doctorService.FindAllPIPS(requestId));
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
                    return Ok(await _doctorService.FindById(request.Id));

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
                    return Ok(await _doctorService.Delete(request.Id));

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
            public async Task<ActionResult> Update([FromRoute] int id,
                [FromBody] DoctorRequest request)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    if (id > 0)
                    {
                        return Ok(await _doctorService.Update(id, request));
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
