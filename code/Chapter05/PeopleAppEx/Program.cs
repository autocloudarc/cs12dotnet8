using Packt.Shared; // To use Person.
using Fruit = (string Name, int Number); // Aliasing a tuple type

ConfigureConsole(); // Sets current culture to US English.

// Alternatives:
// ConfigureConsole(useComputerCulture: true); // Sets current culture to computer culture.
// ConfigureConsole(culture: "fr-FR"); // Sets current culture to French.

Person bob = new(); // C# 9 or Later.
WriteLine(bob); // Implicit call to ToString().
// WriteLine(bob.ToString()); // Does the same thing

bob.Name = "Bob Smith";

bob.Born = new DateTimeOffset(
    year: 1965, month: 12, day: 22,
    hour: 16, minute: 28, second: 0,
    offset: TimeSpan.FromHours(-5)); // US Eastern Time.

WriteLine(format: "{0} was born on {1:D}.", // Long date.
    arg0: bob.Name, arg1: bob.Born);

Person alice = new()
{
    Name = "Alice Jones",
    Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero)
};

WriteLine(format: "{0} was born on {1:d}.", arg0: alice.Name, arg1: alice.Born);

bob.BucketListEx = WondersOfTheAncientWorldEx.HangingGardensOfBabylon
    | WondersOfTheAncientWorldEx.MausoleumAtHalicarnassus;
WriteLine($"{bob.Name}'s bucket list is {bob.BucketListEx}.");

bob.Children.Add(new Person { Name = "Alfred" });
bob.Children.Add(new Person { Name = "Bella" });
bob.Children.Add(new Person { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");
foreach (Person child in bob.Children)
{
    WriteLine($"  {child.Name}");
}

BankAccount.InterestRate = 0.012M; // Store a shared value in the static field.

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: jonesAccount.AccountName,
    arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: gerrierAccount.AccountName,
    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

// Constant fields are accessibble via the type.
WriteLine($"{bob.Name} is a {Person.Species}.");
WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");

/*Book book = new()
{
    Isbn = "978-0-321-87758-1",
    Title = "Professional C# 7 and .NET Core 2.0"
};
*/

Book book = new(isbn: "978-0-321-87758-1",
    title: "Professional C# 7 and .NET Core 2.0")
{
    Author = "Mark J. Price",
    PageCount = 821
};

WriteLine($"ISBN: {book.Isbn}, {book.Title} is written by {book.Author} and contains {book.PageCount:N0} pages.");

Person blankPerson = new();
WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
       arg0: blankPerson.Name,
       arg1: blankPerson.HomePlanet,
       arg2: blankPerson.Instantiated);

int a = 10;
int b = 20;
int c = 30;
int d = 40;

WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");
bob.PassingParameters(a, in b, ref c, out d);
WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

//(string, int) fruit = bob.GetFruit();
/*var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");
*/
var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

// With an aliased tuple type.
Fruit fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

// Store return value in a tuple variable with two named fields.
(string name, int number) namedFields = bob.GetNamedFruit();
// Access the fields by name.
WriteLine($"Deconstructed tuple: {namedFields.name}, {namedFields.number}");

var (name1, dob1) = bob; // Implicitly calls the Deconstruct method.
WriteLine($"Deconstructed person: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

// Change to -1 to make the exception handling code execute.
int number = -1;

try
{
    WriteLine($"{number}! = {Person.Factorial(number)}");
}
catch (Exception Ex)
{
    WriteLine($"{Ex.GetType()} says: {Ex.Message} number was {number}.");
}

Person sam = new()
{
    Name = "Sam",
    Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero  )
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);