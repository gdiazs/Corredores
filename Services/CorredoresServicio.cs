using Corredores.Entities;
using Corredores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corredores.Services
{
    public class CorredoresServicio
    {
        public List<Corredor> ObtenerCorredores() {
            using (var db = new CorredoresDBEntities()) {
                return db.Corredors.ToList();
            }
        }

        public void AgregarCorredor(Corredor corredor) {
            using (var db = new CorredoresDBEntities())
            {
                db.Corredors.Add(corredor);
                db.SaveChanges();
            }
        }

        public void EliminarCorredor(int corredorId)
        {
            using (var db = new CorredoresDBEntities())
            {
                var corredor = db.Corredors.Find(corredorId);
                db.Corredors.Remove(corredor);
                db.SaveChanges();
                
            }
        }

        public void AgregarTiemposDeCorredor(TiemposModelo tiemposModelo) {

            using (var db = new CorredoresDBEntities())
            {
                var corredor = db.Corredors.Find(tiemposModelo.CorredorID);
                corredor.Minutos = tiemposModelo.Minutos;
                corredor.Segundos = tiemposModelo.Segundos;
                db.SaveChanges();
            }
        }

        public ReporteCorredores GenerarReporteCorredores(IEnumerable<Corredor> corredores) {
            var corredoresModelo = corredores
                    .Select(corredor => new CorredorModelo() { Nombre = corredor.CorredorNombre, Tiempos = $"{corredor.Minutos}:{corredor.Segundos}", Velocidad = CalcularVelocidad(corredor) });


            var listaDeMetricas = corredoresModelo.ToList().OrderByDescending(corredor => Decimal.Parse(corredor.Velocidad));
            var promedioVelocidad = listaDeMetricas.Average(corredor => Decimal.Parse(corredor.Velocidad));

            var primero = listaDeMetricas.First();
            var ultimo = listaDeMetricas.Last();

            return new ReporteCorredores()
            {
                Corredores = corredoresModelo,
                PeorVelocidad = ultimo.Velocidad,
                MejorVelocidad = primero.Velocidad,
                VelocidadPromedio = promedioVelocidad.ToString("0.##")
            };

        }

        private string CalcularVelocidad(Corredor corredor)
        {
            decimal segundosTotales = (corredor.Minutos.Value * 60) + corredor.Segundos.Value;
            decimal resultado = 2000 / segundosTotales;
            return resultado.ToString("0.##");
        }

    }
}