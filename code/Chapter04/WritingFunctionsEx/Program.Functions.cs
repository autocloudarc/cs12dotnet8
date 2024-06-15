using System.ComponentModel.Design;
using System.Globalization; // To use CultureInfo
partial class Program
{
    static void TimesTable(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times tabel with {size} rows:");
        WriteLine();

        for (int row = 1; row <= size; row++)
        {
            WriteLine($"{row} x {number} = {row * number}");
        }
        WriteLine();
    }
    static decimal CalculateTax(
        decimal amount, string twoLetterRegionCode)
    {
        decimal rate = twoLetterRegionCode switch
        {
            "CH" => 0.08M, // Switzerland
            "DK" or "NO" => 0.25M, // Denmark, Norway
            "GB" or "FR" => 0.2M, // UK, France
            "HU" => 0.27M, // Hungary
            "OR" or "AK" or "MT" => 0.0M, // Oregon, Alaska, Montana
            "ND" or "WI" or "ME" or "VA" => 0.05M, // North Dakota, Wisconsin, Maine, Virginia
            "CA" => 0.0825M, // California
            _ => 0.06M // Most other states.
        };

        return amount * rate / 100;
    }
    static void ConfigureConsole(string culture = "en-US",
        bool useComputerCulture = false)
    {
        // To enable Unicode characters like Euro symbol in the console.
        OutputEncoding = System.Text.Encoding.UTF8;
        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"Current culture is {CultureInfo.CurrentCulture.DisplayName}");


    }
    // Using lambdas in function implementations
    static string CardinalToOrdinal(uint number)
    {
        uint lastTwoDigits = number % 100;
        switch (lastTwoDigits)
        {
            case 11:
            case 12:
            case 13:
                return $"{number}th";
            default:
                uint lastDigit = number % 10;
                string suffix = lastDigit switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th"
                };
                return $"{number}{suffix}";
        }
    }

    static void RunCardinalToOrdinal()
    {
        for (uint number = 1; number <= 1500; number++)
        {
            WriteLine($"{CardinalToOrdinal(number)}");
        }
        WriteLine();
    }

    static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(number),
            message: $"The number must be non-negative. Input: {number}");
        }
        else if (number == 0)
        {
            return 1;
        }
        else
        {
            checked // for overflow
            {
                return number * Factorial(number - 1);
            }
        }
    }

    static void RunFactorial()
    {
        for (int number = -2; number <= 15; number++)
        {
            try
            {
                WriteLine($"{number}! = {Factorial(number):N0}");
            }
            catch (OverflowException)
            {
                WriteLine($"{number}! is too large for a 32-bit integer.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                WriteLine($"{e.Message}");
            }
            catch (Exception e)
            {
                WriteLine($"{number}! throws {e.GetType()}: {e.Message}");
            }
        }
    }
    static int FibImperative(uint term) // Imperative
    {
        if (term == 0)
        {
            throw new ArgumentOutOfRangeException(
                paramName: nameof(term),
                message: "The term must be positive.");
        }
        else if (term == 1)
        {
            return 1;
        }
        else if (term == 2)
        {
            return 1;
        }
        else
        {
            return FibImperative(term - 1) + FibImperative(term - 2);
        }
    }
    static void RunFibImperative()
    {
        for (uint i = 1; i <= 30; i++)
        {
            WriteLine($"The {CardinalToOrdinal(i)} term of the Fibonacci sequence is {FibImperative(i):N0}.");
        }
    }

    static int FibFunctional(uint term) => term switch // Functional
    {
        0 => throw new ArgumentOutOfRangeException(),
        1 => 0,
        2 => 1,
        _ => FibFunctional(term -1) + FibFunctional(term - 2)
    };

    static void RunFibFunctional()
    {
        for (uint i = 1; i <= 30; i++)
        {
            try
            {
                WriteLine($"The {CardinalToOrdinal(i)} term of the Fibonacci sequence is {FibFunctional(i):N0}.");
            }
            catch (ArgumentOutOfRangeException)
            {
                WriteLine($"The {CardinalToOrdinal(i)} term is too large for a 32-bit integer.");
            }
            catch (Exception e)
            {
                WriteLine($"{e.GetType()}: {e.Message}");
            }
        }
    }
}