using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agilet_code_challenge.Models;
using agilet_code_challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace agilet_code_challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilsController : ControllerBase
    {
        public readonly IUtilsService _service;
        public UtilsController(IUtilsService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ServiceResponse<string[]>> GetSortedNames(NamesArray namesArray)
        {
            var response = _service.OrganizedArray(namesArray.Names, namesArray.Order);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(response);
        }
    }
}