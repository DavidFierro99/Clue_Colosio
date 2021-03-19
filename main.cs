using System;


class MainClass {
    
    // Categorias del juego, constante
    static string[] DICT_ELEMENTOS = {"Sospechosos", "Lugares", "Armas"};
    
    // Elementos del juego, personas, lugares y armas
    static string[,] DATOS = new string[,] {{"Carlos S", "Mario A", "Ernesto Z", "Comandante M", "Joaquin G"},
                                            {"Lomas taurinas", "Aeropuerto", "Mitin", "Sede del partido", "Coche",},
                                            {"Pistola", "Cuchillo", "Playera del PRI", "Taco envenenado", "Carro de tamales"}};

    static string[] ASESINO;

    static string[] sospecha;


    public static void Main (string[] args) 
    {
        
        // Inicializacion de variable aleatoria
        var RAND = new Random();

        // Configuracion del asesino de la partida
        ASESINO = new string[] {DATOS[0, RAND.Next(0,5)], DATOS[1, RAND.Next(0,5)], DATOS[2, RAND.Next(0,5)]};
        
        Console.WriteLine("Colosio fue asesinado por " + ASESINO[0] + " en " + ASESINO[1] + " con " + ASESINO[2]);


        preguntas();

        Console.WriteLine("Has utilizado todas tus preguntas, es momento de decidir quien fue el culpable");

        acusar();

        if (sospecha[0] == ASESINO[0] && sospecha[1] == ASESINO[1] && sospecha[2] == ASESINO[2])
        {
            Console.WriteLine("Acertaste");
        }
        else
        {
            Console.WriteLine("Fallaste");
        }

        Console.WriteLine("Colosio fue asesinado por " + ASESINO[0] + " en " + ASESINO[1] + " con " + ASESINO[2]);

    }

    
    private static void preguntas()
    {
        int PREGUNTAS_DISPONIBLES = 5;
        
        for (PREGUNTAS_DISPONIBLES = 5; PREGUNTAS_DISPONIBLES>0; )
        {
            Console.WriteLine("Preguntas restantes: " + PREGUNTAS_DISPONIBLES + "\n" +
                            "1. Preguntar acerca de sospechoso\n" +
                            "2. Preguntar acerca de lugar\n" + 
                            "3. Preguntar acerca de arma" );

            int categoria = int.Parse(Console.ReadLine());

            if (categoria > 3 || categoria < 1)
            {
                Console.WriteLine("Opcion invalida");
            }
            else
            {
                categoria--;
                PREGUNTAS_DISPONIBLES--;

                Console.WriteLine(DICT_ELEMENTOS[categoria]);

                for (int elementos = 0; elementos < 5; elementos++)
                {
                    Console.WriteLine((elementos + 1) + ". " + DATOS[categoria, elementos]);
                }

                int eleccion = int.Parse(Console.ReadLine());

                validar_dato(categoria, eleccion);
            }
        }

    }


    private static void validar_dato(int categoria, int eleccion)
    {
        if (categoria > 5 || categoria < 0)
        {
            Console.WriteLine("Opcion invalida");
        }
        else
        {
            eleccion--;
            if(DATOS[categoria, eleccion] == ASESINO[categoria])
            {
                Console.WriteLine("SI");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
      

    private static void acusar()
    {
        sospecha = new string[] {"", "", ""};

        for (int categoria = 0; categoria < 3; )
        {
            Console.WriteLine(DICT_ELEMENTOS[categoria]);

            for (int elementos = 0; elementos < 5; elementos++)
            {
                Console.WriteLine((elementos + 1) + ". " + DATOS[categoria, elementos]);
            }

            int indice = int.Parse(Console.ReadLine());

            if(indice > 5 || indice < 0)
            {
                Console.WriteLine("Opcion invalida");
            }
            else
            {     
                indice--;
                sospecha[categoria] = DATOS[categoria, indice];

                categoria++;
            }
        
        }
    }
}
