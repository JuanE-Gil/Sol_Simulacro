using System.Collections.Generic;
using System.Linq;

using UI.Modelo;

namespace UI.Controlador
{
    public class ClienteControlador
    {
        private readonly DistribuidoraEntities distribuidoraDB = new DistribuidoraEntities();

        public Clientes FindByID(int num_cliente) {
            Clientes clienteDB = distribuidoraDB.Clientes.Find(num_cliente);
            return clienteDB;
        }

        public List<Clientes> FindAll() {
            var query = from clientes in distribuidoraDB.Clientes
                        select clientes;
            return query.ToList();
        }
    }
}
