class Food
{
    //fields
    public string Name;
    // private int Calories;
    public int Calories { get;set; }
    private double _price;
    public double Price {get{return _price;}set{if (value > 0) _price = value;}}
    private bool Spicy;


    /// <summary> Supply all params </summary>
    public Food(string name, int calories, double price, bool spicy)
    {
        Name = name;
        Calories = calories;
        _price = price;
        Spicy = spicy;
    }

    /// <summary> Makes nameless food </summary>
    public Food( int calories, double price, bool spicy)
    {
        Name = "No Name Given";
        Calories = calories;
        _price = price;
        Spicy = spicy;
    }

    /// <summary> Makes free food </summary>
    public Food(string name, int calories, bool spicy)
    {
        Name = name + "-- FREE!";
        Calories = calories;
        _price = 0;
        Spicy = spicy;
    }

    /// <summary> Makes generic food </summary>
    public Food()
    {
        Name = "Generic";
        Calories = 0;
        _price = 0;
        Spicy = false;
    }


    /// <summary> Display Info </summary>
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Calories: {Calories}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Spicy: {Spicy}");
        
    }

    /// <summary> Display Info times amount of times</summary>
    public virtual void DisplayInfo(int times)
    {
        for (int i = 0; i < times; i++)
        {
            DisplayInfo();
        }
        
    }
}