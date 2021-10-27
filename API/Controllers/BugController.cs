using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly StoreContext _context;
        public BugController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfind")]
        public ActionResult GetNotFindRequest()
        {
            return Ok();
        }
    }
}