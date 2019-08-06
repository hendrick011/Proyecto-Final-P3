using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Producto producto { get; set; }
        public Cliente cliente { get; set; }
        public Empleado empleado { get; set; }
    }
}
