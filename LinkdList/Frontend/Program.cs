using Backend;

internal class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList<string> list =
         new DoublyLinkedList<string>();

        int option = -1;

        do
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine(" TALLER 5 - LISTAS DOBLEMENTE LIGADAS");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Adicionar");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atras");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar la(s) moda(s)");
            Console.WriteLine("6. Mostrar grafico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.WriteLine("======================================");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(
                Console.ReadLine(), out option))
            {
                Console.WriteLine("Ingrese una opcion valida.");
                option = -1;
                continue;
            }

            String value;

            switch (option)
            {
                case 1:
                    Console.Write("Ingrese un valor: ");

                    value = Console.ReadLine() ?? "";

                    list.Add(value);

                    Console.WriteLine(
                        "Elemento agregado correctamente.");

                    Console.Write("Lista actual: ");
                    list.DisplayForward();

                    break;

                case 2:
                    Console.WriteLine(
                        "\nRECORRIDO HACIA ADELANTE");

                    list.DisplayForward();
                    break;

                case 3:
                    Console.WriteLine(
                        "\nRECORRIDO HACIA ATRAS");

                    list.DisplayBackward();
                    break;

                case 4:
                    list.SortDescending();

                    Console.WriteLine(
                        "Lista en orden descendente:");

                    list.DisplayForward();
                    break;

                case 5:
                    list.DisplayModes();
                    break;

                case 6:
                    list.DisplayGraph();
                    break;

                case 7:
                    Console.Write(
                        "Ingrese el valor que desea buscar: ");

                    value = Console.ReadLine() ?? "";

                    if (list.Contains(value))
                    {
                        Console.WriteLine(
                            $"El valor {value} SI existe.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"El numero {value} NO existe.");
                    }

                    break;

                case 8:
                    Console.Write(
                       "Valor del que desea eliminar todas las ocurrencias: ");

                    value = Console.ReadLine() ?? "";

                    if (list.RemoveOne(value))
                    {
                        Console.WriteLine(
                            "Una ocurrencia fue eliminada.");
                    }
                    else
                    {
                        Console.WriteLine(
                            "El valor no existe.");
                    }

                    Console.Write("Lista actual: ");
                    list.DisplayForward();
                    break;

                case 9:
                    Console.Write(
         "Valor del que desea eliminar todas las ocurrencias: ");

                    value = Console.ReadLine() ?? "";

                    int removedCount = list.RemoveAll(value);

                    Console.WriteLine(
                        $"Ocurrencias eliminadas: {removedCount}");

                    Console.Write("Lista actual: ");
                    list.DisplayForward();
                    break;

                case 0:
                    Console.WriteLine(
                        "Programa finalizado.");
                    break;

                default:
                    Console.WriteLine(
                        "Opcion no valida.");
                    break;
            }

        } while (option != 0);
    }
}
