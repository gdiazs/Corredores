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
    }
}