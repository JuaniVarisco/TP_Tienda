namespace TP_Tienda
{
    class Producto
    {
        private string nombre = "";
        private double costo;
        private int stock = 0;

        public Producto(string name, double cost, int stock1)
        {
            nombre = name;
            costo = cost;
            stock = stock1;
        }

        public double precioVenta()
        {
            return costo * 1.3;
        }

        public void tomarStock(int c)
        {
            if (c <= stock)
            {
                stock -= c;
            }

            else
            {
                Console.WriteLine("Solo queda/n {0} {1}/s", stock, nombre);
            }
        }

        public int getStock()
        {
            return stock;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void agregarStock(int c)
        {
            stock += c;
        }
    }
}