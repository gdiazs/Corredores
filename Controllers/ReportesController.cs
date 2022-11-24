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

            return View(this.corredoresServicio.GenerarReporteCorredores(corredores));
        }
    }
}