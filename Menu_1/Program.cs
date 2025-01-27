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
                if (opcion == 1) DibujarGrafica();
                else if (opcion == 2) DibujarEspiral();
                else if (opcion == 3) salir = true;
                else MostrarError("Opción no válida.");
            }
            else MostrarError("Introduce un número válido.");
        }
        Console.WriteLine("Saliendo del programa. Presiona cualquier tecla para cerrar...");
        Console.ReadKey();
    }

    private static void MostrarMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menú 1 - Tema 2");
        Console.ResetColor();
        Console.WriteLine("1. Dibujar gráfica con *");
        Console.WriteLine("2. Dibujar espiral con *");
        Console.WriteLine("3. Salir");
        Console.Write("Escribe la opción (número): ");
    }

    private static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }

    private static void DibujarGrafica()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dibujar gráfica");
        Console.ResetColor();

        int x = Console.WindowWidth - 10, y = Console.WindowHeight - 10;
        int[] limites = { 6, 14 }; // 6 asteriscos horizontales y 14 verticales
        int estado = 0, pasos = 0;

        while (true)
        {
            if (x <= 0 || y <= 0 || y >= Console.WindowHeight - 1) break; // Se detiene al llegar al límite de la pantalla

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = estado % 2 == 0 ? ConsoleColor.Cyan : ConsoleColor.DarkBlue;
            Console.Write("*");
            System.Threading.Thread.Sleep(50);

            if (estado == 0 && pasos < limites[0]) x--;
            else if (estado == 1 && pasos < limites[1]) y--;
            else if (estado == 2 && pasos < limites[0]) x--;
            else if (estado == 3 && pasos < limites[1]) y++;
            else { estado = (estado + 1) % 4; pasos = -1; }
            pasos++;
        }

        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Listo!!! Presiona una tecla para continuar.");
        Console.ResetColor();
        Console.ReadKey();
    }

    private static void DibujarEspiral()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dibujar espiral");
        Console.ResetColor();

        int x = Console.WindowWidth / 2;
        int y = Console.WindowHeight / 2;
        int horizontal = 5;
        int vertical = 2;
        int pasos = 0;
        bool derecha = false;
        bool izquierda = true;
        bool arriba = false;
        bool abajo = false;
        bool neutro = true;

        ConsoleColor[] colores = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Cyan };

        for (int i = 0; i < 461; i++)
        {
            if (izquierda && pasos < horizontal && neutro)
            {
                Console.ForegroundColor = colores[i % colores.Length];
                Console.SetCursorPosition(x--, y);
                Console.WriteLine("*");
                pasos++;
                if (pasos == horizontal)
                {
                    pasos = 0;
                    horizontal += 5;
                    arriba = true;
                    izquierda = false;
                    neutro = false;
                }
                System.Threading.Thread.Sleep(40);
            }
            else if (arriba && pasos < vertical && !neutro)
            {
                Console.ForegroundColor = colores[i % colores.Length];
                Console.SetCursorPosition(x, y--);
                Console.WriteLine("*");
                pasos++;
                if (pasos == vertical)
                {
                    pasos = 0;
                    vertical += 2;
                    derecha = true;
                    arriba = false;
                    neutro = true;
                }
                System.Threading.Thread.Sleep(40);
            }
            else if (derecha && pasos < horizontal && neutro)
            {
                Console.ForegroundColor = colores[i % colores.Length];
                Console.SetCursorPosition(x++, y);
                Console.WriteLine("*");
                pasos++;
                if (pasos == horizontal)
                {
                    pasos = 0;
                    horizontal += 5;
                    abajo = true;
                    derecha = false;
                    neutro = false;
                }
                System.Threading.Thread.Sleep(40);
            }
            else if (abajo && pasos < vertical && !neutro)
            {
                Console.ForegroundColor = colores[i % colores.Length];
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("*");
                pasos++;
                if (pasos == vertical)
                {
                    pasos = 0;
                    vertical += 2;
                    izquierda = true;
                    abajo = false;
                    neutro = true;
                }
                System.Threading.Thread.Sleep(40);
            }
        }

        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Listo!!! Presiona una tecla para continuar.");
        Console.ResetColor();
        Console.ReadKey();
    }
}
