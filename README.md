# CsLox

## Description
CsLox is a C# implementation of the Lox programming language interpreter, based on the "Crafting Interpreters" book by Robert Nystrom.

Lox is a lightweight, high-level, dynamically typed, and interpreted language designed for learning and exploring programming language theory and interpreter construction.

CsLox aims to provide a robust and efficient interpreter that adheres closely to the specifications and philosophy of the original Lox language while leveraging the strengths of C#.

## Features
- Full implementation of the Lox language
- Dynamic typing
- Automatic memory management
- First-class functions
- Closures
- Classes and inheritance

## Requirements
- .NET Core 8.0 or higher

## Installation
Clone the repository to your local machine:

```bash
git clone https://github.com/yourusername/CsLox.git
cd CsLox
```

Build the project using .NET CLI:
```bash
dotnet build
```

## Usage
To run a Lox program, use the following command:

```bash
dotnet run --project CsLox path/to/your_script.lox
```

Alternatively, to start an interactive REPL:

```bash
dotnet run --project CsLox
```

## Acknowledgments

- Robert Nystrom, for his excellent book "Crafting Interpreters," which inspired this project.
- The C# community for their continuous support and resources.