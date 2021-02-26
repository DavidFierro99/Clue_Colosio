from random import randrange


    
datos = (("Carlos S", "Mario A", "Ernesto Z", "Comandante M", "Diego M"),
         ("Lomas taurinas", "Aeropuerto", "Mitin", "Sede del partido", "Coche"),
         ("Pistola", "Cuchillo", "Playera del PRI", "Taco envenenado", "Carro de tamales"))

elemento = {0: "Sospechosos:", 1: "Lugares", 2: "Armas"}

asesino = (datos[0][randrange(0,5)], datos[1][randrange(0,5)], datos[2][randrange(0,5)])

print(asesino)
    
def main():
    imprimir_header("Tijuana, México. 23 de marzo de 1994\n" +
          "Luis Donaldo Colosio ha sido asesinado.\n" +
          "Es tu deber como investigador de la PGR encontrar al culpable, buena suerte...")

    imprimir_header("Puedes hacer cinco preguntas, usalas sabiamente")

    preguntas()
    
    imprimir_header("Has utilizado todas tus preguntas, es momento de decidir quien fue el culpable")

       
def preguntas():
    
    PREGUNTAS_DISPONIBLES = 5
    
    for preguntas in range(PREGUNTAS_DISPONIBLES):
        
        imprimir_header("Preguntas restantes: " + str(PREGUNTAS_DISPONIBLES) + "\n" +
              "1. Preguntar acerca de sospechoso\n" +
              "2. Preguntar acerca de lugar\n" + 
              "3. Preguntar acerca de arma")
        
        entrada = eval(input("Introduce un dato. "))
        
        if entrada > 3 or entrada < 1:
            print("Opcion invalida")
            
        else:
            PREGUNTAS_DISPONIBLES = PREGUNTAS_DISPONIBLES - 1
            
            imprimir_header(elemento[entrada-1])
            for elementos in range(5):
                print(str(elementos + 1) + ". " + datos[entrada-1][elementos])
            
            entrada_2 = eval(input("Introduce un dato. "))
            
            print(validar_dato(entrada, entrada_2))
            

def validar_dato(entrada, entrada_2):
    
    if entrada > 5 or entrada < 1:
        print("Opcion invalida")
        
    else:
        if datos[entrada - 1][entrada_2 - 1] == asesino[entrada - 1]:
            return "Si"
        else:
            return "No"
    
    
def imprimir_header(mensaje):
    
    print("**********************************************************************************")
    print(mensaje)
    print("**********************************************************************************")
  
    
  
main()