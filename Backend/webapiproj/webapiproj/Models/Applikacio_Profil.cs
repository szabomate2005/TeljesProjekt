using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapiproj.Models
{
    public class Applikacio_Profil
    {
        [Column("AppId")]
        public int AppId { get; set; }
        [Column("ProfilId")]
        public int ProfilId { get; set; }
        [ForeignKey("AppId")]
        public virtual Applikacio Applikacio { get; set; }
        [ForeignKey("ProfilId")]
        public virtual Profil Profil { get; set; }

        ////app kapcsolat
        //[ForeignKey("Csatlakozo")]
        //[Column("Id")]
        //public int AppId { get; set; }
        //public virtual Applikacio Applikacio { get; set; }

        //[ForeignKey("Csatlakozo")]
        //[Column("Id")]
        ////profil kapcsolat
        //public int ProfilId { get; set; }
        //public virtual Profil Profil { get; set; }
    }
}