using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
