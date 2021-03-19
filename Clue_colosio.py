from random import randrange

DICT_ELEMENTOS = {0: "Sospechosos", 1: "Lugares", 2: "Armas"}
    
datos = (["Carlos S", "Mario A", "Ernesto Z", "Comandante M", "Joaquin G"],
         ["Lomas taurinas", "Aeropuerto", "Mitin", "Sede del partido", "Coche"],
         ["Pistola", "Cuchillo", "Playera del PRI", "Taco envenenado", "Carro de tamales"])

asesino = (datos[0][randrange(0,5)], datos[1][randrange(0,5)], datos[2][randrange(0,5)])

personas_inocentes = datos[0].copy()
personas_inocentes.remove(asesino[0])

lugares_inocentes = datos[1].copy()
lugares_inocentes.remove(asesino[1])

objetos_inocentes = datos[2].copy()
objetos_inocentes.remove(asesino[2])

INOCENTES = (personas_inocentes, lugares_inocentes, objetos_inocentes)

def main():
    imprimir_header("Tijuana, México. 23 de marzo de 1994\n" +
          "Luis Donaldo Colosio ha sido asesinado.\n" +
          "Es tu deber como investigador de la PGR encontrar al culpable, buena suerte...")

    imprimir_header("Puedes hacer cinco preguntas, usalas sabiamente")

    preguntas()
    
    imprimir_header("Has utilizado todas tus preguntas, es momento de decidir quien fue el culpable")

    Sospecha = tuple(acusar())
    
    if Sospecha == asesino:
        print("Acertaste")
    else:
        print("Fallaste")
    
    
def preguntas():
    
    PREGUNTAS_DISPONIBLES = 5

    for preguntas in range(PREGUNTAS_DISPONIBLES):
        
        imprimir_header("Preguntas restantes: " + str(PREGUNTAS_DISPONIBLES) + "\n" +
                        "1. Preguntar acerca de sospechoso\n" +
                        "2. Preguntar acerca de lugar\n" + 
                        "3. Preguntar acerca de arma"
                        )
        
        categoria = eval(input("Introduce un dato. ")) 
        
        if categoria > 3 or categoria < 1:
            print("Opcion invalida")
            
        else:
            PREGUNTAS_DISPONIBLES = PREGUNTAS_DISPONIBLES - 1
            
            imprimir_header(DICT_ELEMENTOS[categoria-1])
            
            for elementos in range(5):
                print(str(elementos + 1) + ". " + datos[categoria-1][elementos])
            
            eleccion = eval(input("Introduce un dato. "))
            
            validar_dato(categoria, eleccion)
  
            
def acusar():
    Sospecha = []
    
    for categoria_datos in range(3):
        
        imprimir_header(DICT_ELEMENTOS[categoria_datos])
        
        for elementos in range(5):
            
            print(str(elementos + 1) + ". " + datos[categoria_datos][elementos])
        
        
        indice = eval(input("Introduce tu suposicion. ")) - 1
        Sospecha.append(datos[categoria_datos][int(indice)])
        
    return Sospecha

    
def generar_frases(culpable, categoria, eleccion):
    pistas = randrange(1,4)

    if culpable:
        if DICT_ELEMENTOS[categoria-1] == "Sospechosos":
           print("No se puede ubicar a " + datos[categoria - 1][eleccion - 1] + " en el momento del asesinato")
        else:
            print("Se encontraron rastros de sangre en " + datos[categoria - 1][eleccion - 1])
    
    else:
        if DICT_ELEMENTOS[categoria-1] == "Sospechosos:":
            print(datos[categoria - 1][eleccion - 1] + " tiene una coartada solida.")
        else:
            print("No se encontraron rastros de sangre en " + datos[categoria - 1][eleccion - 1] +
                    ". Testigos afirman que no vieron nada raro.")
        
                    
        print("La investigacion tambien descarto:")
        for i in range(1,pistas+1):
            cat_pista = randrange(3)
            print(DICT_ELEMENTOS[cat_pista] + ": " + INOCENTES[cat_pista][randrange(4)])

    
def validar_dato(categoria, eleccion):
    
    if categoria > 5 or categoria < 1:
        print("Opcion invalida")
        
    else:
        if datos[categoria - 1][eleccion - 1] == asesino[categoria - 1]:
            generar_frases(True, categoria, eleccion)
        else:
            generar_frases(False, categoria, eleccion)
    
    
def imprimir_header(mensaje):
    
    print("**********************************************************************************")
    print(mensaje)
    print("**********************************************************************************")
  

main()