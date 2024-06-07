using System.ComponentModel.DataAnnotations;

namespace TP_Tienda
{
    internal class Carrito
    {
        private List<(Producto, int)> carrito = new List<(Producto, int)>();

        private double subtotal = 0;

        public void resetCarrito()
        {
            carrito.Clear();
            subtotal = 0;
        }

        public void agregar(Producto prd, int cantidad, Tienda tienda)
        {
            if (tienda.getProductos().IndexOf(prd) != -1)
            {
                if (prd.getStock() >= cantidad)
                {
                    carrito.Add((prd, cantidad));
                    prd.tomarStock(cantidad);
                    subtotal += cantidad * prd.precioVenta();
                }

                else
                {
                    Console.WriteLine("No hay suficiente stock \n");
                }
            }
            else
            {
                Console.WriteLine("El producto no se encuentra en la tienda");
            }
        }

        public void eliminar(Producto prd, int cantidad)
        {
            if (carrito.IndexOf((prd, cantidad)) != -1)
            {
                carrito.Remove((prd, cantidad));
                subtotal -= cantidad * prd.precioVenta();
                prd.agregarStock(cantidad);
            }
            else
            {
                Console.WriteLine("No tienes ese producto en el carrito \n");
            }
        }

        public double getSubtotal()
        {
            return subtotal;
        }

        public void mostrarCarrito()
        {
            foreach ((Producto, int) product in carrito)
            {
                Console.WriteLine("Producto: {0}; Cantidad: {1}; Precio unitario: {2}", product.Item1.getNombre(), product.Item2, Math.Round(product.Item1.precioVenta(), 2));
                Console.WriteLine("Subtotal: {0}", Math.Round((product.Item1.precioVenta() * product.Item2), 2));
            }
            Console.WriteLine("Total: {0}", subtotal);
        }
    }
}
