using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webapiproj.Models
{
    public class Csatlakozo
    {
        [Key]
        public int Id { get; set; }
        public string Nev { get; set; }

    }
}