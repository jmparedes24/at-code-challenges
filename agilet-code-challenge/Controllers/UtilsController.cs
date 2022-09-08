using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}