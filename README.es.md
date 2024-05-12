<!-- Autor: Daniel Benjamin Perez Morales -->
<!-- GitHub: https://github.com/DanielPerezMoralesDev13 -->
<!-- Correo electrónico: danielperezdev@proton.me  -->
# ***Repositorio de Ejemplo en C#/.NET***

*Este repositorio contiene ejemplos de código en C#* ***para ayudarte a comenzar con el desarrollo en .NET. Incluye una guía básica de sintaxis de C# y las instrucciones para compilar para Windows y Linux.***

## ***Sintaxis Básica de C #***

### ***Variables y Tipos de Datos***

```csharp
int edad = 25;
string nombre = "Juan";
float altura = 1.75f;
bool es_estudiante = true;
```

### ***Estructuras de Control***

```csharp
// If-else
if (edad >= 18) {
    Console.WriteLine("Es mayor de edad");
} else {
    Console.WriteLine("Es menor de edad");
}

// Bucle for
for (int i = 0; i < 5; i++) {
    Console.WriteLine(i);
}

// Bucle while
int contador = 0;
while (contador < 3) {
    Console.WriteLine("Hola");
    contador++;
}
```

### ***Funciones***

```csharp
public void Saludar(string nombre) {
    Console.WriteLine("Hola, " + nombre);
}

// Llamada a la función
Saludar("Abella");
```

## ***Compilación para Windows***

1. *Asegúrate de tener instalado el SDK de .NET. Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download).*

2. *Abre una terminal y navega hasta el directorio del proyecto.*

3. *Ejecuta el siguiente comando para compilar:*

```bash
dotnet build -c Release -r win-x64
```

*Esto generará el ejecutable para Windows en la directorio `bin/Release/net5.0/win-x64/`.*

## ***Compilación para Linux***

1. *Asegúrate de tener instalado el SDK de .NET. Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download).*

2. *Abre una terminal y navega hasta el directorio del proyecto.*

3. *Ejecuta el siguiente comando para compilar:*

```bash
dotnet build -c Release -r linux-x64
```

*Esto generará el ejecutable para Linux en la directorio `bin/Release/net5.0/linux-x64/`.*

---

*Siéntete libre de expandir este README según sea necesario para incluir más información sobre tu proyecto o para adaptarlo a tus necesidades específicas.*
