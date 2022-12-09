
using System.Text.RegularExpressions;

namespace PaddySe.AdventOfCode2022.Day5;

public class Move
{
	private Move() { }

	public int CratesToMove { get; set; }

	public int FromColumn { get; set; }

	public int ToColumn { get; set; }

	private static readonly Regex InstructionPattern = new("^move (?<count>\\d+) from (?<from>\\d) to (?<to>\\d)$");

	public static Move Parse(string instructions)
	{
		var match = InstructionPattern.Match(instructions);
		return new Move
		{
			CratesToMove = int.Parse(match.Groups["count"].Value),
			FromColumn = int.Parse(match.Groups["from"].Value),
			ToColumn = int.Parse(match.Groups["to"].Value)
		};
	}
}