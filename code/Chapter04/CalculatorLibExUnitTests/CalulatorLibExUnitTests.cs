using CalculatorLibEx; // To use calculator

namespace CalculatorLibExUnitTests;

public class CalulatorExUnitTests
{
    [Fact]
    public void TestAdding2And2()
    {
        // Arrange: Setup the inputs and the unit under test
        double a = 2;
        double b = 2;
        double expected = 4;
        Calculator calc = new();

        // Act: Execute the function to test.
        double actual = calc.Add(a, b);

        // Assert: Make assertions to compare expected to actual results
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestAdding2And3()
    {
        // Arrange: Setup the inputs and the unit under test
        double a = 2;
        double b = 3;
        double expected = 5;
        Calculator calc = new();

        // Act: Execute the function to test.
        double actual = calc.Add(a, b);

        // Assert: Make assertions to compare expected to actual results
        Assert.Equal(expected, actual);
    }
}