using Corredores.Entities;
using Corredores.Models;
using Corredores.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Corredores.Controllers
{
    public class ReportesController : Controller
    {

        private readonly CorredoresServicio corredoresServicio;

        public ReportesController(CorredoresServicio corredoresServicio)
        {
            this.corredoresServicio = corredoresServicio;
        }



        // GET: Reportes
        public ActionResult Index()
        {
            var corredores = this.corredoresServicio.ObtenerCorredores();

            if (corredores.Count < 10) {
                TempData["CorredoresInvalidos"] = "Debe ingresar al menos 10 corredores para generar el reporte. Intente nuevamente";
                return RedirectToAction("Index", "Corredores");
            }

            foreach (var corredor in corredores) {
                if (corredor.Minutos == null || corredor.Segundos == null) {
                    TempData["CorredoresInvalidos"] = "Algunos jugadores no cuentan tiempos. Por favor edite el tiempo y vuelva a intentarg";
                    return RedirectToAction("Index", "Corredores");
                }

            }

            var corredoresModelo = corredores
                .Select(corredor => new CorredorModelo() { Nombre = corredor.CorredorNombre, Tiempos = $"{corredor.Minutos}:{corredor.Segundos}", Velocidad = CalcularVelocidad(corredor) });


            var listaDeMetricas = corredoresModelo.ToList().OrderByDescending ( corredor => Decimal.Parse(corredor.Velocidad) );
            var promedioVelocidad = listaDeMetricas.Average( corredor => Decimal.Parse(corredor.Velocidad) );

            var primero = listaDeMetricas.First();
            var ultimo = listaDeMetricas.Last();

            return View( new ReporteCorredores() {
                Corredores = corredoresModelo,
                PeorVelocidad = ultimo.Velocidad,
                MejorVelocidad =  primero.Velocidad, 
                VelocidadPromedio = promedioVelocidad.ToString("0.##")
            });
        }

        private string CalcularVelocidad(Corredor corredor)
        {
            decimal segundosTotales = (corredor.Minutos.Value * 60) + corredor.Segundos.Value;
            decimal resultado = 2000 / segundosTotales;
            return resultado.ToString("0.##");
        }
    }
}