using System.Net;

List<VideoGame> Games = new()
{
    new VideoGame("Apex Legends", "Riot", "E", 0, "Xbox, PC"),
    new VideoGame("The Last of Us", "Naughty Dog", "M", 39.99, "PlayStation"),
    new VideoGame("Untitled Goose Game", "House House", "E", 29.99, "PC"),
    new VideoGame("Super Mario World", "Nintendo", "E", 49.99, "SNES"),
    new VideoGame("Elden Ring", "FromSoftware", "M", 59.99, "PC"),
    new VideoGame("World of Warcraft", "Blizzard", "E", 49.99, "PC"),
    new VideoGame("Overwatch 2", "Blizzard", "T", 0, "PC"),
    new VideoGame { Title = "The Legend of Zelda: Breath of the Wild", Studio = "Nintendo", Rating = "E10+", Price = 59.99, Platform = "Nintendo Switch"},
    new VideoGame { Title = "MonsterHunterWorld", Studio = "Capcom", Rating = "M", Price = 40.99, Platform = "PlayStation 4" },
    new VideoGame { Title = "Grand Theft Auto V", Studio = "Rockstar Games", Rating = "M", Price = 29.99, Platform = "PlayStation 4" },
    new VideoGame { Title = "Minecraft", Studio = "Mojang", Rating = "E10+", Price = 26.95, Platform = "PC" },
    new VideoGame { Title = "Fortnite", Studio = "Epic Games", Rating = "T", Price = 0, Platform = "Various" },
    new VideoGame { Title = "Red Dead Redemption 2", Studio = "Rockstar Games", Rating = "M", Price = 39.99, Platform = "Xbox One" },
    new VideoGame { Title = "Super Mario Odyssey", Studio = "Nintendo", Rating = "E10+", Price = 49.99, Platform = "Nintendo Switch"},
    new VideoGame { Title="Kirby's Air Ride",Studio="Nintendo",Rating="E",Price=20.00,Platform="Gamecube"},
    new VideoGame { Title = "Hades", Studio ="Supergiant Games", Rating = "T", Price = 24.99, Platform ="Various"},
    new VideoGame { Title = "Cuphead", Studio ="Studio MDHR", Rating = "E", Price = 19.99, Platform ="Various"},
    new VideoGame { Title = "Undertale", Studio = "Toby Fox", Rating = "E10+", Price = 9.99, Platform = "Various"},
    new VideoGame { Title = "Star Citizen", Studio ="Cloud Imperium Games", Rating = "M", Price = 45.99, Platform ="PC"},
    new VideoGame {Title = "Mario Kart 8", Studio = "Nintendo", Rating = "E", Price = 60.00, Platform = "Nintendo Switch, Wii U"},
    new VideoGame { Title = "Destiny 2", Studio ="Bungie", Rating = "T", Price = 0, Platform ="Varies"},
    new VideoGame { Title = "Ember Knights", Studio ="Doom Turtle", Rating = "E10+", Price = 19.99, Platform ="Nintendo Switch, PC"},
    new VideoGame { Title = "Terraria", Studio ="Re-Logic", Rating = "E10+", Price = 9.99, Platform ="Various"},
    new VideoGame { Title = "Horizon Zero Dawn", Studio ="Guerrilla Games", Rating = "T", Price = 19.99, Platform ="Playstation 4, Windows"} 

};

// Getting a single result based on criteria
// VideoGame EldenRing = Games.First(g => g.Title == "Elden Rin"); //first will crash if no match 
VideoGame? EldenRing = Games.FirstOrDefault(g => g.Title.Contains("Elfdfdden Rin"));
if (EldenRing == null)
{
    Console.WriteLine("Not found");
    
} 
else 
{
    Console.WriteLine(EldenRing);
    
}
// Console.WriteLine(EldenRing);



// Getting multiple results based on criteria
List<VideoGame> AffordableGames = Games.Where( g => g.Price < 25).ToList();
AffordableGames.ForEach(Console.WriteLine);
IEnumerable<VideoGame> EnumGames = Games.Where( g => g.Price < 25);
// EnumGames.ForEach(Console.WriteLine); // IENumerable does not containt ForEach method


// Getting select pieces of data
List<double> AffordablePrices = AffordableGames.Select(ag => ag.Price).ToList();
List<double> JustThePricesFullQuery = Games.Where(g => g.Price < 25).Select(g => g.Price).ToList();
AffordablePrices.ForEach(Console.WriteLine);


// Ordering / Top 3
List<VideoGame> SpendyOnes = Games.OrderByDescending(g => g.Price).Take(3).ToList();
SpendyOnes.ForEach(Console.WriteLine);

// Logical testing
bool FreeGamesExist = Games.Any(g => g.Price == 0);
bool ContrivedFreeGamesExist = !Games.All( g => g.Price != 0);

Flavor Vanilla = new("Vanilla", false);
Flavor Chocolate = new("Chocolate", false);
Flavor Strawberry = new("Strawberry", false);
Flavor PeanutButter = new("Peanut Butter", true);
Flavor RockyRoad = new("Rocky Road", true);
Flavor MintChocolateChip = new("Mint Chocolate Chip", false);
Flavor CookieDough = new("Cookie Dough", false);
Flavor GreenTea = new( "Green Tea", false);
Flavor Spumoni = new("Spumoni", true);


IceCreamStore Alices = new("Alice's All Flavors", new(){Vanilla,Chocolate,Strawberry,PeanutButter,RockyRoad,MintChocolateChip,CookieDough,GreenTea,Spumoni});
IceCreamStore Fionas = new("Fiona's Few Flavors", new(){Strawberry,GreenTea,MintChocolateChip});
IceCreamStore Carls = new("Carl's Classics", new(){Vanilla,Chocolate,Strawberry,CookieDough,MintChocolateChip,RockyRoad});
IceCreamStore Bobs = new("Bob's Binary Choice",new(){PeanutButter,Chocolate});
IceCreamStore Alexs = new("Alex Miller Goes Nuts",new(){RockyRoad,Spumoni,PeanutButter});

List<IceCreamStore> StoreDirectory = new(){Alices,Fionas,Carls,Bobs,Alexs};

// nested queries 
List<IceCreamStore> NutFreeStoreList = StoreDirectory.Where( s => s.AvailableFlavors.All(f => !f.ContainsNuts)).ToList();
NutFreeStoreList.ForEach(Console.WriteLine);

List<IceCreamStore> CookieStores = StoreDirectory.Where( s => s.AvailableFlavors.Any(f=>f.Name.Contains("Cookie"))).ToList();
CookieStores.ForEach(Console.WriteLine);