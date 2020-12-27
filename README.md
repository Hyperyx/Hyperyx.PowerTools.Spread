# Hyperyx.PowerTools.Spread: ES6 Spread operator for .NET Core

`dotnet add package Hyperyx.PowerTools.Spread --version 1.0.0`

Spread operator creates a deepclone and sets the value for the specified property.

## Usage

You can use the spread operator like the following:

```csharp
namespace Hyperyx-PowerTools-Spread.Demo
{
    public class Person
    {
        public Address Address { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                Address = new Address
                {
                    City = "1"
                }
            };

            // Makes a deep clone and updates the property value.
            var clone = person.Spread(x => x.Address.City, "Amsterdam");

            // The clone has no references to the original object.
            Console.WriteLine(person.Address.City);

            // The spread sets the value in the cloned object.
            Console.WriteLine(clone.Address.City);
        }
    }
}

```


