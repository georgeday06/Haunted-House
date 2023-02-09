Room[] house = new Room[7];
house[0] = new Room("Hallway", new int[] { -1, 1, 3, -1 }, "Room0", false);
house[1] = new Room("Study", new int[] { -1, 2,-1, 0}, "Room1", false);
house[2] = new Room("Library", new int[] { -1, -1, -1, 1 }, "Room2", false);
house[3] = new Room("Kitchen", new int[] { 0, 4, 5, -1 }, "Room3", false);
house[4] = new Room("Cellar", new int[] { -1, -1, 6, 3 }, "Room4", false);
house[5] = new Room("Courtyard", new int[] { 3, 6, -1, -1 }, "Room5", false);
house[6] = new Room("Garden", new int[] { 4, -1, -1, 5 }, "Room6", false);
Player player = new Player(0,0);

Random R = new Random();
house[R.Next(1,6)].AddKey();
house[R.Next(1, 6)].AddKey();

int currentRoom = 0;
List<string> validCommands = new List<string>();

while (true)
{
    string command = "";
    validCommands.Clear();
    Console.WriteLine("You are currently in: " + house[currentRoom].getName());
    Console.WriteLine("From here you can travel to: ");
    int[] neighbouringRooms = house[currentRoom].getConnections();

    if (neighbouringRooms[0] >= 0){validCommands.Add("North");}
    if (neighbouringRooms[1] >= 0) { validCommands.Add("East"); }
    if (neighbouringRooms[2] >= 0) { validCommands.Add("South"); }
    if (neighbouringRooms[3] >= 0) { validCommands.Add("West"); }

    
    foreach (var direction in validCommands)
    {
        Console.WriteLine(direction);
    }

    while (validCommands.Contains(command) == false)
    {
        Console.WriteLine("Where do you want to go?");
        command = Console.ReadLine();
    }
    if (command =="North") {currentRoom=neighbouringRooms[0];}
    else if (command == "East") { currentRoom = neighbouringRooms[1]; }
    else if (command == "South") { currentRoom = neighbouringRooms[2]; }
    else if (command == "West") { currentRoom = neighbouringRooms[3]; }
    player.SetCurrentRoom(currentRoom);
}

class Room
{
    private string Name;
    private int[] connections;
    private string Description;
    private bool containsKey;

    public Room(string n,int[] c, string d, bool ck)
    {
        Name = n;
        connections = c;
        Description = d;
        containsKey = ck;
    }

    public string getName()
    {
        return Name;
    }
    public string getDescription()
    {
        return Description;
    }
    public int[] getConnections()
    {
        return connections;
    }
    public bool getContainsKey()
    {
        return containsKey;
    }
    public void AddKey()
    {
        containsKey = true;
        getContainsKey();
    }
    public void RemoveKey()
    {
        containsKey = false;
        getContainsKey();
    }
}

class Player
{
    private int currentRoom;
    private int keys;

    public Player(int cr, int k)
    {
        currentRoom = cr;
        keys = k;
    }
    public int GetCurrentRoom()
    {
        return currentRoom;
    }
    public void SetCurrentRoom(int scr)
    {
        currentRoom = scr;
    }
    public void TakeKey(bool cK)
    {
        if (cK == true)
        {
            Console.WriteLine("You picked up a key!");
        }
    }
    public void unlockDoor()
    {
        if (currentRoom == 6 && keys == 2)
        {

        }
    }
}