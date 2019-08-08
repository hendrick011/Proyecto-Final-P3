using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Producto Producto { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
    }
}
