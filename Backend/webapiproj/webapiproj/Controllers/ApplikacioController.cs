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
    public class ApplikacioModel
    {
        public string AppNev { get; set; }
        public string KategoriaNev { get; set; }
        public string VidekortyaNev { get; set; }
        public int VideokartyaVram { get; set; }
        public string ProcesszorNev { get; set; }
        public int ProcesszorSzalakSzama { get; set; }
        public int ProcesszorMagokSzama { get; set; }
        public double ProcesszorFrekvencia { get; set; }
        public double RamFrekvencia { get; set; }
        public int RamMeret { get; set; }
        public string OprendszerNev { get; set; }
        public int Tarhely { get; set; }
    }
    public class ApplikacioController : ApiController
    {
        ProjektContext ctx = new ProjektContext();
        // GET api/<controller>
        [ResponseType(typeof(ApplikacioModel))]
        public HttpResponseMessage Get()
        {
            IEnumerable<ApplikacioModel> result = null;
            result = ctx.Applikaciok.Include(x=>x.Kategoria).Include(x=>x.Setup).Select(x=>new ApplikacioModel
            { 
                AppNev=x.Nev,
                KategoriaNev=x.Kategoria.Nev,
                VidekortyaNev=x.Setup.Videokartya.Nev,
                VideokartyaVram=x.Setup.Videokartya.Vram,
                ProcesszorNev=x.Setup.Processzor.Nev,
                ProcesszorSzalakSzama=x.Setup.Processzor.SzalakSzama,
                ProcesszorMagokSzama=x.Setup.Processzor.ProcesszormagokSzama,
                ProcesszorFrekvencia=x.Setup.Processzor.ProcesszorFrekvencia,
                RamMeret=x.Setup.Ram.Meret,
                RamFrekvencia=x.Setup.Ram.Frekvencia,
                OprendszerNev=x.Setup.Oprendszer.Nev,
                Tarhely=x.Tarhely
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }

        // GET api/<controller>/5
        [ResponseType(typeof(ApplikacioModel))]
        public HttpResponseMessage Get(int id,string name)
        {
            ApplikacioModel result = null;
            result = ctx.Applikaciok.Include(x => x.Kategoria).Include(x => x.Setup).Where(x=>x.Nev==name).Select(x => new ApplikacioModel
            {
                KategoriaNev = x.Kategoria.Nev,
                VidekortyaNev = x.Setup.Videokartya.Nev,
                VideokartyaVram = x.Setup.Videokartya.Vram,
                ProcesszorNev = x.Setup.Processzor.Nev,
                ProcesszorSzalakSzama = x.Setup.Processzor.SzalakSzama,
                ProcesszorMagokSzama = x.Setup.Processzor.ProcesszormagokSzama,
                ProcesszorFrekvencia = x.Setup.Processzor.ProcesszorFrekvencia,
                RamMeret = x.Setup.Ram.Meret,
                RamFrekvencia = x.Setup.Ram.Frekvencia,
                OprendszerNev = x.Setup.Oprendszer.Nev,
                Tarhely = x.Tarhely
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