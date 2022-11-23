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
    public class CorredoresController : Controller
    {

        private readonly CorredoresServicio corredoresServicio;

        public CorredoresController(CorredoresServicio corredoresServicio)
        {
            this.corredoresServicio = corredoresServicio;
        }

        public ActionResult Index()
        {
            var corredores = this.corredoresServicio.ObtenerCorredores();
            var corredorModelo = new CorredorFormulariosModelo() { Corredores = corredores};

            return View(corredorModelo);
        }


        [HttpPost]
        public ActionResult Agregar(CorredorFormulariosModelo corredorModelo)
        {
            if (ModelState.IsValid) {
                this.corredoresServicio.AgregarCorredor(corredorModelo.NuevoCorredor);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {

            this.corredoresServicio.EliminarCorredor(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AgregarTiempos(CorredorFormulariosModelo formulariosModelo)
        {
            if (ModelState.IsValid)
            {
                this.corredoresServicio.AgregarTiemposDeCorredor(formulariosModelo.NuevoTiempoDeCorredor);
            }
            

            return RedirectToAction("Index");
        }
    }
}