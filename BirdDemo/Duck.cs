public class Duck : Bird, IFly, ISwim
{

    public Duck(string name) : base(name){}

    public int AirSpeed { get; set; } = 12;
    public int NauticalSpeed { get; set; } = 8;

    public void Fly()
    {
        Console.WriteLine($"{Name} takes to the sky at {AirSpeed} mph");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} paddles off at {NauticalSpeed} knots");
    }
}