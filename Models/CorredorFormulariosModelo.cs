using Corredores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corredores.Models
{
    public class CorredorFormulariosModelo
    {
        public List<Corredor> Corredores { set; get; }
        public Corredor NuevoCorredor { set; get; }

        public TiemposModelo NuevoTiempoDeCorredor { set; get; }
}
}