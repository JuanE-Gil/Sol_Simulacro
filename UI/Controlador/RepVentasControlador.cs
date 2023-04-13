using System.Collections.Generic;
using System.Linq;

using UI.Modelo;

namespace UI.Controlador
{
    public class RepVentasControlador
    {
        private DistribuidoraEntities distribuidoraDB = new DistribuidoraEntities();

        public Repventas FindByID(int num_empl) {
            Repventas repVentasDB = distribuidoraDB.Repventas.Find(num_empl);
            return repVentasDB;
        }

        public List<Repventas> FindAll() {
            var query = from repVentas in distribuidoraDB.Repventas
                        select repVentas;
            return query.ToList();
        }
    }
}
