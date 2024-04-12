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

## Lox Language Manual

### Introduction
Lox is a dynamically-typed programming language designed for ease of use and clarity. It supports object-oriented principles and offers a robust standard library.

### Data Types

- **Boolean**: true or false
- **Number**: All numbers are floating point. Example: 123, 45.67
- **String**: Text enclosed in double quotes. Example: "Hello, world!"
- **Nil**: Represents the absence of a value or null.

### Variables
Declare variables using the ```var``` keyword. Variables must be initialized upon declaration.

```bash
var name = "Lox";
var version = 1.0;
```

### Control Structures

- Conditional Statements:
    ```bash
    if (condition) {
        // statements
    } else {
        // statements
    }
    ```

- While Loop:
    ```bash
    if (condition) {
        // statements
    } else {
        // statements
    }
    ```

- For Loop:
    ```bash
    for (var i = 0; i < 10; i = i + 1) {
        print i;
    }
    ```

### Functions

Define functions using the ```fun``` keyword. Functions may return values using ```return```.

```bash
fun greet(name) {
  print "Hello " + name + "!";
}
```

### Classes

Lox supports simple classes with inheritance.

```bash
class Animal {
  fun speak() {
    print "Some noise";
  }
}

class Dog < Animal {
  fun speak() {
    print "Bark";
  }
}

```

### Operators

- **Arithmetic**: +, -, *, /
- **Comparison**: ==, !=, <, >, <=, >=
- **Logical**: and, or, !

### Comments
Use // for single-line comments.
```bash
// This is a comment
```

### Standard Functions

- print: Outputs a string to the console.

    ```bash
    print "Hello, world!";
    ```

### Tokens Recognized by the Scanner

The scanner supports various tokens including:

- **Keywords**: and, class, else, false, for, fun, if, nil, or, print, return, super, this, true, var, while
- **Symbols**: (, ), {, }, ,, ., -, +, ;, *, /, !, =, <, >
- **Literals**: Identifiers, strings, numbers
- **Miscellaneous**: Comments, whitespace (spaces, tabs, and new lines are ignored except to separate tokens)

## Acknowledgments

- Robert Nystrom, for his excellent book "Crafting Interpreters," which inspired this project.
- The C# community for their continuous support and resources.