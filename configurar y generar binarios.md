<!-- Autor: Daniel Benjamin Perez Morales -->
<!-- GitHub: https://github.com/DanielPerezMoralesDev13 -->
<!-- Correo electrónico: danielperezdev@proton.me  -->
# ***Comandos c# projects***

```bash
dotnet build -c Release
```

- **`dotnet`**: *Este es el comando principal de la CLI de .NET Core. Se utiliza para realizar diversas tareas relacionadas con proyectos .NET Core, como compilar, ejecutar, publicar y más.*

- **`build`**: *Es un subcomando de `dotnet` que se utiliza para compilar un proyecto .NET Core. Cuando ejecutas `dotnet build`, el SDK de .NET Core compila el proyecto y genera los archivos de salida según la configuración definida en el archivo de proyecto (`csproj`).*

- **`-c Release`**: *Esta es una opción que se pasa al subcomando `build`. La opción `-c` o `--configuration` se utiliza para especificar la configuración de compilación que se debe utilizar. En este caso, se ha especificado `Release`, lo que indica que se debe compilar el proyecto en modo de liberación. El modo de liberación suele implicar la optimización del código y la exclusión de símbolos de depuración, lo que resulta en un binario más pequeño y más eficiente.*

*Entonces, en resumen, el comando `dotnet build -c Release` se utiliza para compilar un proyecto .NET Core en modo de liberación, lo que genera los archivos de salida correspondientes (como ensamblados DLL) listos para ser ejecutados o distribuidos.*

## ***Ejecutar***

```bash
dotnet /home/d4nitrix13/Desktop/Poo/bin/Release/net8.0/Poo.dll
```

## ***Para generar el binario con .NET y especificar el nombre del binario, puedes utilizar el comando `dotnet publish` con la opción `--output` para especificar el directorio de salida y la opción `--configuration` para especificar la configuración de compilación (por ejemplo, `Release` para producción). Aquí tienes cómo hacerlo:***

```bash
dotnet publish -c Release -o DirectorioDeSalida /p:PublishSingleFile=true /p:PublishTrimmed=true /p:PublishReadyToRun=true
```

- *`-c Release`: Especifica que se debe usar la configuración de compilación Release, que normalmente está optimizada para producción.*

- *`-o DirectorioDeSalida`: Especifica el directorio donde se colocarán los archivos publicados. Reemplaza `DirectorioDeSalida` con la ruta deseada.*

- *`/p:PublishSingleFile=true`: Esta opción empaqueta la aplicación en un solo archivo ejecutable.*

- *`/p:PublishTrimmed=true`: Esta opción realiza la poda de las dependencias no utilizadas para reducir el tamaño del archivo binario.*

- *`/p:PublishReadyToRun=true`: Esta opción precompila el código para mejorar el rendimiento de inicio.*

## ***Para generar un binario específicamente para Windows con .NET, puedes especificar la plataforma de destino utilizando la opción `--runtime`. Aquí tienes cómo hacerlo:***

```bash
dotnet publish -c Release -r win-x64 -o DirectorioDeSalidaWindows /p:PublishSingleFile=true /p:PublishTrimmed=true /p:PublishReadyToRun=true
```

- *`-r win-x64`: Esto especifica que el binario debe ser compilado para la plataforma de destino Windows x64. Si deseas compilar para otra arquitectura, puedes cambiar `win-x64` a `win-x86` para Windows de 32 bits o `win-arm` para Windows en ARM, por ejemplo.*

- *El resto de las opciones (`-c Release`, `-o DirectorioDeSalida`, `/p:PublishSingleFile=true`, `/p:PublishTrimmed=true`, `/p:PublishReadyToRun=true`) son las mismas que se explicaron anteriormente.*

*Al ejecutar este comando, se generará un binario optimizado específicamente para Windows x64 en el directorio especificado por `-o`. Puedes ajustar las opciones según tus necesidades específicas.*

*Después de ejecutar este comando, encontrarás tu binario en el directorio especificado por `-o`.*
