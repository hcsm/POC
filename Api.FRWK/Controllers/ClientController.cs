using System;
using Domain.Entity.FRWK;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace Api.FRWK.Controllers
{
    [Consumes("application/json")]
    [Route("api/client")]
    public class ClientController : Controller
    {
        [HttpGet("{number}")]
        [Route("FRWKChallenge/{number}")]
        public IActionResult GetObjectChallenge(int number)
        {
            try
            {
                FRWKChallenge obj = NumericalOperations.DecomposeNumberMethod2(number);
                return Ok(obj);

            }
            catch (Exception Ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, Ex.Message);
                return result;
            }
        }
    }
}