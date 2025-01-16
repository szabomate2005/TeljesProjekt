﻿using System;
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
    public class ApplikacioProfilModel
    {
        public string UserName { get; set; }
        public string ApplikacioNeve { get; set; }
    }
    public class Applikacio_ProfilController : ApiController
    {
        ProjektContext ctx = new ProjektContext();
        // GET api/<controller>
        [ResponseType(typeof(AlaplapModel))]
        public HttpResponseMessage Get()
        {
            IEnumerable<ApplikacioProfilModel> result = null;
            result = ctx.Applikacio_Profilok.Include(x => x.Applikacio).Include(x => x.Profil).Select(x=>new ApplikacioProfilModel {
                UserName=x.Profil.Felhasznalonev,
                ApplikacioNeve=x.Applikacio.Nev
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET api/<controller>/5
        [ResponseType(typeof(AlaplapModel))]
        public HttpResponseMessage Get(int id,string name)
        {
            ApplikacioProfilModel result = null;
            result = ctx.Applikacio_Profilok.Include(x => x.Applikacio).Include(x => x.Profil).Where(x => x.Applikacio.Nev == name).Select(x=>new ApplikacioProfilModel {
                UserName = x.Profil.Felhasznalonev,
                ApplikacioNeve = x.Applikacio.Nev
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
