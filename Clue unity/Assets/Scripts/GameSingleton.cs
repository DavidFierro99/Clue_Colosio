using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    static string[,] DATOS = new string[,] {{"Carlos S", "Mario A", "Ernesto Z", "Comandante M", "Joaquin G"},
                                            {"Lomas taurinas", "Aeropuerto", "Mitin", "Sede del partido", "Coche",},
                                            {"Pistola", "Cuchillo", "Playera del PRI", "Taco envenenado", "Carro de tamales"}};

    public string[] ASESINO;

    private static GameSingleton _instance;

    public static GameSingleton Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("Inside singleton");

            ASESINO = new string[]{DATOS[0, Random.Range(0, 5)],
                                   DATOS[1, Random.Range(0, 5)],
                                   DATOS[2, Random.Range(0, 5)],
                                   };

            Instance = this;
        }
    }
}
