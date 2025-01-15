﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapiproj.Models
{
    public class Alaplap_Csatlakozo
    {


        [Column("AlaplapId")]
        public int AlaplapId { get; set; }
        [Column("CsatlakozoId")]
        public int CsatlakozoId { get; set; }
        [ForeignKey("CsatlakozoId")]
        public virtual Csatlakozo Csatlakozo { get; set; }
        [ForeignKey("AlaplapId")]
        public virtual Alaplap Alaplap { get; set; }


        ////csatlakozo kapcsolat
        //[ForeignKey("Csatlakozo")]
        //[Column("Id")]
        //public int CsatlakozoId { get; set; }
        //public virtual Csatlakozo Csatlakozok { get; set; }
        ////alaplap kapcsolat
        //[ForeignKey("Alaplap")]
        //[Column("Id")]
        //public int AlaplapId { get; set; }
        //public virtual Alaplap Alaplapok { get; set; }
    }
}