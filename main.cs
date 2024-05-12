using System;
using System.Collections.Generic; // Dependencia para usar Listas
using System.Text.RegularExpressions; // Dependencia para usar Expresiones regulares

namespace Program {
    class Reglamento{
    // Atributos de instancia
    public String _reglamento_nombre_año;
    public List<String> _lista_de_requisitos;  
    
    // Constructor
    public Reglamento(String _reglamento_nombre_año, List<String> _lista_de_requisitos){
        this._reglamento_nombre_año = _reglamento_nombre_año;
        this._lista_de_requisitos = _lista_de_requisitos;
    }

    /*
    Uso: valida que el usuario que lo que ingrese el usuario osea el nombre del reglamento coincida con el nombre del reglamento de una de las instancias o si coincide con el numero asignado al nombre del reglamento ejemplo:

    1. reglamento beca 2024
    2. reglamento adminsion 2025
    3. reglamento cualquier cosa 2024

    -> Debera ingresar el usuario el numero asignado del reglamento o el nombre del reglamento. Si quisiera elegir el reglamento adminsion 2025 podria escribir el nombre mismo o el numero que en esta caso es 2
    Warning: !Solo el numero sin el punto¡ si hace el usuario ingresa esto 2. <- ¡No es valido! 
    correct: 2

    return: -> Esta metodo retorna un String que puede ser el nombre o el numero asignado ala clase toma como argumento
    
    String texto -> se usara para imprimir por consola

    List<object> list -> se usara para almacenar las instancias de la clase Reglamentos no ponemos List<Reglamentos por que dara error por accesibilidad para evitar eso hacemos List<object>

    int contador -> con este manejamos el indice simplemente

    En C#, puedes crear una lista que pueda almacenar cualquier tipo de dato utilizando el tipo object. El tipo object es la clase base para todos los tipos en el sistema de tipos de C#. Esto significa que cualquier tipo de dato se puede asignar a una variable de tipo object.

    ejemplo de cómo crear una lista que puede almacenar cualquier tipo de dato utilizando List<object>:

        // Crear una lista que puede almacenar cualquier tipo de dato
        List<object> miLista = new List<object>();

        // Agregar diferentes tipos de datos a la lista
        miLista.Add(123);         // Entero
        miLista.Add("Hola");      // Cadena
        miLista.Add(3.14);        // Doble
        miLista.Add(true);        // Booleano
        miLista.Add(new MiClase());// Objeto de una clase personalizada

        // Recorrer la lista e imprimir los elementos
        foreach (var elemento in miLista)
        {
            Console.WriteLine(elemento);
        }

    */
    public static String validarInputReglamento(String texto,List<Reglamento> lista_reglamento){
        int contador = 0;
        String ?input;
        Boolean existe;
        while (true){
            existe = false;
            System.Console.Clear();
            System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
            System.Console.WriteLine(texto);
            System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
            input = System.Console.ReadLine();
            // i va tener instancias de la clase reglamento
            // String.IsNullOrEmpty es en mayuscula si hacemos string.IsNullOrEmpty no es valido
            if (String.IsNullOrEmpty(input)){
                System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                System.Console.WriteLine(value: $"Error input: ingrese el numero del reglamento o el nombre del reglamento (presione enter para continuar)");
                System.Console.ReadKey();
                continue;
            }else if (!string.IsNullOrEmpty(input) && input.ToLower() == "exit"){
                // falta
                return "exit";
            }
            foreach (var i in lista_reglamento){
                System.Console.WriteLine($"{i._reglamento_nombre_año}\n");
                if (!string.IsNullOrEmpty(input) && i._reglamento_nombre_año == input.ToLower()){
                    existe = true;
                    break;
                }
                contador++;
            }
            if (existe){
                // Rompemos el bucle ya que el usuario ingreso bien el nombre reglamento
                break;
            }
            // validamos si todos los caracteres son numeros
            if (!string.IsNullOrEmpty(input) && input.All(predicate: char.IsDigit)){
                for (int i = 1; i <= contador; i++){
                    /*
                    En C#, puedes convertir un string a un int utilizando el método int.Parse() o int.TryParse(). Aquí tienes ejemplos de ambos métodos:

                    int.Parse(): Este método lanza una excepción si la cadena no puede ser convertida a un entero.

                    string texto = "123";
                    int numero = int.Parse(texto);

                    int.TryParse(): Este método intenta realizar la conversión y devuelve un valor booleano indicando si la conversión fue exitosa. Si la conversión es exitosa, el resultado se almacena en una variable de salida.

                    string texto = "123";
                    int numero;
                    bool exito = int.TryParse(texto, out numero);
                    if (exito){
                        // La conversión fue exitosa
                    }else{
                        // La conversión falló
                    }

                    */
                    if (i == int.Parse(input)){
                        return lista_reglamento[i-1]._reglamento_nombre_año;
                    }else{
                        continue;
                    }
                }
            }
            
            contador = 0;
            continue;
        }
        return lista_reglamento[contador]._reglamento_nombre_año;
    }

    /*
    Lo que hace este metodo es añadir un nuevo item al atributo this._lista_de_requisitos debe ser de tipo String
    */
    public void añadirNuevoRequisito(String nuevo_requisito){
        this._lista_de_requisitos.Add(item: nuevo_requisito);
        return;
    }

    public Boolean verSiExisteRequisito(string requisito){
        foreach (String i in this._lista_de_requisitos)
        {
            if (i == requisito){
                return true;
            }else{
                continue;
            }

        }
        return false;
    }

    // validaremos si el input del usuario coincide con un reglamento
}
    public class Program{
        
        // para validar el año del reglamento
        public static Boolean validarAño(String texto){
            if (!String.IsNullOrEmpty(value:texto) &&
                char.IsDigit(c: texto[texto.Length - 1]) == true &&
                char.IsDigit(c:texto[texto.Length - 2]) == true &&
                char.IsDigit(c:texto[texto.Length - 3]) == true &&
                char.IsDigit(c:texto[texto.Length - 4]) == true){
                    return true;
                    // acceder al ultimo caracter
                    // System.Console.WriteLine(value: char.ToLower(texto[texto.Length - 1])); 
                }
            return false;
        }

        /* 
        Esta metodo lo que hace validar lo siguiente
        - Reglamento <no deben ir numeros aqui debe ser un caracter != a espacio>
        */
        public static Boolean validarCampo(String texto){
            // Creamos una instancia de la clase Regex de expresiones regulares
            Regex regex = new Regex(pattern: "^[ \t\n\r\f\v0-9a-zA-Z_$%-]+$");
            if (!String.IsNullOrEmpty(value: texto) && 
            regex.IsMatch(input: texto) == true){

                    /*
                    1. `[ \t\n\r\f\v0-9a-zA-Z_$%-]+`: Esta es una clase de caracteres que coincide con uno o más de los siguientes caracteres:

                    2. ` `: Un espacio en blanco.

                    3. `\t`: Un carácter de tabulación.

                    4. `\n`: Un salto de línea.

                    5. `\r`: Un retorno de carro.

                    6. `\f`: Un avance de página.

                    7. `\v`: Un tabulador vertical.

                    8. `0-9`: Cualquier dígito del 0 al 9.

                    9. `a-zA-Z`: Cualquier letra mayúscula o minúscula.

                    10. `_$%-`: Los caracteres `_`, `$`, `%` y `-`.

                    11. `+`: Indica que la clase de caracteres anterior (que puede contener espacios, dígitos, letras, y los caracteres `_`, `$`, `%` y `-`) puede aparecer una o más veces.

                    12. `$`: Coincide con el final de la cadena.

                    13. El metodo IsMatch -> Regex.IsMatch("^[ \t\n\r\f\v0-9a-zA-Z_$%-]+$") verifica si la cadena coincide con la expresión regular.
                    */
                return true;
            }
            return false;
        }
        public static String validarInputUsuario(String texto){
            String ?input;
            // Referencia para char -> char.ToUpper(input[0])

            /*
            1. La logica es la siguiente primero se valida si la variable input es null
            
            2. lo siguiente que se hace es determinar la longitud del reglamento sea mayor a 17 
            la razon por que sea mayor a 17 es esta -> Eje: Reglamento x 2024 -> el nombre del reglamento debe tener como minimo 1 caracter si es el caso -> En total habria 17
            caracters contando desde el 1 claro
            
            3. luego lo que hice fue acceder a una subcadena de la misma manera que lo haces en Python con la notación de slicing ejemplo -> x: str = "daniel perez morales"; print(x[0:10:1]). Aunque es en c# no existe esta notacion lo que se hace es usaar el metodo <variable>.Substring(inicio,fin) reitero funciona distinto. Un ejemplo podria ser  <variable>.Substring(10,4) empezamos desde el caracter #10 y terminamos en el caracters #4. Es diferente en python!. y luego lo convertimos a minuscula la cadena al final

            4. llamo al metodo Program.validarAño(input.Substring(input.Length - 4, 4).ToLower()) que retorna un bool y lo que hace es valida si los ultimos 4 caracteres son digitos nada mas

            5. llamo al metodo Program.validarCampo(input.Substring(11,input.Length - 15).ToLower()) que retorna un bool lo que hace es que el nombre del reglamento no tenga numeros

            6. Si en casa de que no se cumpla ninguno de los casos repite el proceso
            */
            while (true){
                System.Console.Clear(); // borramos pantalla
                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.WriteLine(value: texto);
                System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                input = System.Console.ReadLine();
                if (!String.IsNullOrEmpty(input) && input.ToLower() == "exit"){
                    return input.ToLower();
                }
                // System.Console.WriteLine(value: $"len ->{input.Substring(11,input.Length - 15)}$");
                // System.Console.WriteLine(value: $"new_len = {input}");
                // System.Environment.Exit(1);
                if (input != null && input.Length >= 17 && 
                input.Substring(startIndex: 0,length: 11).ToLower() == "reglamento " &&
                // Extraemos los ultimos 4 caracteres
                Program.validarAño(texto: input.Substring(startIndex: input.Length - 4,length: 4).ToLower()) == true &&
                // Extraemos los caracters empezando desde el caracter #11 hasta terminar #4 caracteres antes del final de la cadena
                Program.validarCampo(texto: input.Substring(startIndex: 11,length:input.Length - 15).ToLower()) == true){
                    break;
                }else{
                    // Si no se cumplen las condiciones le volvemos a pedir al usuario que ingrese correctamente
                    System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                    System.Console.WriteLine(value: "Input Invalido ingrese correctamente el formato eje: (reglamento beca 2024) presion enter para continuar");
                    System.Console.ReadKey();
                    continue;
                }
            }
            return input.ToLower();
        }


        public static void Main(){ 
            List<Reglamento> lista_reglamento = new List<Reglamento>();
            /*
            Ejemplo Crear una lista bidimensional de cadenas

            Ejemplo Agregar sublistas a la lista principal
            lista_de_requisitos_temporal.Add(item:new List<String>());
            lista_de_requisitos_temporal.Add(item:new List<String>());
            lista_de_requisitos_temporal.Add(item:new List<String>());

            Ejemplo Agregar elementos a las sublistas
            lista_de_requisitos_temporal[0].Add(item:"Requisito 1-1");
            lista_de_requisitos_temporal[0].Add(item:"Requisito 1-2");
            */
            List<List<String>> lista_de_requisitos_temporal = new List<List<String>>();
            // año es para pedirle al usuario que ingrese el año
            // contador es una variable que usaremos para llevar un conteo de los requisitos del reglamento en año en especifico

            // y contador lista sirve para llevar un control sobre la lista bidimensional usando la variable como indice
            int numero_requisito_a_borrar,indice,contador,contador_lista = 0;

            // booleano para saber si existe el reglamento
            Boolean existe;
            // para pedir datos al usuario
            String ?input,reglamento_nombre_año, cadena;
            
            // Para testear warnings
            // System.Console.ReadKey();

            while (true)
            {
                System.Console.Clear();
                // Establece el color de fondo y el color del texto utilizando secuencias de escape ANSI

                // Console.BackgroundColor = System.ConsoleColor.Blue;
                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.Write(value: "1. ");
                System.Console.ForegroundColor = System.ConsoleColor.White;
                System.Console.WriteLine(value: "Crear un nuevo reglamento (año)");

                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.Write(value: "2. ");
                System.Console.ForegroundColor = System.ConsoleColor.White;
                System.Console.WriteLine(value: "Añadir un requisito a un reglamento que ya existe");

                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.Write(value: "3. ");
                System.Console.ForegroundColor = System.ConsoleColor.White;
                System.Console.WriteLine(value: "Ver todos los requisitos de un reglamento en especifico");

                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.Write(value: "4. ");
                System.Console.ForegroundColor = System.ConsoleColor.White;
                System.Console.WriteLine(value: "Ver todos los reglamentos");

                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.Write(value: "5. ");
                System.Console.ForegroundColor = System.ConsoleColor.White;
                System.Console.WriteLine(value: "Eliminar un requisito");


                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.Write(value: "6. ");
                System.Console.ForegroundColor = System.ConsoleColor.White;
                System.Console.WriteLine(value: "Eliminar un reglamento");

                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.Write(value: "7. ");
                System.Console.ForegroundColor = System.ConsoleColor.White;
                System.Console.WriteLine(value: "Salir");

                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                System.Console.Write(value:"\nSelecciona su opcion 1-7 -> ");
                System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                input = System.Console.ReadLine();
                existe = false;
                contador = 0;
                indice = 0;

            
                // reglamento_nombre_año = Program.validarInputUsuario("Digite el año ej: -> (2024) para crear el nuevo reglamento");
                // System.Console.WriteLine(value: $"Reglamento -> {reglamento_nombre_año}");
                // System.Environment.Exit(exitCode:1);
                switch (input){
                    case "1":                    

                        reglamento_nombre_año = Program.validarInputUsuario("Digite el año ej: -> (reglamento beca 2024) para crear el nuevo reglamento o ingrese exit para regresar al menu principal");
                        if (reglamento_nombre_año == "exit"){
                            break;
                        }

                        System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                        // System.Console.WriteLine(value: $"Reglamento -> {reglamento_nombre_año}");
                        // Verificar si la lista está vacía o si el año no está presente en la lista
                        //  con metodo de compresion de lista -> !lista_reglamento.Any(i => i._reglamento_nombre_año == año)
                        
                        foreach (Reglamento i in lista_reglamento){
                            if (i._reglamento_nombre_año == reglamento_nombre_año){
                                System.Console.ForegroundColor = System.ConsoleColor.Red;
                                System.Console.WriteLine(value: $"En el sistema ya existe el -> {reglamento_nombre_año}");
                                existe = true;
                                break;
                            }else{
                                
                                continue;
                            }
                        }
                        // existe == true y existe ambas son validas
                        if (!existe){
                            while (true)
                            {
                                System.Console.Clear(); // Limpiar la terminal
                                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                System.Console.WriteLine(value: $"Ingresa el requisito para el reglamento {reglamento_nombre_año}:");
                                System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                                input = System.Console.ReadLine();
                                if (!string.IsNullOrEmpty(input)){
                                    break;
                                }else if (string.IsNullOrEmpty(input)){
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                    System.Console.WriteLine(value: "ingrese nuevamente las indicaciones solicitadas (presione enter para continuar)");
                                    System.Console.ReadKey();
                                    continue;
                                }
                            }
                            
                            // añadimos una nuevo indice al lista bidimensional
                            if (!String.IsNullOrEmpty(value: input)){
                                lista_de_requisitos_temporal.Add(item:new List<String>());
                                /*
                                - Si es distino a null

                                1. añadimos el input a una lista llamada lista_de_requisitos_temporal en el ultima posicion esos manejo de posicion o indexacion lo hacemos con la variable contador_lista que va incrementando de uno en uno despues que se añade un item

                                2. añadimos ala lista donde almacenamos todas las instancias de las class Reglamento en la ultima posicion

                                3. incrementamos contador_lista en 1
                                */
                                
                                lista_de_requisitos_temporal[contador_lista].Add(item:input.ToLower());
                                lista_reglamento.Add(item:new Reglamento(_reglamento_nombre_año: reglamento_nombre_año, _lista_de_requisitos: lista_de_requisitos_temporal[contador_lista]));
                                contador_lista++;

                                // preguntar si quiere añadir otro requisito
                                while (true){
                                    System.Console.Clear();
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                    System.Console.WriteLine(value: $"desea añadir otro requisito al reglamento -> {reglamento_nombre_año} (s/n) ");
                                    
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                                    input = System.Console.ReadLine();
                                    // validamos al que el usuario ingrese si o no
                                    if (!String.IsNullOrEmpty(value: input) && input.ToLower() == "s" || !String.IsNullOrEmpty(value: input) &&input.ToLower() == "si"){
                                        foreach (Reglamento i in lista_reglamento){
                                            if (i._reglamento_nombre_año == reglamento_nombre_año){
                                                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                                System.Console.WriteLine(value: $"Añade el nuevo requisito para el {i._reglamento_nombre_año}");
                                                System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                                                input = System.Console.ReadLine();
                                                // validamos que la cadena no sea null y que el requisito no exista en la instancia
                                                if (!String.IsNullOrEmpty(value: input) && !i.verSiExisteRequisito(requisito: input.ToLower())){
                                                    i.añadirNuevoRequisito(nuevo_requisito: input.ToLower());
                                                    System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                                                    System.Console.WriteLine(value: $"\nRequisito #{i._lista_de_requisitos.Count} {input.ToLower()} -> añadido al {i._reglamento_nombre_año}");
                                                    System.Console.ReadKey();
                                                    existe = true;
                                                    break;
                                                }else if (!String.IsNullOrEmpty(value: input) && i.verSiExisteRequisito(requisito: input.ToLower())){
                                                    System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                                    System.Console.WriteLine($"El requisito {input.ToLower()} ya existe en el {i._reglamento_nombre_año}");
                                                    System.Console.ReadKey();
                                        
                                                }else if (String.IsNullOrEmpty(value: input)){
                                                    // si en dado caso que de null la variable input imprimimos por consola y finalizamos el programa con codigo de salida diferente de 0 -> osea error
                                                    System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                                    System.Console.WriteLine(value: "Warning: variable == null");
                                                    System.Console.WriteLine(value: "ingrese nuevamente las indicaciones solicitadas (presione enter para continuar)");
                                                    
                                                    System.Console.ReadKey();
                                                    // System.Environment.Exit(exitCode: 1);
                                                    continue;
                                                }
                                            
                                        }else{
                                            continue;
                                        }
                                    }
                                    }else if (!String.IsNullOrEmpty(value: input) && input.ToLower() == "n" || !String.IsNullOrEmpty(value: input) &&input.ToLower() == "no"){
                                        break;
                                    }else{
                                        System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                        System.Console.Write(value: "Input error: ");
                                        System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                                        System.Console.WriteLine(value: "ingrese s -> si o n -> no (enter para continuar)");
                                        System.Console.ReadKey();
                                        continue;
                                    }
                                }
                            }else if (String.IsNullOrEmpty(value: input)){
                                // si en dado caso que de null la variable input imprimimos por consola y finalizamos el programa con codigo de salida diferente de 0 -> osea error
                                System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                System.Console.WriteLine(value: "Warning: variable == null");
                                System.Console.WriteLine(value: "ingrese nuevamente las indicaciones solicitadas (presione enter para continuar)");
                                
                                System.Console.ReadKey();
                                // System.Environment.Exit(exitCode: 1);
                                continue;
                            }
                            
                            // lista_de_requisitos_temporal.Clear(); metodo para borrar todos los item de una lista -> array
                        }
                        System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                        System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                        System.Console.ReadKey();
                        break;
                    case "2":
                    if (lista_reglamento.Count == 0){
                        System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                            System.Console.WriteLine(value: "No hay ningun reglamento disponible");
                            System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                            System.Console.ReadKey();
                            continue;
                        }
                        cadena = "Reglamentos disponibles\n";
                        foreach (Reglamento i in lista_reglamento){
                            contador++;
                            System.Console.ForegroundColor = System.ConsoleColor.Blue;
                            cadena += $"\n{contador}. ";

                            System.Console.ForegroundColor = System.ConsoleColor.White;
                            cadena += $"{i._reglamento_nombre_año}\n";
                        }
                        cadena += "\nNombre del reglamento ejemplo: -> (reglamento beca 2024) para ver todos sus requisitos o ingrese el numero asociado al reglamento ejemplo: (1) para regresar al menu ingrese exit para regresar al menu principal";

                        reglamento_nombre_año = Reglamento.validarInputReglamento(texto: cadena,lista_reglamento: lista_reglamento);
                        if (reglamento_nombre_año == "exit"){
                            break;
                        }
                        foreach (Reglamento i in lista_reglamento){
                            if (i._reglamento_nombre_año == reglamento_nombre_año){
                                System.Console.Clear();
                                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                System.Console.WriteLine(value: $"Añade el nuevo requisito para el {i._reglamento_nombre_año}");
                                System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                                input = System.Console.ReadLine();
                                // validamos que la cadena no sea null y que el requisito no exista en la instancia
                                if (!String.IsNullOrEmpty(value: input) && !i.verSiExisteRequisito(requisito: input.ToLower())){
                                    i.añadirNuevoRequisito(nuevo_requisito: input.ToLower());
                                    System.Console.WriteLine(value: $"\nRequisito #{i._lista_de_requisitos.Count} {input.ToLower()} -> añadido al {i._reglamento_nombre_año}");
                                    existe = true;
                                    break;
                                }else if (!String.IsNullOrEmpty(value: input) && i.verSiExisteRequisito(requisito: input.ToLower())){
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                    System.Console.WriteLine($"\nEl requisito {input.ToLower()} ya existe en el {i._reglamento_nombre_año}");
                                    existe = true;
                                    System.Console.ReadKey();
                        
                                }else if (String.IsNullOrEmpty(value: input)){
                                    // si en dado caso que de null la variable input imprimimos por consola y finalizamos el programa con codigo de salida diferente de 0 -> osea error
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                    System.Console.WriteLine(value: "Warning: variable == null");
                                    System.Console.WriteLine(value: "ingrese nuevamente las indicaciones solicitadas (presione enter para continuar)");
                                    
                                    System.Console.ReadKey();
                                    // System.Environment.Exit(exitCode: 1);
                                    continue;
                                }
                                
                            }else{
                                continue;
                            }
                        }
                        
                        // existe == true ambas son validas
                        if (!existe){
                            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                            System.Console.WriteLine(value: $"No existe el -> {reglamento_nombre_año}");
                        }

                        System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                        System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                        System.Console.ReadKey();
                        break;
                    case "3":
                    if (lista_reglamento.Count == 0){
                        System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                            System.Console.WriteLine(value: "No hay ningun reglamento disponible");
                            System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                            System.Console.ReadKey();
                            continue;
                        }
                        /*
                        string cadena1 = "Hola";
                        string cadena2 = " mundo";

                        // Usando el operador +
                        string resultado1 = cadena1 + cadena2;
                        Console.WriteLine(resultado1); // Imprimirá: Hola mundo

                        // Usando el método Concat
                        string resultado2 = string.Concat(cadena1, cadena2);
                        Console.WriteLine(resultado2); // También imprimirá: Hola mundo
                        */
                        cadena = "Reglamentos disponibles\n";
                        foreach (Reglamento i in lista_reglamento){
                            contador++;
                            System.Console.ForegroundColor = System.ConsoleColor.Blue;
                            cadena += $"\n{contador}. ";

                            System.Console.ForegroundColor = System.ConsoleColor.White;
                            cadena += $"{i._reglamento_nombre_año}\n";
                        }
                        contador = 0;
                        cadena += "\nNombre del reglamento ejemplo: -> (reglamento beca 2024) para ver todos sus requisitos o ingrese el numero asociado al reglamento ejemplo: (1) para regresar al menu ingrese exit para regresar al menu principal";
                        
                        reglamento_nombre_año = Reglamento.validarInputReglamento(texto: cadena, lista_reglamento: lista_reglamento);
                        if (reglamento_nombre_año == "exit"){
                            break;
                        }
                        
                        foreach (Reglamento i in lista_reglamento){
                            if (i._lista_de_requisitos.Count == 0){
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                    System.Console.WriteLine(value: "No hay requisitos a borrar (enter para continuar)");
                                    System.Console.ReadKey();
                                    existe = true;
                                    break;
                                }
                            if (i._reglamento_nombre_año == reglamento_nombre_año){
                                foreach (String j in i._lista_de_requisitos){
                                    contador++;
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                    System.Console.Write(value: $"Requisito #{contador} -> ");
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                                    System.Console.WriteLine(value: $"{j}");
                                }
                                existe = true;
                                break;
                            }else{
                                continue;
                            }
                        }
                        
                        // existe == true ambas son validas
                        if (!existe){
                            System.Console.ForegroundColor = System.ConsoleColor.Red;
                            System.Console.WriteLine(value: $"No existe el -> {reglamento_nombre_año}");
                        }

                        contador = 0;
                        System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                        System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                        System.Console.ReadKey();
                        
                        break;
                    case "4":
                        if (lista_reglamento.Count == 0){
                            System.Console.ForegroundColor = System.ConsoleColor.Red;
                            System.Console.WriteLine(value: "No hay ningun reglamento disponible");
                            System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                            System.Console.ReadKey();
                            continue;

                        }
                        System.Console.Clear();
                        System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                        System.Console.WriteLine(value: "Reglamentos disponibles\n");
                        foreach (Reglamento i in lista_reglamento){
                            contador++;
                            System.Console.ForegroundColor = System.ConsoleColor.Blue;
                            System.Console.Write(value: $"{contador}. ");

                            System.Console.ForegroundColor = System.ConsoleColor.White;
                            System.Console.WriteLine(value: $"{i._reglamento_nombre_año}");
                        }
                        System.Console.ForegroundColor = System.ConsoleColor.Cyan;
                        System.Console.WriteLine(value: "\nPresion Enter o cualquier tecla");
                        System.Console.ReadKey();
                        break;
                    case "5":
                        if (lista_reglamento.Count == 0){
                            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                System.Console.WriteLine(value: "No hay ningun reglamento disponible");
                                System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                                System.Console.ReadKey();
                                continue;
                            }
                        
                        cadena = "Reglamentos disponibles\n";
                        foreach (Reglamento i in lista_reglamento){
                            contador++;
                            System.Console.ForegroundColor = System.ConsoleColor.Blue;
                            cadena += $"\n{contador}. ";

                            System.Console.ForegroundColor = System.ConsoleColor.White;
                            cadena += $"{i._reglamento_nombre_año}\n";
                        }
                        contador = 0;
                        cadena += "\nIngrese el nombre del reglamento eje: (reglamento beca 2024) o ingrese exit para regresar al menu principal";
                        // borrar requisitos
                        reglamento_nombre_año = Reglamento.validarInputReglamento(texto: cadena,lista_reglamento: lista_reglamento);
                        if (reglamento_nombre_año == "exit"){
                            break;
                        }
                        List<Reglamento> lista_reglamento_copia = new List<Reglamento>(lista_reglamento);
                        foreach (Reglamento i in lista_reglamento_copia){
                            System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                            
                            System.Console.WriteLine(value: $"{reglamento_nombre_año} ingrese el requisito que desea borrar");

                            if (i._reglamento_nombre_año == reglamento_nombre_año){
                                while (true){
                                    if (i._lista_de_requisitos.Count == 0){
                                        System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                        System.Console.WriteLine(value: "No hay requisitos a borrar (enter para continuar)");
                                        System.Console.ReadKey();
                                        break;
                                    }
                                    System.Console.Clear();
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                    System.Console.WriteLine(value: $"{reglamento_nombre_año}");
                                    // seccion para pedir al usuario el numero del requisito o nombre del requisito a borrar
                                    foreach (String j in i._lista_de_requisitos){
                                        contador++;
                                        System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                        System.Console.Write(value: $"Requisito #{contador} -> ");
                                        System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                                        System.Console.WriteLine(value: $"{j}");
                                    }
                                
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                                    System.Console.WriteLine(value: "\nIngrese el #<requsito> o el nombre del requisito a eliminar (ingrese exit para regresar al menu)");
                                    System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;

                                    input = System.Console.ReadLine();
                                    if (!String.IsNullOrEmpty(value: input) && input == "exit"){
                                        // lo asignamos true por que si no le asignamos la variable no saldra el mensaje de edvertencia de que no existe el reglamento
                                        existe = true;
                                        break;
                                    }else if (!String.IsNullOrEmpty(value: input) && input.All(predicate: char.IsDigit) && Convert.ToInt32(value: input) <= contador){
                                        numero_requisito_a_borrar = Convert.ToInt32(input) - 1;
                                        for (int k = 0; k < contador; k++){
                                            /*
                                            verificar que sea solo digitos
                                            string texto = "1234567890";
                                            bool solo_digitos = texto.All(char.IsDigit);
                                            */
                                            if (numero_requisito_a_borrar == k){
                                                    
                                                // borrar por indice
                                                lista_reglamento[indice]._lista_de_requisitos.RemoveAt(index: numero_requisito_a_borrar);

                                                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                                System.Console.WriteLine(value: $"requisito #{numero_requisito_a_borrar + 1} del {i._reglamento_nombre_año} eliminado con exito");
                                                System.Console.ReadKey();
                                                existe = true;
                                                break;
                                            }else{
                                                existe = false;
                                                continue;
                                            }
                                            
                                        }
                                    }else if (!String.IsNullOrEmpty(value: input)){
                                        // metodo para ver el len de una lista .Count
                                        for (int j = 0; j < i._lista_de_requisitos.Count;j++){
                                            if (input.ToLower() == lista_reglamento[indice]._lista_de_requisitos[j]){
                                                // borrar por valor
                                                lista_reglamento[indice]._lista_de_requisitos.Remove(item: input.ToLower());
                                                System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
                                                System.Console.Write(value: $"requisito {input.ToLower()} del {i._reglamento_nombre_año} eliminado con exito");
                                                System.Console.ReadKey();
                                                existe = true;
                                                break;
                                            }else{
                                                continue;
                                            }
                                        }
                                    }
                                    contador = 0;
                                    if (!existe){
                                        System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                                        System.Console.WriteLine(value: $"Error input: {input} no es un nombre o #<requisito> valido (presione enter para continuar)");
                                        System.Console.ReadKey();
                                        existe = false;
                                        continue;
                                    }
                                    
                                }
                                break;
                            }else{
                                indice++;
                                continue;
                            }
                        }

                        if (!existe){
                            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                            System.Console.WriteLine(value: $"No existe el -> {reglamento_nombre_año}");
                        }
                        System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                        System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                        System.Console.ReadKey();
                        lista_reglamento_copia.Clear();
                        break;
                    case "6":
                        if (lista_reglamento.Count == 0){
                        System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                            System.Console.WriteLine(value: "No hay ningun reglamento disponible");
                            System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                            System.Console.ReadKey();
                            continue;
                        }
                        cadena = "Reglamentos disponibles\n";
                        foreach (Reglamento i in lista_reglamento){
                            contador++;
                            System.Console.ForegroundColor = System.ConsoleColor.Blue;
                            cadena += $"\n{contador}. ";

                            System.Console.ForegroundColor = System.ConsoleColor.White;
                            cadena += $"{i._reglamento_nombre_año}\n";
                        }
                        cadena += "\nNombre del reglamento ejemplo: -> (reglamento beca 2024) para ver todos sus requisitos o ingrese el numero asociado al reglamento ejemplo: (1) para regresar al menu ingrese exit para regresar al menu principal";
                        //Borrar reglamento
                        reglamento_nombre_año = Reglamento.validarInputReglamento(texto: cadena, lista_reglamento: lista_reglamento);
                        if (reglamento_nombre_año == "exit"){
                            break;
                        }
                        foreach (Reglamento i in lista_reglamento){
                            if (i._reglamento_nombre_año == reglamento_nombre_año){
                                System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                                /*
                                - las listas en C# son estructuras de datos dinámicas que pueden crecer o reducir su tamaño según sea necesario.

                                Ejemplo 1 unidimensional Borrar por valor
                                
                                List<string> lista = new List<string>() {"elemento1", "elemento2", "elemento3"};

                                // Eliminar el elemento "elemento2" de la lista
                                lista.Remove("elemento2");

                                ---
                                
                                Ejemplo 2 unidimensional borrar por indice

                                List<string> lista = new List<string>() {"elemento1", "elemento2", "elemento3"};

                                // Eliminar el elemento en el índice 1 (elemento2)
                                lista.RemoveAt(1);

                                ---

                                Ejemplo bidireccional borrar por indice
                                List<List<string>> listaBidimensional = new List<List<string>>() {
                                new List<string>() {"a", "b", "c"},
                                new List<string>() {"d", "e", "f"},
                                new List<string>() {"g", "h", "i"}
                                };

                                // Supongamos que queremos eliminar el elemento "e" que está en la segunda lista (índice 1) y en la segunda posición (índice 1)
                                listaBidimensional[1].RemoveAt(1);
                                */
                                lista_reglamento.RemoveAt(index: contador - 1);
                                System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                                 System.Console.Clear();

                                System.Console.WriteLine(value: $"\nEl -> {reglamento_nombre_año} ha sido eliminado con exito del sistema\n");
                                existe = true;
                                break;
                            }else{
                                contador++;
                                continue;
                            }
                        }

                        if (!existe){
                            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                            System.Console.WriteLine(value: $"No existe el -> {reglamento_nombre_año}");
                        }
                        System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                        System.Console.WriteLine(value: "Presion Enter o cualquier tecla");
                        System.Console.ReadKey();
                        
                        break;
                    
                    case "7":
                        // Salir de la aplicación con codigo de salida 0 (exito)
                        System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                        System.Console.WriteLine(value: "Gracias por usar el programa");
                        System.Console.ReadKey();
                        // Restaura los colores originales de la terminal
                        Console.ResetColor();
                        System.Environment.Exit(0);
                        break;
                    default:
                        // Salir de la aplicación con codigo de salida 0 (exito)
                        System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
                        System.Console.WriteLine(value: "Error input: ingrese una opcion dentro del rango 1-7");
                        System.Console.ReadKey();
                        break;
                }
                // System.Console.ReadKey();
            }
            
        }
    }

}
