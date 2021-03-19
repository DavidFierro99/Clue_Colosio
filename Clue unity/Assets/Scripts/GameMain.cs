using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMain : MonoBehaviour
{   
    static int PREGUNTAS_DISPONBILES = 5;

    static Text n_Text;

    // Categorias del juego, constante
    static string[] DICT_ELEMENTOS = {"Sospechosos", "Lugares", "Armas"};
    
    // Elementos del juego, personas, lugares y armas
    static string[,] DATOS = new string[,] {{"Carlos S", "Mario A", "Ernesto Z", "Comandante M", "Joaquin G"},
                                            {"Lomas taurinas", "Aeropuerto", "Mitin", "Sede del partido", "Coche",},
                                            {"Pistola", "Cuchillo", "Playera del PRI", "Taco envenenado", "Carro de tamales"}};
    
    public string[] ASESINO;

    static string[] sospecha;

    // Start is called before the first frame update
    void Start()
    {
        ASESINO = GameSingleton.Instance.ASESINO;
        Debug.Log(ASESINO[0] + "/" + ASESINO[1] + "/" + ASESINO[2]);

        n_Text = GameObject.Find("/Canvas/n_preguntas").GetComponent<Text>();
        n_Text.text = PREGUNTAS_DISPONBILES.ToString();
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void pregunta(string escena)
    {
        PREGUNTAS_DISPONBILES--;
        SceneManager.LoadScene(escena);
    }


    public void volver()
    {
        SceneManager.LoadScene("Main");
    }
    
}
