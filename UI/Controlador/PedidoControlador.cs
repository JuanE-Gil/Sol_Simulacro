using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using UI.Modelo;

namespace UI.Controlador
{
    public class PedidoControlador
    {
        private readonly DistribuidoraEntities distribuidoraDB = new DistribuidoraEntities();

        public void Insert(Pedidos pedido) {
            distribuidoraDB.Pedidos.Add(pedido);
            distribuidoraDB.SaveChanges();
        }

        public void update(Pedidos pedido) {
            Pedidos pedidoDB = distribuidoraDB.Pedidos.Find(pedido.num_pedido);

            distribuidoraDB.Entry(pedidoDB).CurrentValues.SetValues(pedido);
            distribuidoraDB.SaveChanges();
        }

        public void Delete(int num_pedido) {
            Pedidos pedidoDB = distribuidoraDB.Pedidos.Find(num_pedido);

            distribuidoraDB.Entry(pedidoDB).State = EntityState.Deleted;
            distribuidoraDB.SaveChanges();
        }

        public Pedidos FindByID(int num_pedido) {
            Pedidos pedidoDB = distribuidoraDB.Pedidos.Find(num_pedido);
            return pedidoDB;
        }

        public List<Pedidos> FindAll() {
            var query = from pedidos in distribuidoraDB.Pedidos
                        select pedidos;
            return query.ToList();
        }

    }
}
