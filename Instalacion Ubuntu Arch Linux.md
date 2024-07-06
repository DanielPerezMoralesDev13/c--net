<!-- Autor: Daniel Benjamin Perez Morales -->
<!-- GitHub: https://github.com/DanielPerezMoralesDev13 -->
<!-- Correo electrónico: danielperezdev@proton.me  -->
# ***Para instalar .NET Core en Ubuntu y Arch Linux, puedes seguir estos pasos***

## ***Instalación en Ubuntu***

1. *Abre una terminal.*
2. *Actualiza el índice del paquete:*

    ```bash
    sudo apt update
    ```

3. *Instala el paquete `apt-transport-https` que permite descargar paquetes desde repositorios HTTPS:*

    ```bash
    sudo apt install -y apt-transport-https
    ```

4. *Importa la clave de Microsoft GPG:*

    ```bash
    wget -q https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    ```

5. *Actualiza el índice del paquete nuevamente:*

    ```bash
    sudo apt update
    ```

6. *Instala el SDK de .NET Core:*

## ***apt search dotnet-sdk***

```bash
sudo apt search dotnet-sdk
```

```bash
sudo apt install -y dotnet-sdk-8.0
```

## ***snap find dotnet-sdk***

```bash
sudo snap find dotnet-sdk
```

```txt
Name        Version  Publisher    Notes    Summary
dotnet-sdk  8.0.204  dotnetcore✓  classic  Develop high performance applications in less time, on any platform.
```

```bash
sudo snap install dotnet-sdk --channel=3.1/stable
```

### ***Instalación en Arch Linux***

1. *Abre una terminal.*
2. *Instala el paquete `dotnet-sdk` desde los repositorios oficiales de Arch Linux:*

```bash
sudo pacman -S dotnet-sdk
```

*Una vez que hayas instalado .NET Core, puedes verificar si se instaló correctamente ejecutando el siguiente comando en la terminal:*

```bash
dotnet --version
```

*Esto debería imprimir la versión instalada de .NET Core en tu sistema.*

*Después de instalar .NET Core, puedes ejecutar tu aplicación .NET utilizando el comando `dotnet run`, seguido del nombre de tu archivo de programa.*

```bash
dotnet run ./main.cs
```

```bash
dotnet new console -o prueba
```

- *Para iniciar un proyecto de página web en ASP.NET usando .NET CLI (Command Line Interface), puedes seguir estos pasos básicos. ASP.NET proporciona plantillas y herramientas a través de .NET CLI que te permiten crear y gestionar proyectos de forma eficiente desde la línea de comandos.*

### ***Crear un Nuevo Proyecto ASP.NET***

**Para crear un proyecto de página web en ASP.NET, puedes usar el siguiente comando en la terminal:**

```bash
dotnet new web -n MiProyectoWeb
```

- *`dotnet new web`:** *Este comando crea un nuevo proyecto web en ASP.NET.*
- *`-n MiProyectoWeb`:** *Especifica el nombre del proyecto. Puedes cambiar `MiProyectoWeb` por el nombre que desees para tu proyecto.*

- *Este comando creará una estructura básica para tu proyecto web en ASP.NET.*

### ***Navegar al Directorio del Proyecto***

**Una vez que el proyecto se haya creado, navega al directorio del proyecto usando:**

```bash
cd MiProyectoWeb
```

### Ejecutar el Proyecto

**Para ejecutar tu proyecto web y verlo en tu navegador local, usa el siguiente comando:**

```bash
dotnet run
```

- **Esto iniciará el servidor web y te proporcionará una URL local (por lo general, `http://localhost:5000` o `https://localhost:5001`) donde puedes acceder a tu proyecto.**

### ***Abrir y Editar el Proyecto***

- *Puedes usar cualquier editor de texto o IDE compatible con .NET para abrir y editar tu proyecto. Algunas opciones populares son Visual Studio Code, Visual Studio (la versión adecuada para .NET Core/.NET 5+), JetBrains Rider, entre otros.*

### ***Opciones Avanzadas***

**Si necesitas configurar tu proyecto para usar un framework específico de ASP.NET (como MVC, Razor Pages, etc.), puedes especificarlo al crear el proyecto:**

```bash
dotnet new webapp -n MiProyectoWeb --framework net6.0
```

- **`webapp`:** *Especifica una plantilla de aplicación web que incluye opciones adicionales.*
- **`--framework net6.0`:** *Puedes especificar el framework específico que deseas usar. En este caso, `net6.0` es la versión actual de .NET.*

### ***Notas Adicionales**

- *A medida que desarrolles tu proyecto, puedes añadir más funcionalidades usando comandos como `dotnet add package` para agregar paquetes NuGet, o `dotnet build` para compilar tu proyecto.*
- *Para más información sobre opciones y comandos disponibles, puedes consultar la documentación oficial de .NET CLI y ASP.NET.*

- *Siguiendo estos pasos, estarás listo para iniciar y desarrollar tu proyecto de página web en ASP.NET usando .NET CLI desde la línea de comandos.*

> [!WARNING]
> *El error específico que mencionas, CS0453, se refiere al hecho de que estás utilizando el tipo string?, que es una anotación de referencia nula introducida en C# 8.0, pero no está soportada en compiladores más antiguos como mcs. Por lo tanto, si intentas compilar el código con mcs, obtendrás un error debido a esta característica no compatible.*

- *Por otro lado, si utilizas dotnet run para ejecutar un proyecto .NET Core que incluye la anotación de referencia nula string?, no deberías encontrar errores, ya que .NET Core es compatible con esta característica y puede manejarla correctamente.*
