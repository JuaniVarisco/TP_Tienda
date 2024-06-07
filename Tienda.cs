namespace TP_Tienda
{
    class Tienda
    {
        private List<Producto> productos = new List<Producto>();
        private double caja = 0;

        public double getCaja()
        {
            return caja;
        }

        public void agregarProducto(Producto product)
        {
            productos.Add(product);
        }

        public void eliminarProducto(Producto prduct)
        {
            productos.Remove(prduct);
        }

        public List<Producto> getProductos()
        {
            return productos;
        }

        public Producto getProducto(string nombre)
        {
            foreach (Producto p in productos) { 
                if (p.getNombre() == nombre)
                {
                    return p;
                }
            }
            return null;
        }

        public void mostrarProductos()
        {
            foreach (Producto product in productos)
            {
                Console.WriteLine("Producto : {0} ; Stock : {1} ; Precio :{2}\n", product.getNombre(), product.getStock(), Math.Round(product.precioVenta(), 2));
            }
        }

        public double cobrar(double pago, double importe)
        {
            if (pago >= importe)
            {
                caja += importe;
                return pago - importe;
            }
            else
            {
                return -1;
            }
        }
    }
}
