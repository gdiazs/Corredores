using Corredores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corredores.Models
{
    public class ReporteCorredores
    {

        public IEnumerable<CorredorModelo> Corredores { set; get; }

        public string MejorVelocidad { set; get; }

        public string PeorVelocidad { set; get; }

        public string VelocidadPromedio { set; get; }
    }
}