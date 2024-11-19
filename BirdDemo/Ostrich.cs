public class Ostrich : Bird, IRun
{
    public int Speed { get ; set ; } = 32;

    public Ostrich(string name) : base(name){}

    public void Run()
    {
        Console.WriteLine($"{Name} run off at {Speed} mph");
    }
}