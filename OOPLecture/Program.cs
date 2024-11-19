// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Food Pasta = new("pasta",1000,5.99,true);
Pasta.Name = "Spicy Pasta";
Console.WriteLine(Pasta.Price);
Pasta.Price = 1.00;
Pasta.DisplayInfo();

Fruit Apple = new("apple",100,0.49,false,true);
Apple.DisplayInfo();
Apple.DisplayInfo(8);
Apple.DisplayInfo();

Food Test = new();