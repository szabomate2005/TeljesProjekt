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
    
    public class VideokartyaModel
    {
        public string Nev { get; set; }
        public string alaplapiCsatlakozas { get; set; }
        public int ajanlottTapegyseg { get; set; }
        public string momonitorCsatlakozas { get; set; }
        public string chipGyartoja { get; set; }
        public int vram { get; set; }
    }
    public class VideokartyaController : ApiController
    {
        ProjektContext ctx = new ProjektContext();
        // GET api/<controller>
        [ResponseType(typeof(VideokartyaModel))]
        public HttpResponseMessage Get()
        {
                IEnumerable<VideokartyaModel> result = null;
                result = ctx.Videokartyak.Select(x=>new VideokartyaModel
                {
                    Nev=x.Nev,
                    alaplapiCsatlakozas=x.AlaplapiCsatlakozas,
                    ajanlottTapegyseg=x.AjanlottTapegyseg,
                    momonitorCsatlakozas=x.MonitorCsatlakozas,
                    chipGyartoja=x.ChipGyartoja,
                    vram=x.Vram
                }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }

        // GET api/<controller>/5
        [ResponseType(typeof(VideokartyaModel))]
        public HttpResponseMessage Get(int id,string name)
        {
            VideokartyaModel result = null;
            result = ctx.Videokartyak.Where(x => x.Nev == name).Select(x => new VideokartyaModel {
                Nev = x.Nev,
                alaplapiCsatlakozas = x.AlaplapiCsatlakozas,
                ajanlottTapegyseg = x.AjanlottTapegyseg,
                momonitorCsatlakozas = x.MonitorCsatlakozas,
                chipGyartoja = x.ChipGyartoja,
                vram = x.Vram
            }).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK,result);
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