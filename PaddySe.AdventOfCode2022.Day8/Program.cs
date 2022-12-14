using System.Diagnostics;
using PaddySe.AdventOfCode2022.Day8;

var sampleInput = new List<string>
{
	"30373",
	"25512",
	"65332",
	"33549",
	"35390"
};

/* ----- Part 1 ----- */

var treePatch = TreePatch.Create(sampleInput);
var result = treePatch.Part1();
Debug.Assert(result == 21, "Invalid result");
Console.WriteLine($"[VALIDATE 1] {result} are visible from the outside.");

treePatch = TreePatch.Create(File.ReadAllLines("Input.txt"));
result = treePatch.Part1();
Console.WriteLine($"[PART 1] {result} are visible from the outside.");


/* ----- Part 2 ----- */

treePatch = TreePatch.Create(sampleInput);
result = treePatch.Part2();
Debug.Assert(result == 8, "Invalid result");
Console.WriteLine($"[VALIDATE 2] Best scenic score is {result}.");

treePatch = TreePatch.Create(File.ReadAllLines("Input.txt"));
result = treePatch.Part2();
Console.WriteLine($"[PART 2] {result} is the best tree score.");
