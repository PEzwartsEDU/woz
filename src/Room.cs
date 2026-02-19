using System.Collections.Generic;

class Room {
	private string description;
	private Dictionary<string, Room> exits;
	
	private Inventory chest;
	public Inventory Chest
	{
		get { return chest; }
		//set { chest = value; }
	}

	public Room(string desc)
	{
		description = desc;
		exits = new Dictionary<string, Room>();
		chest = new Inventory(10);
	}

	public void AddExit(string direction, Room neighbor)
	{
		exits.Add(direction, neighbor);
	}

	public string GetShortDescription()
	{
		return description;
	}

	public string GetLongDescription()
	{
		string str = "";
		str += description;
		str += "\n";
		str += GetExitString();
		return str;
	}

	public Room GetExit(string direction)
	{
		if (exits.ContainsKey(direction))
		{
			return exits[direction];
		}
		return null;
	}

	private string GetExitString()
	{
		string str = "Exits: ";
		str += String.Join(", ", exits.Keys);

		return str;
	}
}