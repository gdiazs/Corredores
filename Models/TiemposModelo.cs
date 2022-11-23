using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Corredores.Models
{
    public class TiemposModelo
    {
        public int CorredorID { set; get; }

        [Required]
        public int Minutos { set; get; }

        [Required]
        public int Segundos { set; get; }
    }
}