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
    sudo apt install apt-transport-https
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
sudo apt install dotnet-sdk-8.0
```

## ***snap find dotnet-sdk***

```bash
sudo snap find dotnet-sdk
```

```txt
Name        Version  Publisher    Notes    Summary
dotnet-sdk  8.0.204  dotnetcore✓  classic  Develop high performance applications in less time, on any platform.
```

```json
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

> [!WARNING]
> *El error específico que mencionas, CS0453, se refiere al hecho de que estás utilizando el tipo string?, que es una anotación de referencia nula introducida en C# 8.0, pero no está soportada en compiladores más antiguos como mcs. Por lo tanto, si intentas compilar el código con mcs, obtendrás un error debido a esta característica no compatible.*

- *Por otro lado, si utilizas dotnet run para ejecutar un proyecto .NET Core que incluye la anotación de referencia nula string?, no deberías encontrar errores, ya que .NET Core es compatible con esta característica y puede manejarla correctamente.*
