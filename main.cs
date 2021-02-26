using System;


class MainClass {
  public static void Main (string[] args) {

    var rand = new Random();

    Console.WriteLine ("Tijuana, 23 de marzo de 1994...");

    string[] sospechosos = {"Carlos S", "Mario A", "Ernesto Z", "Comandante M", "Diego M"};

    string[] lugares = {"Lomas taurinas", "Aeropuerto", "Mitin", "Sede del partido", "Coche"};

    string[] armas = {"Pistola", "Cuchillo", "Playera del PRI", "Taco envenenado", "Carro de tamales"}; 

    string[] asesino = {sospechosos[rand.Next(0,5)], lugares[rand.Next(0,5)], armas[rand.Next(0,5)]};
    
    Console.WriteLine("Colosio fue asesinado por " + asesino[0] + 
                      " en " + asesino[1] + " con " + asesino[2]);
  }
}