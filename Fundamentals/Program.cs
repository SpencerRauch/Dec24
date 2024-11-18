// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int Age = 36;

string Name = "Spencer";
char OneLetter = 'C';

// PascalCase -> CappedLikeThis

// Console.WriteLine($"My name is {Name} the character was {OneLetter} my age is {Age}");

if ( Age > 30 )
{
    Console.WriteLine("Yes I am getting old");
}

string[] Strings = new string[3];
Strings[0] = "Bob";
Strings[1] = "Alice";
// Console.WriteLine(Strings[0]);
// Console.WriteLine(Strings[2]);
// Console.WriteLine(Strings[1]);

int[] Ints = new int[1];
// Console.WriteLine(Ints[0]);

for (int i = 0; i < Strings.Length; i++)
{
    if (i == 2){
        Strings[i] = "Cory";
    }
    Console.WriteLine(Strings[i]);
    
}

foreach (string s in Strings)
{
    Console.WriteLine(s);
    // s = "Steve";
    
}

List<string> Names = ["Bob", "Alice"];

Names.ForEach(Console.WriteLine);

Dictionary<string,int> PetAges = new()
{
    {"Wiley",5},
    {"Honey",5}
};

Console.WriteLine(PetAges["Wiley"]);

foreach (KeyValuePair<string,int> entry in PetAges)
{
    Console.WriteLine($"The key is {entry.Key} the value is {entry.Value}");
    
}
PetAges.Add("Bob",9);

static void SomeLogging()
{
    Console.WriteLine("Here is my log");
    
}

// SomeLogging();
// SomeLogging();
// SomeLogging();


static int DoSomeMath(int numOne, int numTwo=7)
{
    return numOne * numTwo + numOne / numTwo;
}


Console.WriteLine(DoSomeMath(8,6));
DoSomeMath(4);

