using System.Collections.Generic;

class CommandLibrary
{
	private readonly List<string> validCommands;

	public CommandLibrary()
	{
		validCommands = new List<string>();

		validCommands.Add("help");
		validCommands.Add("go");
		validCommands.Add("look");
		validCommands.Add("status");
		validCommands.Add("quit");
	}

	public bool IsValidCommandWord(string instring)
	{
		return validCommands.Contains(instring);
	}

	public string GetCommandsString()
	{
		return String.Join(", ", validCommands);
	}
}