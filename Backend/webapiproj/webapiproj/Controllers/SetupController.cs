using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using webapiproj.Models;
using System.Web.Http.Description;

namespace webapiproj.Controllers
{
    public class SetupModel
    {
        public string Vidknev { get; set; }
        public string Processzornev { get; set; }
        public string Ramnev { get; set; }
        public string Oprendszernev { get; set; }
    }
    public class SetupController : ApiController
    {
        ProjektContext ctx = new ProjektContext();
        // GET api/<controller>
        [ResponseType(typeof(SetupModel))]
        public HttpResponseMessage Get()
        {
            IEnumerable<SetupModel> result = null;
            result = ctx.Setupok.Include(x => x.Alaplap).Include(x => x.Oprendszer).Include(x => x.Processzor).Include(x => x.Ram).Include(x => x.Videokartya).Select(x => new SetupModel
            {
                Vidknev=x.Videokartya.Nev,
                Processzornev=x.Processzor.Nev,
                Ramnev=x.Ram.Nev,
                Oprendszernev=x.Oprendszer.Nev
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }

        // GET api/<controller>/5
        [ResponseType(typeof(SetupModel))]
        public HttpResponseMessage Get(int id)
        {
            SetupModel result = null;
            result = ctx.Setupok.Include(x => x.Alaplap).Include(x => x.Oprendszer).Include(x => x.Processzor).Include(x => x.Ram).Include(x => x.Videokartya).Where(x=>x.Id==id).Select(x=>new SetupModel
            {
                Vidknev = x.Videokartya.Nev,
                Processzornev = x.Processzor.Nev,
                Ramnev = x.Ram.Nev,
                Oprendszernev = x.Oprendszer.Nev
            }).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
