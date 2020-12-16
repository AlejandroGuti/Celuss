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
    public class IPSsController : ControllerBase
    {


            private readonly IIPSService _iPSService;

            public IPSsController(IIPSService iPSService)
            {
            _iPSService = iPSService;
            }

            [HttpPost("Create")]
            public async Task<ActionResult> Create([FromBody] IPSRequest model)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    return Ok(await _iPSService.Create(model));

                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            [HttpGet()]
            public async Task<ActionResult> FindProjectList()
            {


                try
                {

                    return Ok(await _iPSService.FindAll());
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
                    return Ok(await _iPSService.FindById(request.Id));

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
                    return Ok(await _iPSService.Delete(request.Id));

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
            public async Task<ActionResult> Update([FromRoute] int id, [FromBody] IPSRequest request)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    if (id > 0)
                    {
                        return Ok(await _iPSService.Update(id, request));
                    }
                    else
                    {
                        return BadRequest();
                    }




                }
                catch (Exception ex)
                {
                    Exception j = ex;
                    return BadRequest();
                }

            
        }
    }
}
