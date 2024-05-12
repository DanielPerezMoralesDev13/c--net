<!-- Autor: Daniel Benjamin Perez Morales -->
<!-- GitHub: https://github.com/DanielPerezMoralesDev13 -->
<!-- Correo electrónico: danielperezdev@proton.me  -->
# ***C#/.NET Example Repository***

*This repository contains code examples in C#* ***to help you get started with .NET development. It includes a basic guide to C# syntax and instructions for compiling for Windows and Linux.***

## ***Basic C# Syntax***

### ***Variables and Data Types***

```csharp
int age = 25;
string name = "John";
float height = 1.75f;
bool is_student = true;
```

### ***Control Structures***

```csharp
// If-else
if (age >= 18) {
    Console.WriteLine("Is an adult");
} else {
    Console.WriteLine("Is a minor");
}

// For loop
for (int i = 0; i < 5; i++) {
    Console.WriteLine(i);
}

// While loop
int counter = 0;
while (counter < 3) {
    Console.WriteLine("Hello");
    counter++;
}
```

### ***Functions***

```csharp
public void Greet(string name) {
    Console.WriteLine("Hello, " + name);
}

// Function call
Greet("Abella");
```

## ***Compilation for Windows***

1. *Make sure you have the .NET SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).*

2. *Open a terminal and navigate to the project directory.*

3. *Run the following command to compile:*

```bash
dotnet build -c Release -r win-x64
```

*This will generate the executable for Windows in the directory `bin/Release/net5.0/win-x64/`.*

## ***Compilation for Linux***

1. *Make sure you have the .NET SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).*

2. *Open a terminal and navigate to the project directory.*

3. *Run the following command to compile:*

```bash
dotnet build -c Release -r linux-x64
```

*This will generate the executable for Linux in the directory `bin/Release/net5.0/linux-x64/`.*

---

*Feel free to expand this README as needed to include more information about your project or to tailor it to your specific needs.*
