// All types in this file will be defined in this file-scoped namespace.
namespace Packt.Shared;

public partial class Person : object
{
    #region Fields: Data or state for this person.

    public string? Name { get; set; } // ? means nullable.
    public DateTimeOffset Born;

    #endregion

    public WondersOfTheAncientWorldEx BucketListEx;

    public List<Person> Children = new();

    // Constant fields: Values that are fixed at compilation.
    public const string Species = "Homo Sapiens";

    // Read-only fields: Values that can be set at runtime
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    #region Constructors: Called when using new to instantiate a type.

    public Person()
    {
        // Constructors can set default values for fields
        // Including any read-only fields like Instantiated.
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }
    #endregion

    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        // out parameters cannot have a default and they
        // must be initialized inside the method.
        z = 100;
        // Increment each parameter except the read-only x.
        w++;
        // x++; // Gives a compiler error!
        y++;
        z++;
        WriteLine($"In the method: w={w}, x={x}, y={y}, z={z}");
    }

    // Method that returns a tuple: (string, int).
    public (string Name, int Number) GetNamedFruit()
    {
        return ("Name: Apples", Number: 5);
    }

    // Deconstructors: Break down this object into parts.
    public void Deconstruct(out string? name, out DateTimeOffset dob)
    {
        name = Name;
        dob = Born;
    }

    public void Deconstruct(out string? name,
        out DateTimeOffset dob,
        out WondersOfTheAncientWorldEx fav)
    {
        name = Name;
        dob = Born;
        fav = BucketListEx;
    }

    // Mehtod with a local function.
    public static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException(
                               $"{nameof(number)} cannot be less than zero.");
        }
        return localFactorial(number);

        int localFactorial(int localNumber) // Local function.
        {
            if (localNumber == 0) return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }
}