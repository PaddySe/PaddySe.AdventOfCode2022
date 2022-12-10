using System.Diagnostics;
using PaddySe.AdventOfCode2022.Day7;

Validate();

var sampleInput = File.ReadAllLines("Input.txt");
var root = FileSystemEntry.ParseDirectoryStructure(sampleInput);

/* ----- Part 1 ----- */

var directories = root.AllDirectories().Where(item => item.Size < 100000).ToList();
var sum = directories.Sum(item => item.Size);
Console.WriteLine($"[PART 1] Sum size: {sum}");


/* ----- Part 2 ----- */

const int totalSize = 70_000_000;
const int neededSpace = 30_000_000;
var freeSpace = totalSize - root.Size;

var candidate = root.AllDirectories().Where(item => item.Size + freeSpace >= neededSpace).OrderBy(item => item.Size).First();

Console.WriteLine($"[PART 2] Folder to delete: {candidate}");


static void Validate()
{
	var input = new List<string>
	{
		"$ cd /",
		"$ ls",
		"dir a",
		"14848514 b.txt",
		"8504156 c.dat",
		"dir d",
		"$ cd a",
		"$ ls",
		"dir e",
		"29116 f",
		"2557 g",
		"62596 h.lst",
		"$ cd e",
		"$ ls",
		"584 i",
		"$ cd ..",
		"$ cd ..",
		"$ cd d",
		"$ ls",
		"4060174 j",
		"8033020 d.log",
		"5626152 d.ext",
		"7214296 k"
	};

	var root = FileSystemEntry.ParseDirectoryStructure(input);
	var directories = root.AllDirectories().Where(item => item.Size < 100000).ToList();
	var sum = directories.Sum(item => item.Size);
	Debug.Assert(sum == 95437, "Incorrect sum!");
	Console.WriteLine($"[VALIDATION 1] Sum size: {sum}");

	const int totalSize = 70_000_000;
	const int neededSpace = 30_000_000;
	var freeSpace = totalSize - root.Size;
	var candidate = root.AllDirectories().Where(item => item.Size + freeSpace >= neededSpace).OrderBy(item => item.Size).First();

	Debug.Assert(candidate.Name == "d", "Wrong folder to delete");
	Console.WriteLine($"[VALIDATION 2] Folder to delete: {candidate}");
}
