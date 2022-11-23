using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corredores.Models
{
    public class CorredorModelo
    {
        public string Nombre { set; get; }
        public string Velocidad { set; get; }
        public string Tiempos { get; internal set; }
    }
}