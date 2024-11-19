class Fruit : Food
{
    public bool Ripe;

    public Fruit(string name, int calories, double price, bool spicy, bool ripe) : base(name, calories, price, spicy)
    {
        Ripe = ripe;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Ripe: {Ripe}");
    }


}