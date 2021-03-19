using System.Linq;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    static string[] SOSPECHOSOS = new string[] { "Carlos S", "Mario A", "Ernesto Z", "Subcomandante M", "Joaquin G" };

    static string[] LUGARES = new string[] { "Lomas taurinas", "Aeropuerto", "Mitin", "Sede del partido", "Coche" };

    static string[] ARMAS = new string[] { "Pistola", "Cuchillo", "Playera del partido", "Taco envenenado", "Olla de pozole" };

    public string[] ASESINO;

    public string[][] INOCENTES;

    public bool FIN;

    public static GameSingleton Instance { get;  set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);

            SetValores();

            Instance = this;
        }
    }

    
    public void SetValores()
    {
        FIN = false;

        ASESINO = new string[] {SOSPECHOSOS[Random.Range(0, 5)],
                                    LUGARES[Random.Range(0, 5)],
                                    ARMAS[Random.Range(0, 5)],
                                    };

        INOCENTES = new string[][] {SOSPECHOSOS.Where(o=> o != ASESINO[0]).ToArray(),
                                        LUGARES.Where(o=> o != ASESINO[1]).ToArray(),
                                        ARMAS.Where(o=> o != ASESINO[2]).ToArray()};


        Debug.Log(ASESINO[0] + "/" + ASESINO[1] + "/" + ASESINO[2]);
    }
}
