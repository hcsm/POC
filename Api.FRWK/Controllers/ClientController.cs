using Domain.Entity.FRWK;
using System;
using System.Web.Http;
using System.Web.Http.Description;
using Utilities;

namespace Api.FRWK.Controllers
{
    [RoutePrefix("Client")]
    public class ClientController : ApiController
    {
        [HttpPost]
        [Route("FRWKChallenge")]
        [ResponseType(typeof(FRWKChallenge))]
        public IHttpActionResult GetObjectChallenge(int number)
        {
            try
            {
                FRWKChallenge obj = NumericalOperations.DecomposeNumberMethod2(number);
                return Ok(obj);

            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }
    }
}
