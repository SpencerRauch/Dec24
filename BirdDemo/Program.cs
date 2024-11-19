// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Bird FirstBird = new(); // cannot instantiate abstract class

Hawk RedTail = new("Redtail");
Duck Daffy = new("Daffy");
Ostrich Ozzy = new("Ozzy");
RedTail.Fly();
// List<string> Names = ["Spencer","Cory"];


List<Bird> AllBirds = [RedTail,Daffy,Ozzy];
List<IFly> FlyingBirds = [RedTail,Daffy];

foreach (Bird bird in AllBirds)
{
    // bird.Swim(); bird does not have this method
    if (bird is IFly f)
    {
        f.Fly();
    } else if (bird is ISwim s)
    {
        s.Swim();
    } else if (bird is IRun r)
    {
        r.Run();
    }
}


