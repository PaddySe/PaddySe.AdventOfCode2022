using PaddySe.AdventOfCode2022.Day5;

//var lines = new List<string> {
//	"    [D]    ",
//	"[N] [C]    ",
//	"[Z] [M] [P]",
//	" 1   2   3 ",
//	"",
//	"move 1 from 2 to 1",
//	"move 3 from 1 to 3",
//	"move 2 from 2 to 1",
//	"move 1 from 1 to 2"
//};

var lines = File.ReadAllLines("Input.txt");

var positions = lines.TakeWhile(item => !string.IsNullOrEmpty(item)).ToList();
var instructions = lines.Skip(positions.Count + 1).Select(Move.Parse).ToList();

/* ----- Part 1 ----- */

var cargohold = CargoHold.Parse(positions);
instructions.ForEach(cargohold.MoveWithCrateMover9000);

Console.Write("[PART 1] ");
foreach (var column in cargohold.Columns)
{
	Console.Write(column.Peek());
}

Console.WriteLine();


/* ----- Part 2 ----- */

cargohold = CargoHold.Parse(positions);
instructions.ForEach(cargohold.MoveWithCrateMover9001);

Console.Write("[PART 2] ");
foreach (var column in cargohold.Columns)
{
	Console.Write(column.Peek());
}

Console.WriteLine();
