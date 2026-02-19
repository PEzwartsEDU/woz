using System;

class Game
{
	private Parser parser;
	private Player player;
	//private Room currentRoom;

	public Game()
	{
		parser = new Parser();
		player = new Player();
		CreateRooms();
	}

	private void CreateRooms()
	{
		// Level 0

		Room dungeon_d = new Room("[CAMPUS] You are in front of a flight of stone stairs ?HMMMMM?");
		Room dungeon = new Room("[DUNGGEON] You are in an dungeon !");

		Room hallway0 = new Room("[DUNGEON] You are in an hallway !");
		Room door0 = new Room("You are in front of an locked door !");

		Room den = new Room("[DUNGEON] You are in an dragon's lair !");
		//Item den = new Item(10, "sword", "Powerful sword");
		//den.Chest.Put(den);

		Room hallway1 = new Room("[DUNGEON] You are in an hallway !");
		Room door1 = new Room("[DUNGEON] You are in an open door !");

		// Might not be used.
		Room secret = new Room("[DUNGEON] You are in an secret room !");

		Room portal = new Room("[DUNGEON] You are in front of an wormhole; Enter?");

		//Room white_house = new Room("[WHITE_HOUSE] You are in the White House of the U.S.A !");
		//Room oval_office = new Room("[OVAL_OFFICE] You are in front of sleepy sleepy donald ...");

		// Level 1

		Room campus = new Room("[CAMPUS] You are on campus");
		Room theatre = new Room("[CAMPUS] You are in the theatre");
		Room pub = new Room("[CAMPUS] You are in the alcohol heaven");
		Room lab = new Room("[CAMPUS] You are in the computing lab");
		Room office = new Room("[CAMPUS] You are in the admin office");

		// Level 0

		//Room valhalla = new Room("[VALHALLA] You gave reached valhalla. Game over.");

		dungeon_d.AddExit("s", campus);
		dungeon_d.AddExit("n", dungeon);

		dungeon.AddExit("s", dungeon_d);
		dungeon.AddExit("n", hallway0);
		
		hallway0.AddExit("n", den);
		hallway0.AddExit("s", dungeon);
		hallway0.AddExit("e", door0);

		door0.AddExit("w", hallway0);

		den.AddExit("s", hallway0);
		den.AddExit("w", hallway1);

		hallway1.AddExit("n", door1);
		hallway1.AddExit("e", den);

		door1.AddExit("s", hallway1);

		// Level 1
		
		campus.AddExit("n", dungeon_d);
		campus.AddExit("s", lab);
		campus.AddExit("e", theatre);
		campus.AddExit("w", pub);
		
		pub.AddExit("e", campus);
		theatre.AddExit("w", campus);

		lab.AddExit("n", campus);
		lab.AddExit("e", office);

		office.AddExit("w", lab);

		player.CurrentRoom = campus;
	}

	public void Play()
	{
		PrintWelcome();

		bool finished = false;
		while (!finished)
		{
			Command command = parser.GetCommand();
			finished = ProcessCommand(command);

			if (player.IsAlive() == false) {
				break;
			}
		}
		Console.WriteLine("Thank you for playing.");
		Console.WriteLine("Press [Enter] to continue.");
		Console.ReadLine();
	}

	private void PrintWelcome()
	{
		Console.WriteLine("WORLD OF ZUUL.\n");
		Console.WriteLine("Zuul an a vibrant realm filled with mystical creatures, ancient forests, and towering mountains. It is a land where magic thrives, and elemental forces govern nature.\n");
		Console.WriteLine("Gandalf, a wise and powerful wizard, revered for his understanding of the arcane and his unwavering commitment to safeguarding Zuul from dark forces.\n");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	private bool ProcessCommand(Command command)
	{
		bool wantToQuit = false;

		if(command.IsUnknown())
		{
			Console.WriteLine("I don't know what you mean...");
			return wantToQuit; // false
		}

		switch (command.CommandWord)
		{
			case "help":
				PrintHelp();
				break;
			case "go":
				GoRoom(command);
				break;
			case "look":
				Look();
				break;
			case "status":
				Status();
				break;
			case "quit":
				wantToQuit = true;
				break;
		}

		return wantToQuit;
	}
	
	private void PrintHelp()
	{
		Console.WriteLine("You are lost. You are alone.");
		Console.WriteLine("You wandering around.\n");
		parser.PrintValidCommands();
	}

	private void GoRoom(Command command)
	{
		if(!command.HasSecondWord())
		{
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;

		Room nextRoom = player.CurrentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to "+direction+"!");
			return;
		}

		player.Damage(5);
		player.CurrentRoom = nextRoom;
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	private void Look() {
		Console.WriteLine(player.CurrentRoom.GetShortDescription());
	}
	
	private void Status() {
		Console.WriteLine(player.health);
	}

	private void Death() {
		Console.WriteLine("## GAME OVER ##");
	}
}