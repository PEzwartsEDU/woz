using System;

class Game
{
	// Private fields
	private Parser parser;
	private Player player;
	//private Room currentRoom;

	// Constructor
	public Game()
	{
		parser = new Parser();
		player = new Player();
		CreateRooms();
	}

	// Initialise the Rooms (and the Items)
	private void CreateRooms()
	{
		// Level 0

		Room dungeon_d = new Room("[CAMPUS] You are in front of a flight of stone stairs ?HMMMMM?");
		Room dungeon = new Room("[DUNGGEON] You are in an dungeon !");

		Room hallway0 = new Room("[DUNGEON] You are in an hallway !");
		Room door0 = new Room("You are in front of an locked door !");

		Room den = new Room("[DUNGEON] You are in an dragon's lair !");

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
		
		// Create your Items here
		// ...
		// And add them to the Rooms
		// ...

		// Start game outside
		player.CurrentRoom = campus;
	}

	//  Main play routine. Loops until end of play.
	public void Play()
	{
		PrintWelcome();

		// Enter the main command loop. Here we repeatedly read commands and
		// execute them until the player wants to quit.
		bool finished = false;
		while (!finished)
		{
			Command command = parser.GetCommand();
			finished = ProcessCommand(command);
		}
		Console.WriteLine("Thank you for playing.");
		Console.WriteLine("Press [Enter] to continue.");
		Console.ReadLine();
	}

	// Print out the opening message for the player.
	private void PrintWelcome()
	{
		Console.WriteLine("WORLD OF ZUUL.\n");
		Console.WriteLine("Zuul an a vibrant realm filled with mystical creatures, ancient forests, and towering mountains. It is a land where magic thrives, and elemental forces govern nature.\n");
		Console.WriteLine("Gandalf, a wise and powerful wizard, revered for his understanding of the arcane and his unwavering commitment to safeguarding Zuul from dark forces.\n");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	// Given a command, process (that is: execute) the command.
	// If this command ends the game, it returns true.
	// Otherwise false is returned.
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
				break;
			case "quit":
				wantToQuit = true;
				break;
		}

		return wantToQuit;
	}

	// ######################################
	// implementations of user commands:
	// ######################################
	
	// Print out some help information.
	// Here we print the mission and a list of the command words.
	private void PrintHelp()
	{
		Console.WriteLine("You are lost. You are alone.");
		Console.WriteLine("You wandering around.\n");
		// let the parser print the commands
		parser.PrintValidCommands();
	}

	// Try to go to one direction. If there is an exit, enter the new
	// room, otherwise print an error message.
	private void GoRoom(Command command)
	{
		if(!command.HasSecondWord())
		{
			// if there is no second word, we don't know where to go...
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;

		// Try to go to the next room.
		Room nextRoom = player.CurrentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to "+direction+"!");
			return;
		}

		player.CurrentRoom = nextRoom;
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	private void Look() {
		Console.WriteLine(player.CurrentRoom.GetShortDescription());
	}
	
	private void Status() {
		Console.WriteLine();
	}
}