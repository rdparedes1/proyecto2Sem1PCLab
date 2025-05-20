//Rubén Darío Paredes Flores - 1152225
//Proyecto 2 de Laboratorio Pensamiento Computacional
//TODO: Validaciones de terminar partida aparte de la rendición de un jugador (ready)
class Program
{
    static void Main(string[] args)
    {
        Jugador jugador1 = new Jugador();
        Jugador jugador2 = new Jugador();
        Funciones funciones = new Funciones();
        bool continuar = true;
        bool aceptarFlota = false;
        Console.WriteLine("Bienvenido al juego de Batalla Naval!");
        Console.WriteLine("El juego consiste en hundir los barcos del oponente antes de que el oponente hunda los tuyos.");
        Console.WriteLine("Cada jugador tiene 15 intentos para hundir los barcos del oponente.");
        Console.WriteLine("Cada golpe acertado a una nave enemiga te otorgará un punto.");
        Console.WriteLine("La flota de cada jugador está compuesta por 3 tipos de barcos:");
        Console.WriteLine("1. Submarino, que ocupa un espacio de 2 casillas de manera horizontal. (2 puntos)");
        Console.WriteLine("2. Fragata, que ocupa un espacio de 3 casillas de manera vertical. (3 puntos)");
        Console.WriteLine("3. Destructor, que ocupa un espacio de 4 casillas de manera vertical u horizontalmente. (4 puntos)");
        Console.WriteLine("A continuación sera generada la posición de los barcos de cada jugador.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        jugador1.setFlotaNaval(funciones.generarFlotaNaval(jugador1.getFlotaNaval()));
        while (!aceptarFlota)
        {
            jugador1.dibujarTableros(1);
            Console.WriteLine("Ingrese el número 1 si desea aceptar la posición actual de su flota, o 2 si desea que vuelva a ser generada una flota random.");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                aceptarFlota = true;
                Console.Clear();
            }
            else if (opcion == "2")
            {
                jugador1.setFlotaNaval(funciones.generarFlotaNaval(jugador1.getFlotaNaval()));
                aceptarFlota = false;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, ingrese 1 o 2.");
            }
        }

        Console.WriteLine("La flota del jugador 1 ha sido aceptada.");
        Console.WriteLine("Ahora es el turno del jugador 2.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        aceptarFlota = false;
        jugador2.setFlotaNaval(funciones.generarFlotaNaval(jugador2.getFlotaNaval()));
        while (!aceptarFlota)
        {
            jugador2.dibujarTableros(2);
            Console.WriteLine("Ingrese el número 1 si desea aceptar la posición actual de su flota, o 2 si desea que vuelva a ser generada una flota random.");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                aceptarFlota = true;
                Console.Clear();
            }
            else if (opcion == "2")
            {
                jugador2.setFlotaNaval(funciones.generarFlotaNaval(jugador2.getFlotaNaval()));
                aceptarFlota = false;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, ingrese 1 o 2.");
            }
        }

        Console.WriteLine("La flota del jugador 2 ha sido aceptada.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Ahora comienza el juego!");
        Console.WriteLine("El jugador 1 comenzará atacando al jugador 2.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        string opcion2;
        while (continuar)
        {
            Console.WriteLine("Turno del jugador 1:");
            jugador1.dibujarTableros(1);
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Atacar al jugador 2.");
            Console.WriteLine("2. Rendirse.");
            opcion2 = Console.ReadLine();
            if (opcion2 == "1")
            {
                jugador1.lanzarMisil(jugador2);
                continuar = funciones.validarWin(jugador1, jugador2, 1);
            }
            else if (opcion2 == "2")
            {
                Console.WriteLine("El jugador 1 se ha rendido. El jugador 2 gana!");
                continuar = false;
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, ingrese 1 o 2.");
            }

            if (continuar == true)
            {
                Console.WriteLine("Turno del jugador 2:");
                jugador2.dibujarTableros(2);
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Atacar al jugador 1.");
                Console.WriteLine("2. Rendirse.");
                opcion2 = Console.ReadLine();
                if (opcion2 == "1")
                {
                    jugador2.lanzarMisil(jugador1);
                    continuar = funciones.validarWin(jugador2, jugador1, 2);
                }
                else if (opcion2 == "2")
                {
                    Console.WriteLine("El jugador 2 se ha rendido. El jugador 1 gana!");
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, ingrese 1 o 2.");
                }
            }
        }
    }
}

class Funciones
{
    string[] letrasCoordenadas = { "A", "B", "C", "D", "E", "F" };
    public void MostrarTablero(string[,] tablero)
    {
        Console.WriteLine("Tablero de Ataque:");
        Console.WriteLine("  1 2 3 4 5 6");
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            Console.Write(letrasCoordenadas[i] + " ");
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                Console.Write(tablero[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public void MostrarFlotaNaval(string[,] flotaNaval)
    {
        Console.WriteLine("Flota Naval:");
        Console.WriteLine("  1 2 3 4 5 6");
        for (int i = 0; i < flotaNaval.GetLength(0); i++)
        {
            Console.Write(letrasCoordenadas[i] + " ");
            for (int j = 0; j < flotaNaval.GetLength(1); j++)
            {
                Console.Write(flotaNaval[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public string[,] generarFlotaNaval(string[,] flotaNaval)
    {
        Random rnd = new Random();
        int intentosMaximos = 100; // Para evitar bucles infinitos
        int intentos = 0;

        // Reinicia el tablero antes de empezar
        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 6; j++)
                flotaNaval[i, j] = " ";

        // Submarino
        bool ocupado = true;
        while (ocupado && intentos < intentosMaximos)
        {
            int fila = rnd.Next(0, 6);
            int columna = rnd.Next(0, 5);
            if (flotaNaval[fila, columna] == " " && flotaNaval[fila, columna + 1] == " ")
            {
                flotaNaval[fila, columna] = "S";
                flotaNaval[fila, columna + 1] = "S";
                ocupado = false;
            }
            intentos++;
        }

        // Fragata
        ocupado = true;
        intentos = 0;
        while (ocupado && intentos < intentosMaximos)
        {
            int fila = rnd.Next(2, 6);
            int columna = rnd.Next(0, 6);
            if (flotaNaval[fila, columna] == " " &&
                flotaNaval[fila - 1, columna] == " " &&
                flotaNaval[fila - 2, columna] == " ")
            {
                flotaNaval[fila, columna] = "F";
                flotaNaval[fila - 1, columna] = "F";
                flotaNaval[fila - 2, columna] = "F";
                ocupado = false;
            }
            intentos++;
        }

        // Destructor
        ocupado = true;
        intentos = 0;
        while (ocupado && intentos < intentosMaximos)
        {
            int orientacion = rnd.Next(0, 2); // 0 = horizontal, 1 = vertical
            if (orientacion == 0)
            {
                int fila = rnd.Next(0, 6);
                int columna = rnd.Next(0, 3);
                if (flotaNaval[fila, columna] == " " && flotaNaval[fila, columna + 1] == " " &&
                    flotaNaval[fila, columna + 2] == " " && flotaNaval[fila, columna + 3] == " ")
                {
                    flotaNaval[fila, columna] = "D";
                    flotaNaval[fila, columna + 1] = "D";
                    flotaNaval[fila, columna + 2] = "D";
                    flotaNaval[fila, columna + 3] = "D";
                    ocupado = false;
                }
            }
            else
            {
                int fila = rnd.Next(3, 6);
                int columna = rnd.Next(0, 6);
                if (flotaNaval[fila, columna] == " " && flotaNaval[fila - 1, columna] == " " &&
                    flotaNaval[fila - 2, columna] == " " && flotaNaval[fila - 3, columna] == " ")
                {
                    flotaNaval[fila, columna] = "D";
                    flotaNaval[fila - 1, columna] = "D";
                    flotaNaval[fila - 2, columna] = "D";
                    flotaNaval[fila - 3, columna] = "D";
                    ocupado = false;
                }
            }
            intentos++;
        }

        return flotaNaval;
    }

    public bool validarWin(Jugador atacante, Jugador atacado, int jugadorActual)
    {
        bool resultado;
        if (atacante.getPuntaje() == 9)
        {
            Console.WriteLine($"¡Felicidades! El jugador número {jugadorActual} ha derribado todos los barcos enemigos, es el ganador.");
            resultado = false;
        }
        else if (atacante.getIntentosDisponlibles() == 0)
        {
            Console.WriteLine($"El jugador número {jugadorActual} ha agotado sus intentos. Fin del juego.");
            if (atacante.getPuntaje() > atacado.getPuntaje())
            {
                Console.WriteLine($"El jugador número {jugadorActual} tiene mayor punteo, el es el ganador.");
            }
            else if (atacante.getPuntaje() < atacado.getPuntaje())
            {
                Console.WriteLine($"El jugador número {jugadorActual} tiene menor punteo, el jugador enemigo es el ganador.");
            }
            else
            {
                Console.WriteLine($"Ambos jugadores tienen el mismo puntaje, no hay ganador.");
            }
            resultado = false;
        }
        else
        {
            resultado = true;
        }
        return resultado;
    }
}

class Jugador
{
    private int puntaje;
    private int intentosDisponlibles;
    private string[,] flotaNaval = new string[6, 6];
    private string[,] tableroAtaque = new string[6,6];

    public Jugador() {
        this.puntaje = 0;
        this.intentosDisponlibles = 15;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                flotaNaval[i, j] = " ";
                tableroAtaque[i, j] = "~";
            }
        }
    }

    public int getPuntaje()
    {
        return puntaje;
    }

    public void setPuntaje(int puntaje)
    {
        this.puntaje = puntaje;
    }

    public int getIntentosDisponlibles()
    {
        return intentosDisponlibles;
    }

    public void setIntentosDisponlibles(int intentosDisponlibles)
    {
        this.intentosDisponlibles = intentosDisponlibles;
    }

    public string[,] getFlotaNaval()
    {
        return flotaNaval;
    }

    public void setFlotaNaval(string[,] flotaNaval)
    {
        this.flotaNaval = flotaNaval;
    }

    public string[,] getTableroAtaque()
    {
        return tableroAtaque;
    }

    public void setTableroAtaque(string[,] tableroAtaque)
    {
        this.tableroAtaque = tableroAtaque;
    }

    public void dibujarTableros(int numeroPlayer)
    {
        Funciones funciones = new Funciones();
        Console.WriteLine($"Puntaje del jugador número {numeroPlayer}: {getPuntaje()}");
        Console.WriteLine($"Intentos disponibles del jugador número {numeroPlayer}: {getIntentosDisponlibles()}");
        Console.WriteLine(" ");
        funciones.MostrarFlotaNaval(flotaNaval);
        Console.WriteLine(" ");
        funciones.MostrarTablero(tableroAtaque);
        Console.WriteLine(" ");
    }

    public void lanzarMisil(Jugador jugadorEnemigo)
    {
        int fila;
        bool repetirAtaque = false;
        while (!repetirAtaque)
        {
            Console.WriteLine("Ingrese la fila (A-F) y columna (1-6) del ataque (ejemplo: A-1):");
            string ataque = Console.ReadLine().ToUpper();
            fila = 1000;
            switch (ataque[0])
            {
                case 'A':
                    fila = 0;
                    break;
                case 'B':
                    fila = 1;
                    break;
                case 'C':
                    fila = 2;
                    break;
                case 'D':
                    fila = 3;
                    break;
                case 'E':
                    fila = 4;
                    break;
                case 'F':
                    fila = 5;
                    break;
                default:
                    Console.WriteLine("Coordenadas inválidas. Intente nuevamente.");
                    break;
            }
            if (fila == 1000)
            {
            }
            else if (fila < 0 || fila > 5)
            {
                Console.WriteLine("Coordenadas inválidas. Intente nuevamente.");
            }
            else
            {
                //TODO: Hacer lo de verificar que no se haya atacado la misma coordenada, con el tablero de ataque del jugador actual
                int columna = int.Parse(ataque[2].ToString()) - 1;
                string[,] tableroAtaque = getTableroAtaque();
                string[,] flotaNaval = jugadorEnemigo.getFlotaNaval();
                if (tableroAtaque[fila, columna] == "X" || tableroAtaque[fila, columna] == "O")
                {
                    Console.WriteLine("Ya has atacado esta coordenada. Intenta nuevamente.");
                }
                else
                {
                    if (fila >= 0 && fila < 6 && columna >= 0 && columna < 6)
                    {
                        if (jugadorEnemigo.getFlotaNaval()[fila, columna] == "S" || jugadorEnemigo.getFlotaNaval()[fila, columna] == "D" || jugadorEnemigo.getFlotaNaval()[fila, columna] == "F")
                        {
                            setPuntaje(getPuntaje() + 1);
                            tableroAtaque[fila, columna] = "O";
                            setTableroAtaque(tableroAtaque);
                            flotaNaval[fila, columna] = "X";
                            jugadorEnemigo.setFlotaNaval(flotaNaval);
                            Console.WriteLine("¡Golpe acertado!");
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            tableroAtaque[fila, columna] = "X";
                            setTableroAtaque(tableroAtaque);
                            Console.WriteLine("¡Agua, el golpe no ha acertado en ningun barco enemigo!");
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        setIntentosDisponlibles(getIntentosDisponlibles() - 1);
                        repetirAtaque = true;
                    }
                    else
                    {
                        Console.WriteLine("Coordenadas inválidas. Intente nuevamente.");
                    }
                }
            }
        }
    }
}