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
        Console.WriteLine("Dibujar espiral divertida");
        Console.ResetColor();

        int ranaX = Console.WindowWidth / 2;
        int ranaY = Console.WindowHeight / 2; 
        int pasosLargos = 5; 
        int pasosCortos = 2; 
        int contadorPasos = 0; 
        bool saltandoDerecha = false; 
        bool saltandoIzquierda = true; 
        bool saltandoArriba = false; 
        bool saltandoAbajo = false;
        bool neutro = true;

        ConsoleColor[] arcoiris = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Cyan }; // Colores 

        for (int brincos = 0; brincos < 461; brincos++) // ¡Muchas vueltas! 
        {
            if (saltandoIzquierda && contadorPasos < pasosLargos && neutro)
            {
                Console.ForegroundColor = arcoiris[brincos % arcoiris.Length];
                Console.SetCursorPosition(ranaX--, ranaY);
                Console.WriteLine("*");
                contadorPasos++;
                if (contadorPasos == pasosLargos)
                {
                    contadorPasos = 0;
                    pasosLargos += 5;
                    saltandoArriba = true;
                    saltandoIzquierda = false;
                    neutro = false;
                }
                System.Threading.Thread.Sleep(40);
            }
            else if (saltandoArriba && contadorPasos < pasosCortos && !neutro)
            {
                Console.ForegroundColor = arcoiris[brincos % arcoiris.Length];
                Console.SetCursorPosition(ranaX, ranaY--);
                Console.WriteLine("*");
                contadorPasos++;
                if (contadorPasos == pasosCortos)
                {
                    contadorPasos = 0;
                    pasosCortos += 2;
                    saltandoDerecha = true;
                    saltandoArriba = false;
                    neutro = true;
                }
                System.Threading.Thread.Sleep(40);
            }
            else if (saltandoDerecha && contadorPasos < pasosLargos && neutro)
            {
                Console.ForegroundColor = arcoiris[brincos % arcoiris.Length];
                Console.SetCursorPosition(ranaX++, ranaY);
                Console.WriteLine("*");
                contadorPasos++;
                if (contadorPasos == pasosLargos)
                {
                    contadorPasos = 0;
                    pasosLargos += 5;
                    saltandoAbajo = true;
                    saltandoDerecha = false;
                    neutro = false;
                }
                System.Threading.Thread.Sleep(40);
            }
            else if (saltandoAbajo && contadorPasos < pasosCortos && !neutro)
            {
                Console.ForegroundColor = arcoiris[brincos % arcoiris.Length];
                Console.SetCursorPosition(ranaX, ranaY++);
                Console.WriteLine("*");
                contadorPasos++;
                if (contadorPasos == pasosCortos)
                {
                    contadorPasos = 0;
                    pasosCortos += 2;
                    saltandoIzquierda = true;
                    saltandoAbajo = false;
                    neutro = true;
                }
                System.Threading.Thread.Sleep(40);
            }
        }

        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("¡Espiral lista! Presiona cualquier tecla para continuar.");
        Console.ResetColor();
        Console.ReadKey();
    }

}
