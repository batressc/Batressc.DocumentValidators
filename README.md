# Verificación de DUI y NIT para El Salvador

## Actualización crítica (22/08/2022)

>Se reportó que los DUIs terminados en cero no se validaban correctamente. Se realizó la corrección correspondiente. Muchas gracias a **Saúl Valdez.** 

Esta librería de clases contiene dos métodos de extensión para el tipo de dato `System.String` que permite validar si el NIT o el DUI poseen el formato correcto y si sus dígitos son válidos, determinando el dígito validador.

A continuación se presenta código de una aplicación de consola (.NET 6) donde se verifica un DUI y NIT:

```csharp
// Especificamos que vamos a utilizar los métodos de extensión
using Batressc.DocumentValidators.Extensions;

namespace ConsoleApp1 {
    internal class Program {
        static void Main(string[] args) {
            string dui = "03096201-2";
            Console.WriteLine($"Validating dui {dui}: {dui.IsValidDUI()}");
            string nit = "0513-010180-238-7";
            Console.WriteLine($"Validating nit {nit}: {nit.IsValidNIT()}");
        }
    }
}
```

Los métodos de extensión poseen dos enumeradores que modifican el comportanmiento de los validadores: 

- `MiddleDashBehavior` determina si se aceptan o no los guiones medios en el DUI o NIT. Por defecto su valor es `Opcional`. 
- `EvaluatorMode` determina si la cadena de entrada permitirá espacios en blanco al principio o al final. Por defecto su valor es `Strict` (no permite espacios).

Para cambiar el comportamiento por defecto, solamente hay que especificar uno o ambos parámetros al llamar a los métodos de extensión:

```csharp
// no se permiten guiones en la cadena de entrada. Este valor retornará False
string dui = "03096201-2";
dui.IsValidDUI(MiddleDashBehavior.NotUse);

// No se permiten guiones y se permiten espacios al principio o al final. Este valor retornará True
string nit = "    05130101802387   ";
nit.IsValidNIT(MiddleDashBehavior.NotUse, EvaluatorMode.Permissive);  

