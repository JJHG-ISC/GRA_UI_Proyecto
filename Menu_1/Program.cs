using System;

internal class Program
{
    private static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            MostrarMenu();
            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1: DibujarGrafica(); break;
                    case 3: salir = true; break;
                    default: MostrarError("Opción no válida."); break;
                }
            }
            else MostrarError("Introduce un número válido.");
        }
        Console.Clear();
        Console.WriteLine("Saliendo del programa. Presiona cualquier tecla para cerrar...");
        Console.ReadKey();
    }

    private static void MostrarMenu()
    {
        Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Menú 1 - Tema 2");
        Console.SetCursorPosition(10, 4); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("1. Dibujar gráfica con *");
        Console.SetCursorPosition(10, 5); Console.WriteLine("2. Dibujar espiral con *");
        Console.SetCursorPosition(10, 6); Console.WriteLine("3. Salir");
        Console.SetCursorPosition(10, 8); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Escribe la opción (número):");
    }

    private static void MostrarError(string mensaje)
    {
        Console.WriteLine(mensaje + " Presiona una tecla para continuar.");
        Console.ReadKey();
    }

    private static void DibujarGrafica()
    {
        Console.Clear();
        Console.SetCursorPosition(10, 2); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Dibujar gráfica");

        int x = Console.WindowWidth - 1, y = 10, estado = 0, pasos = 0;
        int longitudHorizontal = 10, alturaVertical = 5;
        int altoPantalla = Console.WindowHeight - 1;

        for (; x >= 0 && y >= 0 && y < altoPantalla; pasos++)
        {
            if (x <= 0 || y <= 0 || y >= altoPantalla) break;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = estado % 2 == 0 ? ConsoleColor.Blue : ConsoleColor.Cyan;
            Console.Write("*");
            System.Threading.Thread.Sleep(50);

            if (estado == 0 && pasos < longitudHorizontal) x--;
            else if (estado == 1 && pasos < alturaVertical) y--;
            else if (estado == 2 && pasos < longitudHorizontal) x--;
            else if (estado == 3 && pasos < alturaVertical) y++;
            else { estado = (estado + 1) % 4; pasos = -1; }
        }

        Console.SetCursorPosition(10, Math.Min(y + 10, altoPantalla));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Listo!!! presiona una tecla para continuar");
        Console.ReadKey();
        Console.Clear();
    }
}
