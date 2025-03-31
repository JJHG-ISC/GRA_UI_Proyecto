using System;
using System.Threading; // Para Thread.Sleep

internal class Program
{
    // ====================================================
    // Métodos de Cálculo (a nivel de clase)
    // ====================================================

    private static double Factorial(int n)
    {
        double fact = 1;
        for (int i = 2; i <= n; i++)
            fact *= i;
        return fact;
    }

    // Conversión manual (22/7) en lugar de métodos del lenguaje
    private static double GradosARadianes(double grados)
    {
        return grados * (22.0 / 7.0) / 180.0;
    }

    private static double CalcularSeno(double grados)
    {
        double x = GradosARadianes(grados);
        double sum = 0;
        for (int i = 0; i < 10; i++)
        {
            double term = Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
            sum += term;
        }
        return sum;
    }

    private static double CalcularCoseno(double grados)
    {
        double x = GradosARadianes(grados);
        double sum = 0;
        for (int i = 0; i < 10; i++)
        {
            double term = Math.Pow(-1, i) * Math.Pow(x, 2 * i) / Factorial(2 * i);
            sum += term;
        }
        return sum;
    }

    // ====================================================
    // Programa Principal
    // ====================================================
    private static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            MostrarMenuPrincipal();

            // Leer opción
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int opcion))
            {
                MostrarError("Introduce un número válido.");
                continue;
            }

            if (opcion == 1)
            {
                MenuIntroduccion(); // Menú 1
            }
            else if (opcion == 2)
            {
                MenuLocalizacion(); // Menú 2
            }
            else if (opcion == 3)
            {
                salir = true;
            }
            else
            {
                MostrarError("Opción no válida.");
            }
        }
        Console.Clear();
        Console.SetCursorPosition(0, Console.WindowHeight - 2);
        Console.WriteLine("Saliendo del programa. Presiona cualquier tecla para cerrar...");
        Console.ReadKey();
    }

    // ====================================================
    // MENÚ PRINCIPAL
    // ====================================================
    private static void MostrarMenuPrincipal()
    {
        Console.SetCursorPosition(5, 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menú Principal");
        Console.ResetColor();
        Console.SetCursorPosition(5, 4);
        Console.WriteLine("1. Menú 1: Programas de introducción");
        Console.SetCursorPosition(5, 5);
        Console.WriteLine("2. Menú 2: Programas de localización");
        Console.SetCursorPosition(5, 6);
        Console.WriteLine("3. Salir");
        Console.SetCursorPosition(5, 8);
        Console.Write("Escribe la opción (número): ");
    }

    private static void MostrarError(string mensaje)
    {
        Console.Clear();
        Console.SetCursorPosition(5, Console.WindowHeight - 4);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
        Console.SetCursorPosition(5, Console.WindowHeight - 2);
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }

    // ====================================================
    // MENÚ 1: INTRODUCCIÓN
    // ====================================================
    private static void MenuIntroduccion()
    {
        bool volverMenu1 = false;
        while (!volverMenu1)
        {
            Console.Clear();
            MostrarMenu1();

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int opcion))
            {
                MostrarError("Introduce un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    DibujarGrafica();
                    if (NavigationOptions() == 2)
                        continue;
                    break;

                case 2:
                    DibujarEspiral();
                    if (NavigationOptions() == 2)
                        continue;
                    break;

                case 3:
                    DibujarRectangulos();
                    if (NavigationOptions() == 2)
                        continue;
                    break;

                case 4:
                    volverMenu1 = true;
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    MostrarError("Opción no válida.");
                    break;
            }
        }
    }

    private static void MostrarMenu1()
    {
        Console.SetCursorPosition(5, 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menú 1: Programas de introducción");
        Console.ResetColor();
        Console.SetCursorPosition(5, 4);
        Console.WriteLine("1. Dibujar gráfica con *");
        Console.SetCursorPosition(5, 5);
        Console.WriteLine("2. Dibujar espiral con *");
        Console.SetCursorPosition(5, 6);
        Console.WriteLine("3. Dibujar rectángulos con *");
        Console.SetCursorPosition(5, 7);
        Console.WriteLine("4. Volver al Menú Principal");
        Console.SetCursorPosition(5, 8);
        Console.WriteLine("5. Salir");
        Console.SetCursorPosition(5, 10);
        Console.Write("Escribe la opción (número): ");
    }

    // Opciones de navegación (1 = Menú anterior, 2 = Continuar, 3 = Salir)
    private static int NavigationOptions()
    {
        int posY = Console.WindowHeight - 4;
        Console.SetCursorPosition(5, posY);
        Console.WriteLine("1. Menú anterior   2. Continuar   3. Salir");
        Console.SetCursorPosition(5, posY + 1);
        Console.Write("Seleccione una opción: ");

        string input = Console.ReadLine();
        if (!int.TryParse(input, out int opcion))
            opcion = 1;

        if (opcion == 3)
            Environment.Exit(0);

        return opcion;
    }

    // ====================================================
    // MÉTODOS DEL MENÚ 1
    // ====================================================
    private static void DibujarGrafica()
    {
        Console.Clear();
        Console.SetCursorPosition(5, 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dibujar gráfica");
        Console.ResetColor();

        int x = Console.WindowWidth - 10;
        int y = Console.WindowHeight - 10;
        int[] limites = { 6, 14 };
        int estado = 0, pasos = 0;

        while (true)
        {
            if (x <= 0 || y <= 0 || y >= Console.WindowHeight - 1)
                break;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = (estado % 2 == 0) ? ConsoleColor.Cyan : ConsoleColor.DarkBlue;
            Console.Write("*");
            Thread.Sleep(50);

            if (estado == 0 && pasos < limites[0]) x--;
            else if (estado == 1 && pasos < limites[1]) y--;
            else if (estado == 2 && pasos < limites[0]) x--;
            else if (estado == 3 && pasos < limites[1]) y++;
            else
            {
                estado = (estado + 1) % 4;
                pasos = -1;
            }
            pasos++;
        }

        Console.SetCursorPosition(5, Console.WindowHeight - 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Listo!!! Presiona una tecla para continuar.");
        Console.ResetColor();
        Console.ReadKey();
    }

    private static void DibujarEspiral()
    {
        Console.Clear();
        Console.SetCursorPosition(5, 2);
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

        ConsoleColor[] arcoiris = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Cyan };

        for (int brincos = 0; brincos < 461; brincos++)
        {
            if (saltandoIzquierda && contadorPasos < pasosLargos && neutro)
            {
                Console.ForegroundColor = arcoiris[brincos % arcoiris.Length];
                Console.SetCursorPosition(ranaX--, ranaY);
                Console.Write("*");
                contadorPasos++;
                if (contadorPasos == pasosLargos)
                {
                    contadorPasos = 0;
                    pasosLargos += 5;
                    saltandoArriba = true;
                    saltandoIzquierda = false;
                    neutro = false;
                }
                Thread.Sleep(40);
            }
            else if (saltandoArriba && contadorPasos < pasosCortos && !neutro)
            {
                Console.ForegroundColor = arcoiris[brincos % arcoiris.Length];
                Console.SetCursorPosition(ranaX, ranaY--);
                Console.Write("*");
                contadorPasos++;
                if (contadorPasos == pasosCortos)
                {
                    contadorPasos = 0;
                    pasosCortos += 2;
                    saltandoDerecha = true;
                    saltandoArriba = false;
                    neutro = true;
                }
                Thread.Sleep(40);
            }
            else if (saltandoDerecha && contadorPasos < pasosLargos && neutro)
            {
                Console.ForegroundColor = arcoiris[brincos % arcoiris.Length];
                Console.SetCursorPosition(ranaX++, ranaY);
                Console.Write("*");
                contadorPasos++;
                if (contadorPasos == pasosLargos)
                {
                    contadorPasos = 0;
                    pasosLargos += 5;
                    saltandoAbajo = true;
                    saltandoDerecha = false;
                    neutro = false;
                }
                Thread.Sleep(40);
            }
            else if (saltandoAbajo && contadorPasos < pasosCortos && !neutro)
            {
                Console.ForegroundColor = arcoiris[brincos % arcoiris.Length];
                Console.SetCursorPosition(ranaX, ranaY++);
                Console.Write("*");
                contadorPasos++;
                if (contadorPasos == pasosCortos)
                {
                    contadorPasos = 0;
                    pasosCortos += 2;
                    saltandoIzquierda = true;
                    saltandoAbajo = false;
                    neutro = true;
                }
                Thread.Sleep(40);
            }
        }

        Console.SetCursorPosition(5, Console.WindowHeight - 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("¡Espiral lista! Presiona cualquier tecla para continuar.");
        Console.ResetColor();
        Console.ReadKey();
    }

    private static void DibujarRectangulos()
    {
        Console.Clear();
        Console.SetCursorPosition(5, 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dibujar rectángulos con *");
        Console.ResetColor();

        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;

        (ConsoleColor color, int ancho, int alto)[] rectangulos =
        {
            (ConsoleColor.Green, 3, 1),
            (ConsoleColor.Yellow, 15, 5),
            (ConsoleColor.Red, 25, 9),
            (ConsoleColor.Blue, 35, 13),
            (ConsoleColor.Cyan, 45, 17)
        };

        int centroX = anchoConsola / 2;
        int centroY = altoConsola / 2;

        foreach (var (color, ancho, alto) in rectangulos)
        {
            Console.ForegroundColor = color;

            // Superior (izq->der)
            for (int x = -ancho / 2; x <= ancho / 2; x++)
            {
                Console.SetCursorPosition(centroX + x, centroY - alto / 2);
                Console.Write("*");
                Thread.Sleep(10);
            }
            // Lado derecho (arr->abajo)
            for (int y = -alto / 2 + 1; y <= alto / 2; y++)
            {
                Console.SetCursorPosition(centroX + ancho / 2, centroY + y);
                Console.Write("*");
                Thread.Sleep(10);
            }
            // Inferior (der->izq)
            for (int x = ancho / 2 - 1; x >= -ancho / 2; x--)
            {
                Console.SetCursorPosition(centroX + x, centroY + alto / 2);
                Console.Write("*");
                Thread.Sleep(10);
            }
            // Lado izq (abajo->arriba)
            for (int y = alto / 2 - 1; y >= -alto / 2 + 1; y--)
            {
                Console.SetCursorPosition(centroX - ancho / 2, centroY + y);
                Console.Write("*");
                Thread.Sleep(10);
            }
            Thread.Sleep(500);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(5, Console.WindowHeight - 2);
        Console.WriteLine("Listo!!! Presiona una tecla para continuar.");
        Console.ResetColor();
        Console.ReadKey();
    }

    // ====================================================
    // MENÚ 2: PROGRAMAS DE LOCALIZACIÓN
    // ====================================================
    private static void MenuLocalizacion()
    {
        bool volverMenu2 = false;
        while (!volverMenu2)
        {
            Console.Clear();
            MostrarMenu2();

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int opcion))
            {
                MostrarError("Opción no válida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    while (true)
                    {
                        Console.Clear();
                        Senos();
                        int nav = NavigationOptions();
                        if (nav == 1) break;
                        if (nav == 2) continue;
                    }
                    break;

                case 2:
                    while (true)
                    {
                        Console.Clear();
                        Cosenos();
                        int nav = NavigationOptions();
                        if (nav == 1) break;
                        if (nav == 2) continue;
                    }
                    break;

                case 3:
                    while (true)
                    {
                        Console.Clear();
                        TrianguloRectangulo();
                        int nav = NavigationOptions();
                        if (nav == 1) break;
                        if (nav == 2) continue;
                    }
                    break;

                case 4:
                    while (true)
                    {
                        Console.Clear();
                        Recta();
                        int nav = NavigationOptions();
                        if (nav == 1) break;
                        if (nav == 2) continue;
                    }
                    break;

                case 5:
                    while (true)
                    {
                        Console.Clear();
                        TrayectoriaProyectil();
                        int nav = NavigationOptions();
                        if (nav == 1) break;
                        if (nav == 2) continue;
                    }
                    break;

                case 6:
                    volverMenu2 = true;
                    break;

                case 7:
                    Environment.Exit(0);
                    break;

                default:
                    MostrarError("Opción no válida.");
                    break;
            }
        }
    }

    private static void MostrarMenu2()
    {
        Console.SetCursorPosition(42, 4);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Menú Dos");
        Console.ResetColor();
        Console.SetCursorPosition(42, 6);
        Console.WriteLine("(1)\tTabla de senos del 0° al 90°");
        Console.SetCursorPosition(42, 7);
        Console.WriteLine("(2)\tTabla de cosenos del 0° al 90°");
        Console.SetCursorPosition(42, 8);
        Console.WriteLine("(3)\tTriángulo rectángulo (con dibujo)");
        Console.SetCursorPosition(42, 9);
        Console.WriteLine("(4)\tRecta (con dibujo)");
        Console.SetCursorPosition(42, 10);
        Console.WriteLine("(5)\tTrayectoria de un proyectil");
        Console.SetCursorPosition(42, 12);
        Console.WriteLine("(6)\tVolver al Menú Principal");
        Console.SetCursorPosition(42, 13);
        Console.WriteLine("(7)\tSalir");
        Console.SetCursorPosition(42, 15);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Elige la opción (número): ");
        Console.ResetColor();
    }

    // ====================================================
    // MÉTODOS DEL MENÚ 2 (SENOS, COSENOS, etc.)
    // ====================================================

    /// <summary>
    /// Imprime la tabla de senos de 0° a 90°,
    /// mostrando "sen X°= ..." primero "sen" y luego grados y resultado.
    /// </summary>
    private static void Senos()
    {
        Console.Clear();
        string titulo = "Tabla del Seno de 0° a 90°";
        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;
        int posTituloX = (anchoConsola - titulo.Length) / 2;
        Console.SetCursorPosition(posTituloX, 2);
        Console.WriteLine(titulo);

        int columnas = 6;
        int filas = 15;
        int espacioX = 15;
        int espacioY = 1;
        int contador = 0;
        int inicioY = (altoConsola - filas) / 2;
        if (inicioY < 5) inicioY = 5;

        // Imprimimos senos de 0° a 89°
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                int angulo = contador;
                if (angulo > 90) break;

                double seno = CalcularSeno(angulo);

                int posY = inicioY + (i * espacioY);
                if (posY >= Console.BufferHeight) break;

                int posX = (anchoConsola - (columnas * espacioX)) / 2 + (j * espacioX);
                Console.SetCursorPosition(posX, posY);
                // Ahora: "sen  0°= 0.00" (primero "sen", luego grados y resultado)
                Console.Write($"sen {angulo,2}°= {seno:F2}");

                contador += filas;
            }
            contador = i + 1;
        }

        // Agregamos manualmente el 90°
        double seno90 = CalcularSeno(90);
        Console.SetCursorPosition(5, Console.CursorTop + 2);
        Console.WriteLine($"sen 90°= {seno90:F2}");

        Console.SetCursorPosition(5, Console.WindowHeight - 2);
        Console.WriteLine("Presiona ENTER para continuar...");
        Console.ReadLine();
    }

    /// <summary>
    /// Imprime la tabla de cosenos de 0° a 90°,
    /// mostrando "cos X°= ..." primero "cos" y luego grados y resultado.
    /// </summary>
    private static void Cosenos()
    {
        Console.Clear();
        string titulo = "Tabla del Coseno de 0° a 90°";
        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;
        int posTituloX = (anchoConsola - titulo.Length) / 2;
        Console.SetCursorPosition(posTituloX, 2);
        Console.WriteLine(titulo);

        int columnas = 6;
        int filas = 15;
        int espacioX = 15;
        int espacioY = 1;
        int contador = 0;
        int inicioY = (altoConsola - filas) / 2;
        if (inicioY < 5) inicioY = 5;

        // Imprimimos cosenos de 0° a 89°
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                int angulo = contador;
                if (angulo > 90) break;

                double coseno = CalcularCoseno(angulo);

                int posY = inicioY + (i * espacioY);
                if (posY >= Console.BufferHeight) break;

                int posX = (anchoConsola - (columnas * espacioX)) / 2 + (j * espacioX);
                Console.SetCursorPosition(posX, posY);
                // Ahora: "cos  0°= 1.00"
                Console.Write($"cos {angulo,2}°= {coseno:F2}");

                contador += filas;
            }
            contador = i + 1;
        }

        // Agregamos manualmente el 90°
        double cos90 = CalcularCoseno(90);
        Console.SetCursorPosition(5, Console.CursorTop + 2);
        Console.WriteLine($"cos 90°= {cos90:F2}");

        Console.SetCursorPosition(5, Console.WindowHeight - 2);
        Console.WriteLine("Presiona ENTER para continuar...");
        Console.ReadLine();
    }

    private static void TrianguloRectangulo()
    {
        Console.Clear();
        Console.SetCursorPosition(5, 2);
        Console.WriteLine("Cálculo del Triángulo Rectángulo");
        Console.SetCursorPosition(5, 4);
        Console.Write("Ingrese el primer cateto: ");
        double cateto1 = Convert.ToDouble(Console.ReadLine());
        Console.SetCursorPosition(5, 6);
        Console.Write("Ingrese el segundo cateto: ");
        double cateto2 = Convert.ToDouble(Console.ReadLine());

        double hipotenusa = Math.Sqrt(cateto1 * cateto1 + cateto2 * cateto2);
        double angulo1 = Math.Asin(cateto1 / hipotenusa) * 180.0 / Math.PI;
        double angulo2 = Math.Asin(cateto2 / hipotenusa) * 180.0 / Math.PI;

        Console.Clear();
        Console.SetCursorPosition(5, 2);
        Console.WriteLine("Resultados:");
        Console.SetCursorPosition(5, 4);
        Console.WriteLine("Hipotenusa: {0:F2}", hipotenusa);
        Console.SetCursorPosition(5, 5);
        Console.WriteLine("Ángulo opuesto al primer cateto: {0:F2}°", angulo1);
        Console.SetCursorPosition(5, 6);
        Console.WriteLine("Ángulo opuesto al segundo cateto: {0:F2}°", angulo2);

        // Dibujo del triángulo
        Console.SetCursorPosition(5, 8);
        Console.WriteLine("    |\\");
        Console.SetCursorPosition(5, 9);
        Console.WriteLine("    | \\");
        Console.SetCursorPosition(5, 10);
        Console.WriteLine("cat1|  \\ Hipotenusa");
        Console.SetCursorPosition(5, 11);
        Console.WriteLine("    |   \\");
        Console.SetCursorPosition(5, 12);
        Console.WriteLine("    |____\\");
        Console.SetCursorPosition(5, Console.WindowHeight - 2);
        Console.WriteLine("Presiona ENTER para continuar...");
        Console.ReadLine();
    }

    private static void Recta()
    {
        Console.Clear();
        Console.SetCursorPosition(5, 2);
        Console.WriteLine("Cálculo de la Recta a partir de Dos Puntos");
        Console.SetCursorPosition(5, 4);
        Console.Write("Ingrese la coordenada x del primer punto: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        Console.SetCursorPosition(5, 5);
        Console.Write("Ingrese la coordenada y del primer punto: ");
        double y1 = Convert.ToDouble(Console.ReadLine());
        Console.SetCursorPosition(5, 6);
        Console.Write("Ingrese la coordenada x del segundo punto: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        Console.SetCursorPosition(5, 7);
        Console.Write("Ingrese la coordenada y del segundo punto: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        // Para la segunda recta
        Console.SetCursorPosition(5, 9);
        Console.WriteLine("Ingrese las coordenadas de la segunda recta:");
        Console.SetCursorPosition(5, 10);
        Console.Write("Ingrese la coordenada x del tercer punto: ");
        double x3 = Convert.ToDouble(Console.ReadLine());
        Console.SetCursorPosition(5, 11);
        Console.Write("Ingrese la coordenada y del tercer punto: ");
        double y3 = Convert.ToDouble(Console.ReadLine());
        Console.SetCursorPosition(5, 12);
        Console.Write("Ingrese la coordenada x del cuarto punto: ");
        double x4 = Convert.ToDouble(Console.ReadLine());
        Console.SetCursorPosition(5, 13);
        Console.Write("Ingrese la coordenada y del cuarto punto: ");
        double y4 = Convert.ToDouble(Console.ReadLine());

        double? m1 = (Math.Abs(x2 - x1) > 1e-9) ? (y2 - y1) / (x2 - x1) : (double?)null;
        double? m2 = (Math.Abs(x4 - x3) > 1e-9) ? (y4 - y3) / (x4 - x3) : (double?)null;

        Console.Clear();
        Console.SetCursorPosition(5, 2);
        if (m1.HasValue)
            Console.WriteLine("Pendiente de la primera recta: {0:F2}", m1.Value);
        else
            Console.WriteLine("Pendiente de la primera recta: Indefinida (vertical)");

        if (m2.HasValue)
            Console.WriteLine("Pendiente de la segunda recta: {0:F2}", m2.Value);
        else
            Console.WriteLine("Pendiente de la segunda recta: Indefinida (vertical)");

        double A1, B1, C1;
        if (m1.HasValue)
        {
            A1 = m1.Value;
            B1 = -1;
            C1 = y1 - m1.Value * x1;
        }
        else
        {
            A1 = 1;
            B1 = 0;
            C1 = -x1;
        }
        double A2, B2, C2;
        if (m2.HasValue)
        {
            A2 = m2.Value;
            B2 = -1;
            C2 = y3 - m2.Value * x3;
        }
        else
        {
            A2 = 1;
            B2 = 0;
            C2 = -x3;
        }

        double det = A1 * B2 - A2 * B1;
        if (Math.Abs(det) < 1e-9)
        {
            Console.WriteLine("\nLas rectas son paralelas o coincidentes.");
            GraficarDosRectas(x1, y1, x2, y2, x3, y3, x4, y4, null, null);
        }
        else
        {
            double ix = (B1 * C2 - B2 * C1) / det;
            double iy = (C1 * A2 - C2 * A1) / det;
            Console.WriteLine("\nPunto de intersección: ({0:F2}, {1:F2})", ix, iy);
            GraficarDosRectas(x1, y1, x2, y2, x3, y3, x4, y4, ix, iy);
        }

        Console.SetCursorPosition(5, Console.WindowHeight - 2);
        Console.WriteLine("Presiona ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
    }

    private static void GraficarDosRectas(
        double x1, double y1, double x2, double y2,
        double x3, double y3, double x4, double y4,
        double? ix, double? iy)
    {
        double pendiente1 = (y2 - y1) / (x2 - x1);
        double pendiente2 = (y4 - y3) / (x4 - x3);

        double minX = Math.Min(Math.Min(x1, x2), Math.Min(x3, x4));
        double maxX = Math.Max(Math.Max(x1, x2), Math.Max(x3, x4));
        double minY = Math.Min(Math.Min(y1, y2), Math.Min(y3, y4));
        double maxY = Math.Max(Math.Max(y1, y2), Math.Max(y3, y4));

        if (ix.HasValue && iy.HasValue)
        {
            minX = Math.Min(minX, ix.Value);
            maxX = Math.Max(maxX, ix.Value);
            minY = Math.Min(minY, iy.Value);
            maxY = Math.Max(maxY, iy.Value);
        }

        minX -= 2; maxX += 2;
        minY -= 2; maxY += 2;
        int minXi = (int)Math.Floor(minX);
        int maxXi = (int)Math.Ceiling(maxX);
        int minYi = (int)Math.Floor(minY);
        int maxYi = (int)Math.Ceiling(maxY);
        int ancho = maxXi - minXi + 1;
        int alto = maxYi - minYi + 1;

        char[,] plano = new char[alto, ancho];
        for (int i = 0; i < alto; i++)
            for (int j = 0; j < ancho; j++)
                plano[i, j] = ' ';

        int col0 = -minXi;
        int row0 = alto - 1 - (-minYi);
        if (col0 >= 0 && col0 < ancho)
            for (int i = 0; i < alto; i++)
                plano[i, col0] = '|';
        if (row0 >= 0 && row0 < alto)
            for (int j = 0; j < ancho; j++)
                plano[row0, j] = '-';
        if (col0 >= 0 && col0 < ancho && row0 >= 0 && row0 < alto)
            plano[row0, col0] = '+';

        void Marcar(double xx, double yy, char simbolo)
        {
            int col = (int)Math.Round(xx) - minXi;
            int row = alto - 1 - ((int)Math.Round(yy) - minYi);
            if (row >= 0 && row < alto && col >= 0 && col < ancho)
                plano[row, col] = simbolo;
        }

        void TrazarRecta(int x0, int y0, int x1, int y1, char simbolo)
        {
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = dx + dy, e2;
            while (true)
            {
                Marcar(x0, y0, simbolo);
                if (x0 == x1 && y0 == y1) break;
                e2 = 2 * err;
                if (e2 >= dy) { err += dy; x0 += sx; }
                if (e2 <= dx) { err += dx; y0 += sy; }
            }
        }

        TrazarRecta((int)x1, (int)y1, (int)x2, (int)y2, '*');
        TrazarRecta((int)x3, (int)y3, (int)x4, (int)y4, '+');
        if (ix.HasValue && iy.HasValue)
            Marcar(ix.Value, iy.Value, 'X');

        Console.Clear();
        int offsetX = Math.Max((Console.WindowWidth - ancho) / 2, 0);
        int offsetY = Math.Max((Console.WindowHeight - alto) / 2, 0);

        for (int i = 0; i < alto; i++)
        {
            Console.SetCursorPosition(offsetX, offsetY + i);
            for (int j = 0; j < ancho; j++)
                Console.Write(plano[i, j]);
        }

        Console.SetCursorPosition(0, offsetY + alto + 1);
        Console.WriteLine("\nLeyenda: '*' = Recta 1, '+' = Recta 2, 'X' = Intersección, '|' y '-' = Ejes");
        Console.WriteLine($"\nPendiente de la primera recta: {pendiente1:F2}");
        Console.WriteLine($"Pendiente de la segunda recta: {pendiente2:F2}");

        if (!ix.HasValue || !iy.HasValue)
        {
            if (Math.Abs(pendiente1 - pendiente2) < 0.0001)
                Console.WriteLine("Las rectas son paralelas y no tienen intersección.");
            else
                Console.WriteLine("Las rectas no se intersectan en el rango definido.");
        }
        else
        {
            Console.WriteLine($"Punto de intersección: ({ix.Value:F2}, {iy.Value:F2})");
        }
    }

    private static void TrayectoriaProyectil()
    {
        // Limpiamos la consola y pedimos los datos de entrada:
        Console.Clear();
        Console.SetCursorPosition(5, 2);
        Console.WriteLine("Simulación del Movimiento de un Proyectil");

        Console.SetCursorPosition(5, 4);
        Console.Write("Ingrese la velocidad inicial (m/s): ");
        double velocidadInicial = Convert.ToDouble(Console.ReadLine());

        Console.SetCursorPosition(5, 5);
        Console.Write("Ingrese el ángulo de lanzamiento (grados): ");
        double anguloGrados = Convert.ToDouble(Console.ReadLine());

        // Limpiamos para iniciar la simulación
        Console.Clear();

        // Conversión de grados a radianes usando la aproximación 22/7
        double rad = anguloGrados * (22.0 / 7.0) / 180.0;
        double g = 9.81;  // Aceleración gravitatoria
        double t_total = (2 * velocidadInicial * Math.Sin(rad)) / g;

        // Mostramos el encabezado de la tabla
        Console.SetCursorPosition(5, 2);
        Console.WriteLine("Tiempo(s)\tDistancia(m)\tAltura(m)\tVelocidad(m/s)");

        // Variables para llevar los máximos
        double t = 0.0;
        double maxAltura = 0.0;
        double maxVelocidad = velocidadInicial;
        double maxDistancia = 0.0;

        // Definimos la línea base y calculamos el número de líneas disponibles
        int lineaBase = 4;
        int maxLineasDisponibles = Console.WindowHeight - lineaBase - 10;  // Dejamos margen para resultados

        // Factor de escala para evitar que el cursor salga de la ventana
        double factorEscala = (t_total > 0) ? (maxLineasDisponibles / t_total) : 1;

        // Bucle de simulación en intervalos de 0.1 s
        while (t <= t_total)
        {
            // Posición en X y Y en el instante t
            double x = velocidadInicial * Math.Cos(rad) * t;
            double y = velocidadInicial * Math.Sin(rad) * t - 0.5 * g * t * t;

            // Componentes de la velocidad
            double vx = velocidadInicial * Math.Cos(rad);
            double vy = velocidadInicial * Math.Sin(rad) - g * t;
            double velocidad = Math.Sqrt(vx * vx + vy * vy);

            // Actualizamos los valores máximos
            if (y > maxAltura) maxAltura = y;
            if (x > maxDistancia) maxDistancia = x;
            if (velocidad > maxVelocidad) maxVelocidad = velocidad;

            // Calculamos la posición vertical para imprimir (evitando salir del área visible)
            int posY = lineaBase + (int)(t * factorEscala);

            // Si excede la altura de la consola, limitamos la posición
            if (posY >= Console.WindowHeight)
                posY = Console.WindowHeight - 1;

            // Imprimimos la fila con los datos de este instante
            Console.SetCursorPosition(5, posY);
            Console.WriteLine("{0:F1}\t\t{1:F2}\t\t{2:F2}\t\t{3:F2}", t, x, y, velocidad);

            // Incremento de 0.1 s
            t += 0.1;
        }

        // Al terminar, mostramos los resultados finales en la parte inferior de la consola
        Console.SetCursorPosition(5, Console.WindowHeight - 8);
        Console.WriteLine("Resultados finales:");
        Console.WriteLine("Altura máxima: {0:F2} m", maxAltura);
        Console.WriteLine("Velocidad máxima: {0:F2} m/s", maxVelocidad);
        Console.WriteLine("Distancia máxima: {0:F2} m", maxDistancia);

        // Mensaje final
        Console.SetCursorPosition(5, Console.WindowHeight - 4);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Presiona ENTER para continuar...");
        Console.ResetColor();
        Console.ReadLine();
    }
}

