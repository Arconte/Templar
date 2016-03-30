using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Templar.Domain.Services.Services;

namespace Templar.Rest.Service.Imp
{
    [RoutePrefix("api/clues")]
    public class CluesController : ApiController
    {
        private IClueDomainService ClueDomainService;
        public CluesController(IClueDomainService ClueDomainService)
        {
            this.ClueDomainService = ClueDomainService; 
        }
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok();  
        }
    }
}
