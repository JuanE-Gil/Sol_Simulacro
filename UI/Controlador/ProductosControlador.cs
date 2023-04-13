using System.Collections.Generic;
using System.Linq;

using UI.Modelo;

namespace UI.Controlador
{
    public class ProductosControlador
    {
        private readonly DistribuidoraEntities distribuidoraDB = new DistribuidoraEntities();

        public Productos FindByID(int id_producto) {
            Productos productosDB = distribuidoraDB.Productos.Find(id_producto);
            return productosDB;
        }

        public List<Productos> FindAll() {
            var query = from productos in distribuidoraDB.Productos
                        select productos;
            return query.ToList();
        }
    }
}
