using System.Text;

//var lines = new List<string>
//{
//	"2-4,6-8",
//	"2-3,4-5",
//	"5-7,7-9",
//	"2-8,3-7",
//	"6-6,4-6",
//	"2-6,4-8"
//};

var lines = File.ReadAllLines("Input.txt");

var expandedLines = Expand(lines);

/* ----- Part 1 ----- */

var containedCount = 0;

foreach (var pair in expandedLines)
{
	if (pair.Item1.Contains(pair.Item2) || pair.Item2.Contains(pair.Item1))
	{
		containedCount++;
	}
}

Console.WriteLine($"[PART 1] Contained count is {containedCount}");


/* ----- Part 2 ----- */

var overlapCount = 0;

foreach (var pair in expandedLines)
{
	if (pair.Item1.Any(pair.Item2.Contains) || pair.Item2.Any(pair.Item1.Contains))
	{
		overlapCount++;
	}
}

Console.WriteLine($"[PART 2] Overlap count is {overlapCount}");



static List<(string, string)> Expand(IEnumerable<string> lines)
{
	var result = new List<(string, string)>();

	foreach (var line in lines)
	{
		var split = line.Split(',');

		result.Add((ExpandPart(split[0]), ExpandPart(split[1])));
	}

	return result;
}

static string ExpandPart(string part)
{
	var parts = part.Split('-');
	var from = int.Parse(parts[0]);
	var to = int.Parse(parts[1]);

	var builder = new StringBuilder();

	for (var i = from; i <= to; i++)
	{
		builder.Append((char)i);
	}

	return builder.ToString();
}