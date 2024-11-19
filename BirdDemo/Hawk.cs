public class Hawk : Bird, IFly
{

    public Hawk(string name) : base(name){}

    public int AirSpeed { get; set; } = 30;

    public void Fly()
    {
        Console.WriteLine($"{Name} takes to the sky at {AirSpeed} mph");
    }
}