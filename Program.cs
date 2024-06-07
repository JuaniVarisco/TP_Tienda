using TP_Tienda;

namespace TP_Tienda
{
    class Program
    {
        public static void Main()
        {
            // revisar private public
            Tienda tienda = new Tienda();
            Carrito carrito = new Carrito();

            tienda.agregarProducto(new Producto("Leche", 20, 20));
            tienda.agregarProducto(new Producto("Jugo", 30, 50));
            tienda.agregarProducto(new Producto("Alfajor", 15, 40));

            bool vendedor = false;
            bool cliente = false;
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Seleccione: \n1 para ingresar como vendedor \n2 para ingresar como cliente \n3 para salir del programa\n");
                string rol = Console.ReadLine();

                switch (rol)
                {
                    case "1":
                        vendedor = true;
                        break;
                    case "2":
                        cliente = true;
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                while (vendedor)
                {
                    Console.WriteLine("\n--------Menu--------\n");
                    Console.WriteLine("1. Mostrar productos");
                    Console.WriteLine("2. Agregar producto a la tienda");
                    Console.WriteLine("3. Eliminar producto de la tienda");
                    Console.WriteLine("4. Añadir Stock a un producto");
                    Console.WriteLine("5. Reducir Stock a un producto");
                    Console.WriteLine("6. Ver dinero");
                    Console.WriteLine("7. Salir");
                    Console.WriteLine("Seleccione una opcion: ");

                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            tienda.mostrarProductos();
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el nombre del producto: ");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el precio del producto: ");
                            double precio = double.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese el stock del producto: ");
                            int stock = int.Parse(Console.ReadLine());

                            tienda.agregarProducto(new Producto(nombre, precio, stock));
                            break;
                        case 3:
                            Console.WriteLine("Ingrese el nombre del producto que desea eliminar: ");
                            string indiceEliminar = Console.ReadLine();
                            Producto productoEliminar = tienda.getProducto(indiceEliminar);

                            if (productoEliminar == null)
                            {
                                Console.WriteLine("El producto no está en la tienda");
                            }
                            else
                            {
                                tienda.eliminarProducto(productoEliminar);
                            }
                            break;
                        case 4:
                            Console.WriteLine("Ingrese el nombre del producto que desea añadir stock: ");
                            string indiceStock = Console.ReadLine();
                            Producto productoStock = tienda.getProducto(indiceStock);

                            if (productoStock == null)
                            {
                                Console.WriteLine("El producto no está en la tienda");
                            }
                            else
                            {
                                Console.WriteLine("Cuantos productos desea añadir: ");
                                int cantidadStock = int.Parse(Console.ReadLine());

                                productoStock.agregarStock(cantidadStock);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Ingrese el nombre del producto que desea reducir stock: ");
                            string nombreEliminar = Console.ReadLine();
                            Producto productoReducir = tienda.getProducto(nombreEliminar);

                            if (productoReducir == null)
                            {
                                Console.WriteLine("El producto no está en la tienda");
                            }
                            else
                            {
                                Console.WriteLine("Cuanta cantidad desea reducir: ");
                                int cantidadReducir = int.Parse(Console.ReadLine());
                                productoReducir.tomarStock(cantidadReducir);
                            }
                            break;
                        case 6:
                            Console.WriteLine("Dinero en caja: {0}", Math.Round(tienda.getCaja(), 2));
                            break;
                        case 7:
                            vendedor = false;
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                }

                while (cliente)
                {
                    Console.WriteLine("\n--------Menu--------\n");
                    Console.WriteLine("1. Mostrar productos");
                    Console.WriteLine("2. Agregar producto al carrito");
                    Console.WriteLine("3. Eliminar producto del carrito");
                    Console.WriteLine("4. Mostrar carrito");
                    Console.WriteLine("5. Pagar");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine("Seleccione una opcion: ");

                    int opcion = int.Parse(Console.ReadLine());

                    Console.WriteLine("\n");

                    switch (opcion)
                    {
                        case 1:
                            tienda.mostrarProductos();
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el nombre del producto: ");
                            string indice = Console.ReadLine();

                            Console.WriteLine("Ingrese la cantidad: ");
                            int cantidad = int.Parse(Console.ReadLine());

                            if (cantidad <= 0 || tienda.getProducto(indice) == null)
                            {
                                Console.WriteLine("Producto o cantidad no valido \n");
                            }
                            else
                            {
                                carrito.agregar(tienda.getProducto(indice), cantidad, tienda);
                            }
                            brea
                        case 3: // solo se puede eliminar la orden total de un producto, o sea la cantidad exacta que se agrego en un inicio
                            Console.WriteLine("Ingrese el nombre del producto que desea eliminar: ");
                            string indiceEliminar = Console.ReadLine();
                            Console.WriteLine("Ingrese la cantidad que desea eliminar");
                            int cantidadE = int.Parse(Console.ReadLine());

                            carrito.eliminar(tienda.getProducto(indiceEliminar), cantidadE);
                            break;
                        case 4:
                            carrito.mostrarCarrito();
                            break;
                        case 5:
                            Console.WriteLine("Monto a pagar: {0} \n", Math.Round(carrito.getSubtotal(), 2));
                            Console.WriteLine("Ingrese el dinero con el que va a pagar: ");
                            double dineroPagado = double.Parse(Console.ReadLine());

                            if (tienda.cobrar(dineroPagado, carrito.getSubtotal()) == -1)
                            {
                                Console.WriteLine("Dinero insuficiente \n");
                            }

                            else
                            {
                                if (tienda.cobrar(dineroPagado, carrito.getSubtotal()) == 0)
                                {
                                    Console.WriteLine("No requiere vuelto, el monto es exacto \n");

                                    carrito.resetCarrito();
                                }

                                else
                                {
                                    Console.WriteLine("Su vuelto es de {0} \n", Math.Round(tienda.cobrar(dineroPagado, carrito.getSubtotal()), 2));
                                    carrito.resetCarrito();
                                }
                            }
                            
                            
                            break;
                        case 6:
                            cliente = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                Console.Clear(); 
            }
        }
    }
}


