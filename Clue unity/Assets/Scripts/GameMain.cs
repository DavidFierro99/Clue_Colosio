using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMain : MonoBehaviour
{
    //
    static bool FIN;

    static int n_acusacion = 0;

    // Numero de preguntas que se tiene en el juego
    static int PREGUNTAS_DISPONBILES = 5;

    // Frase de confirmacion o negacion de sospecha
    static string frase;

    // Texto que muestra las preguntas restantes
    static Text n_Text;

    // Texto que muestra la frase de sospecha
    static Text textbox;

    // Texto que muestra la frase de sospecha
    static Text textbox_fin;

    // Indice que indica que se está sospechando, persona, lugar o arma
    static int sospecha_actual = -1;

    // Categorias del juego, constante
    static string[] DICT_ELEMENTOS = {"Sospechosos", "Lugares", "Armas"};

    // Arreglo donde se almacena al asesino, lugar y arma
    public string[] ASESINO;

    // Arreglo donde se almacena el resto de los datos del juego
    public string[][] INOCENTES;

    // Arreglo donde se guarda la acusacion generada por el jugador
    static string[] ACUSACION = new string[3] { "", "", "" };

    void Start()
    {
        /* 
         *  :descripcion:   Se llama al inicio de cada escena
         *  :param:         None
         *  :return:        None
         */

        // Instanciacion de ASESINO e INOCENTES. Se utiliza un Singleton para que la primera ve que se obtienen se haga de manera aleatoria, cuando
        // se llamen posteriormente el Singleton hace que se conserven los primeros valores
        ASESINO = GameSingleton.Instance.ASESINO;
        INOCENTES = GameSingleton.Instance.INOCENTES;
        FIN = GameSingleton.Instance.FIN;


        if (SceneManager.GetActiveScene().name == "Main")
        {
            // La escena a cargar es Main, actualiza el valor del contador y verifica que PREGUNTAS_DISPONIBLES > 0

            n_Text = GameObject.Find("/Canvas/n_preguntas").GetComponent<Text>();
            n_Text.text = PREGUNTAS_DISPONBILES.ToString();

            if (PREGUNTAS_DISPONBILES == 0 && !FIN)
            {
                GameSingleton.Instance.FIN = true;

                SceneManager.LoadScene("Acusacion");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Validar")
        {
            // La escena a cargar es Validar, muestra el resultado de la sospecha en textbox
            textbox = GameObject.Find("/Canvas/texto_sos").GetComponent<Text>();
            textbox.text = frase;
        }
        else if (SceneManager.GetActiveScene().name == "Fin")
        {
            textbox_fin = GameObject.Find("/Canvas/texto_fin").GetComponent<Text>();
            textbox_fin.text = frase;
        }
    }
    

    public void Preguntar(int escena)
    {
        /* 
         * :descripcion:    Carga las escenas de cada uno de los elemento
         * :param escena:   Indice de la escena a cargar
         *                      0 - Sospechosos
         *                      1 - Lugares
         *                      2 - Armas
         * :return:         None
         */

        // Baja el contador de preguntas disponibles una unidad
        PREGUNTAS_DISPONBILES--;

        sospecha_actual = escena;

        SceneManager.LoadScene(DICT_ELEMENTOS[escena]);
    }


    public void Volver()
    {
        /* 
         * :descripcion:    Carga la escena Main
         * :param:          None
         * :return:         None
         */

        SceneManager.LoadScene("Main");
    }


    public void Sospecha(string eleccion)
    {
        /* 
         * :descripcion:    Metodo llamado cuando se hace una sospecha, la compara con el dato correspondiente guardado en ASESINO y genera la frase positiva
         *                  o negativa, posteriormente carga la escena Validar
         * :param eleccion: String del elemento que selecciono el jugador, puede ser persona, lugar o arma
         * :return:         None
         */
        if (FIN == false)
        {
            if (eleccion == ASESINO[sospecha_actual])
            {
                GenerarFrases(true, eleccion);
            }
            else
            {
                GenerarFrases(false, eleccion);
            }

            SceneManager.LoadScene("Validar");
        }
        else
        {
            ACUSACION[n_acusacion] = eleccion;

            n_acusacion++;

            if (n_acusacion < 3)
                SceneManager.LoadScene(DICT_ELEMENTOS[n_acusacion]);
            else
            {
                if (ACUSACION[0] == ASESINO[0] && ACUSACION[1] == ASESINO[1] && ACUSACION[2] == ASESINO[2])
                    frase = "Acertaste";
                else
                    frase = "Fallaste";

                Debug.Log(frase);
                SceneManager.LoadScene("Fin");
            }

        }
    }


    public void GenerarFrases(bool culpable, string eleccion)
    {
        /* 
         * :descripcion:    Genera frases positivas o negarivas dependiendo el valos de culpable, la frase es mostrada en la escena Validar
         * :param culpable: Booleano que indica si la sospecha fue acertada o no
         * :param eleccion: String del elemento que selecciono el jugador, puede ser persona, lugar o arma
         */

        int pistas = Random.Range(1,4);

        if (culpable)
        {
            if (DICT_ELEMENTOS[sospecha_actual] == "Sospechosos")
                frase = "No se puede ubicar a " + eleccion + " en el momento del asesinato";
            else
                frase = "Se encontraron rastros de sangre en " + eleccion;
        } 
        else
        {
            if (DICT_ELEMENTOS[sospecha_actual] == "Sospechosos")
                frase = eleccion + " tiene una coartada solida.";
            else
                frase = "No se encontraron rastros de sangre en " + eleccion +
                        ". Testigos afirman que no vieron nada raro.";
                       
            frase += "\n\nLa investigacion tambien descartó:";
            for (int i = 0; i<= pistas; i++)
            {
                int cat_pista = Random.Range(0,3);
                frase += "\n" + DICT_ELEMENTOS[cat_pista] + ": " + INOCENTES[cat_pista][Random.Range(0,4)];
            }
        }

    }
     
    public void Salir()
    {
        /* 
         * :descripcion:    Permite salir del juego
         * :param:          None
         * :return:         None
         */
        
        Application.Quit();
    }


    public void Reiniciar()
    {
        /* 
         * :descripcion:    Reinicia todas las variables necesarias para iniciar una nueva partida
         * :param:          None
         * :return:         None
         */

        // La funcion SetValores vuelve a configurar todas las variables que se guardan en el Sigleton
        GameSingleton.Instance.SetValores();
        
        // Se reinica el contador de preguntas y el indice para la acusacion
        PREGUNTAS_DISPONBILES = 5;
        n_acusacion = 0;

        // Se carga la escena Main
        SceneManager.LoadScene("Main");
    }
}
