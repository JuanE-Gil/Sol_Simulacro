//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI.Modelo
{
    using System;
    using System.Collections.Generic;

    public partial class Pedidos
    {

        public Pedidos(decimal num_pedido, DateTime fecha_pedido, decimal clie, decimal rep, string fab, string producto, decimal cant, double importe) {
            this.num_pedido = num_pedido;
            this.fecha_pedido = fecha_pedido;
            this.clie = clie;
            this.rep = rep;
            this.fab = fab;
            this.producto = producto;
            this.cant = cant;
            this.importe = importe;
        }

        public Pedidos() {
        }

        public decimal num_pedido { get; set; }
        public System.DateTime fecha_pedido { get; set; }
        public decimal clie { get; set; }
        public decimal rep { get; set; }
        public string fab { get; set; }
        public string producto { get; set; }
        public decimal cant { get; set; }
        public double importe { get; set; }

        public virtual Clientes Clientes { get; set; }
        public virtual Productos Productos { get; set; }
        public virtual Repventas Repventas { get; set; }
    }
}
